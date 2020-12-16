using ARPLogistic.Administration;
using ARPLogistic_BE;
using ARPLogistic_BE.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARPLogistic
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            mdlGlobal.loadXML();

            if (args != null &&
                args.Length > 1)
            {
                //MessageBox.Show(args[0]);
               // Global.MyBranchOffice = args[0];
                Global.CompanyCode = args[1];
                Global.intUserID = Convert.ToInt32(args[2]);
                Application.Run(new frmMain());
            }
            else
            {
                //if (args.Length > 0 && args[0] == "-Update-")
                //{
                if (!File.Exists(Directory.GetCurrentDirectory() + @"\Updater.exe"))
                {
                    ApplicationUpdater(mdlGlobal.FtpRemoteHost, mdlGlobal.ftpUser, mdlGlobal.FtpPassword, "Updater.zip", "avUpd.xml");
                }

                ////Check Application Version
                //ApplicationUpdater(mdlGlobal.FtpRemoteHost, mdlGlobal.ftpUser, mdlGlobal.FtpPassword, "Version.txt", "");
                CultureInfo MyCultureInfo = new CultureInfo("en-US");
                ftp ftpClient = new ftp(@"ftp://" + mdlGlobal.FtpRemoteHost, mdlGlobal.ftpUser, mdlGlobal.FtpPassword);
                string appPath = Directory.GetCurrentDirectory() + @"\";
                ftpClient.download(mdlGlobal.ftpPath + "Version.txt", appPath + "Version.txt");
                if (ftpClient.error == null)
                {
                    try
                    {
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        //MessageBox.Show(assembly.Location);
                        var AppInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                        string CompName = AppInfo.CompanyName;
                        string CurrentVersion = AppInfo.ProductVersion.Trim();
                        var u1 = new Version(CurrentVersion);
                        //MessageBox.Show(CurrectVersion);

                        string NewVersion = File.ReadAllText(appPath + "Version.txt");
                        var u2 = new Version(NewVersion);
                        //MessageBox.Show(NewVersion);

                        if (u1.CompareTo(u2) < 0)
                        {
                            //    //update Updater.exe
                            //    //ApplicationUpdater(mdlGlobal.FtpRemoteHost, mdlGlobal.ftpUser, mdlGlobal.FtpPassword, "AVUpdater.zip", "av.xml");
                            //string message = "Aplikasi ini ada Versi terbarunya, apakah anda mau mengupgrade nya?";
                            //string title = AppInfo.ProductName + " - New Version";
                            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            //DialogResult result = MessageBox.Show(message, title, buttons);
                            //if (result == DialogResult.Yes)
                            frmUpdater frmUpdater = new frmUpdater(NewVersion, CurrentVersion, CompName);
                            frmUpdater.ShowDialog();
                            if (frmUpdater.Status == 1)
                            {
                                Application.Exit();
                                //MessageBox.Show("harusnya AllVision nya sudah exit dan mau buka updater");
                                //    //---------------------
                                try
                                {
                                    //try { foreach (Process proc in Process.GetProcessesByName("AllVision")) { proc.Kill(); } }
                                    //catch (Exception ex) {  MessageBox.Show(ex.Message);  }

                                    Process updater = new Process();
                                    updater.StartInfo.FileName = Directory.GetCurrentDirectory() + @"\Updater.exe";
                                    updater.StartInfo.Arguments = "--FtpRemoteHost:" + mdlGlobal.FtpRemoteHost + " --FtpUser:" + mdlGlobal.ftpUser + " --FtpPassword:" + mdlGlobal.FtpPassword + " AllVision Balimoon av";
                                    //updater.StartInfo.UseShellExecute = true;
                                    //updater.StartInfo.RedirectStandardOutput = true;
                                    updater.StartInfo.CreateNoWindow = false;
                                    updater.Start();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, Global.strProductName);
                                }
                                //MessageBox.Show("Buka updater");
                            }
                            else
                                Application.Run(new frmLogin());
                        }
                        else
                            Application.Run(new frmLogin());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Global.strProductName);
                    }
                }
                else
                    Application.Run(new frmLogin());
            }
        }


        //update Aplikasi
        [DllImport("Kernel32.dll")]
        static extern bool QueryFullProcessImageName([In] IntPtr hProcess, [In] uint dwFlags, [Out] System.Text.StringBuilder lpExeName, [In, Out] ref uint lpdwSize);
        static string GetMainModuleFileName(this Process process, int buffer = 1024)
        {
            var fileNameBuilder = new System.Text.StringBuilder(buffer);
            uint bufferLength = (uint)fileNameBuilder.Capacity + 1;
            return QueryFullProcessImageName(process.Handle, 0, fileNameBuilder, ref bufferLength) ? fileNameBuilder.ToString() : null;
        }
        static void ApplicationUpdater(string ftpHost, string ftpUser, string ftpPassword, string zipFile, string md5File, string filePath = "")
        {
            CultureInfo MyCultureInfo = new CultureInfo("en-US");
            ftp ftpClient = new ftp(@"ftp://" + ftpHost, ftpUser, ftpPassword);
            string appPath = Directory.GetCurrentDirectory() + @"\";
            string updatePath = Directory.GetCurrentDirectory() + @"\update\";
            if (filePath == "") { filePath = appPath; }
            //prepare update folder
            if (!Directory.Exists(updatePath))
            {
                Directory.CreateDirectory(updatePath);
            }
            else
            {
                DirectoryInfo dInfo = new DirectoryInfo(updatePath);
                //delete files:
                foreach (FileInfo file in dInfo.GetFiles())
                    file.Delete();
                //delete directories in this directory:
                foreach (DirectoryInfo subDirectory in dInfo.GetDirectories())
                    subDirectory.Delete(true);
            }
            //Get zip file
            ftpClient.download(mdlGlobal.ftpPath + zipFile, updatePath + zipFile);
            long ufSize = ftpClient.getFileSize(mdlGlobal.ftpPath + zipFile);
            if (ftpClient.error == null)
            {
                if (File.Exists(updatePath + zipFile))
                {
                    FileInfo fi = new FileInfo(updatePath + zipFile);
                    long dfSize = fi.Length;
                    DateTime dfDateTime = fi.CreationTime;
                    if (dfSize == ufSize)
                    {
                        //Get MD5 file
                        ftpClient.download(mdlGlobal.ftpPath + md5File, updatePath + md5File);
                        if (ftpClient.error == null)
                        {
                            if (File.Exists(updatePath + md5File))
                            {
                                File.Copy(Path.Combine(appPath, "fciv.exe"), Path.Combine(updatePath, "fciv.exe"), true);
                                Directory.SetCurrentDirectory(updatePath);
                                //check MD5 hash file
                                //Create Process Start information
                                ProcessStartInfo processStartInfo = new ProcessStartInfo("fciv.exe", "-v -xml " + md5File);
                                processStartInfo.ErrorDialog = false;
                                processStartInfo.UseShellExecute = false;
                                processStartInfo.RedirectStandardError = true;
                                processStartInfo.RedirectStandardInput = true;
                                processStartInfo.RedirectStandardOutput = true;
                                //Execute the process
                                Process process = new Process();
                                process.StartInfo = processStartInfo;
                                bool processStarted = process.Start();
                                if (processStarted)
                                {
                                    //Get the output stream
                                    StreamReader outputReader = process.StandardOutput;
                                    StreamReader errorReader = process.StandardError;
                                    process.WaitForExit();
                                    //Display the result
                                    string displayText = "Output" + Environment.NewLine + "==============" + Environment.NewLine;
                                    displayText += outputReader.ReadToEnd();
                                    displayText += Environment.NewLine + "Error" + Environment.NewLine + "==============" +
                                            Environment.NewLine;
                                    displayText += errorReader.ReadToEnd();
                                    if (displayText.Contains("All files verified successfully"))
                                    {
                                        //extract zip file
                                        ZipFile.ExtractToDirectory(updatePath + zipFile, updatePath + @"\extract");
                                        //using (var zipFileList = new ZipFile(updatePath + zipFile))
                                        //{
                                        //    zipFileList.ExtractAll(updatePath + @"\extract");
                                        //}

                                        //copy to extract files
                                        string sourceDir = updatePath + @"\extract";
                                        try
                                        {
                                            string[] fileList = Directory.GetFiles(sourceDir, "*.*");
                                            foreach (string f in fileList)
                                            {
                                                // Remove path from the file name.
                                                string fName = f.Substring(sourceDir.Length + 1);
                                                // Use the Path.Combine method to safely append the file name to the path.
                                                // Will overwrite if the destination file already exists.
                                                File.Copy(Path.Combine(sourceDir, fName), Path.Combine(filePath, fName), true);
                                            }
                                        }
                                        catch (DirectoryNotFoundException dirNotFound)
                                        {
                                            MessageBox.Show(dirNotFound.Message);
                                        }
                                    }
                                }
                                Directory.SetCurrentDirectory(appPath);
                            }
                        }
                    }
                }
            }
            ftpClient = null;
        }
    }
}
