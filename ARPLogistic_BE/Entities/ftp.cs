using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ARPLogistic_BE.Entities
{
    public class ftp
    {
        private string host = null;
        private string user = null;
        private string pass = null;
        private FtpWebRequest ftpRequest = null;
        private FtpWebResponse ftpResponse = null;
        private Stream ftpStream = null;
        private int bufferSize = 2048;
        private CultureInfo MyCultureInfo = new CultureInfo("en-US");
        public string error = null;

        public ftp(string hostIP, string userName, string password) { host = hostIP; user = userName; pass = password; }

        public void download(string remoteFile, string localFile)
        {
            error = null;
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpStream = ftpResponse.GetResponseStream();
                FileStream localFileStream = new FileStream(localFile, FileMode.Create);
                byte[] byteBuffer = new byte[bufferSize];
                int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                try
                {
                    while (bytesRead > 0)
                    {
                        localFileStream.Write(byteBuffer, 0, bytesRead);
                        bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                    }
                }
                //catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                catch (Exception ex) { error = ex.ToString() + '\n'; }
                localFileStream.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
            }
            //catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            catch (Exception ex) { error = error + ex.ToString(); }
            return;
        }

        public void upload(string remoteFile, string localFile)
        {
            error = null;
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpStream = ftpRequest.GetRequestStream();
                FileStream localFileStream = new FileStream(localFile, FileMode.Open);
                byte[] byteBuffer = new byte[bufferSize];
                int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                try
                {
                    while (bytesSent != 0)
                    {
                        ftpStream.Write(byteBuffer, 0, bytesSent);
                        bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                    }
                }
                //catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                catch (Exception ex) { error = ex.ToString() + '\n'; }
                localFileStream.Close();
                ftpStream.Close();
                ftpRequest = null;
            }
            //catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            catch (Exception ex) { error = error + ex.ToString(); }
            return;
        }

        public void delete(string deleteFile)
        {
            error = null;
            try
            {
                ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + deleteFile);
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpResponse.Close();
                ftpRequest = null;
            }
            //catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            catch (Exception ex) { error = ex.ToString(); }
            return;
        }

        public void rename(string currentFileNameAndPath, string newFileName)
        {
            error = null;
            try
            {
                ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + currentFileNameAndPath);
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.Rename;
                ftpRequest.RenameTo = newFileName;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpResponse.Close();
                ftpRequest = null;
            }
            //catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            catch (Exception ex) { error = ex.ToString(); }
            return;
        }

        public void createDirectory(string newDirectory)
        {
            error = null;
            try
            {
                ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + newDirectory);
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpResponse.Close();
                ftpRequest = null;
            }
            //catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            catch (Exception ex) { error = ex.ToString(); }
            return;
        }

        public DateTime getFileCreatedDateTime(string fileName)
        {
            error = null;
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + fileName);
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                DateTime fileInfo = ftpResponse.LastModified;
                ftpResponse.Close();
                ftpRequest = null;
                return fileInfo;
            }
            //catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            catch (Exception ex) { error = error + ex.ToString(); }
            return DateTime.ParseExact("1/1/1900", "D", MyCultureInfo);
        }

        public long getFileSize(string fileName)
        {
            error = null;
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + fileName);
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                long fileInfo = ftpResponse.ContentLength;
                ftpResponse.Close();
                ftpRequest = null;
                return fileInfo;
            }
            //catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            catch (Exception ex) { error = error + ex.ToString(); }
            return 0;
        }

        public string[] directoryListSimple(string directory)
        {
            error = null;
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + directory);
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpStream = ftpResponse.GetResponseStream();
                StreamReader ftpReader = new StreamReader(ftpStream);
                string directoryRaw = null;
                try { while (ftpReader.Peek() != -1) { directoryRaw += ftpReader.ReadLine() + "|"; } }
                //catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                catch (Exception ex) { error = ex.ToString() + '\n'; }
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                try { string[] directoryList = directoryRaw.Split("|".ToCharArray()); return directoryList; }
                //catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                catch (Exception ex) { error = error + ex.ToString() + '\n'; }
            }
            //catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            catch (Exception ex) { error = error + ex.ToString(); }
            return new string[] { "" };
        }

        public string[] directoryListDetailed(string directory)
        {
            error = null;
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + directory);
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpStream = ftpResponse.GetResponseStream();
                StreamReader ftpReader = new StreamReader(ftpStream);
                string directoryRaw = null;
                try { while (ftpReader.Peek() != -1) { directoryRaw += ftpReader.ReadLine() + "|"; } }
                //catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                catch (Exception ex) { error = ex.ToString() + '\n'; }
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                try { string[] directoryList = directoryRaw.Split("|".ToCharArray()); return directoryList; }
                //catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                catch (Exception ex) { error = error + ex.ToString() + '\n'; }
            }
            //catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            catch (Exception ex) { error = error + ex.ToString(); }
            return new string[] { "" };
        }
    }
}
/* HOW TO USED ----------------
// Create Object Instance 
ftp ftpClient = new ftp(@"ftp://10.10.10.10/", "user", "password");

// Upload a File 
ftpClient.upload("etc/test.txt", @"C:\Users\metastruct\Desktop\test.txt");

// Download a File 
ftpClient.download("etc/test.txt", @"C:\Users\metastruct\Desktop\test.txt");

// Delete a File 
ftpClient.delete("etc/test.txt");

// Rename a File 
ftpClient.rename("etc/test.txt", "test2.txt");

// Create a New Directory 
ftpClient.createDirectory("etc/test");

// Get the Date/Time a File was Created 
string fileDateTime = ftpClient.getFileCreatedDateTime("etc/test.txt");
Console.WriteLine(fileDateTime);

// Get the Size of a File
string fileSize = ftpClient.getFileSize("etc/test.txt");
Console.WriteLine(fileSize);

// Get Contents of a Directory (Names Only)
string[] simpleDirectoryListing = ftpClient.directoryListDetailed("/etc");
for (int i = 0; i<simpleDirectoryListing.Count(); i++) { Console.WriteLine(simpleDirectoryListing[i]); }

// Get Contents of a Directory with Detailed File/Directory Info 
string[] detailDirectoryListing = ftpClient.directoryListDetailed("/etc");
for (int i = 0; i<detailDirectoryListing.Count(); i++) { Console.WriteLine(detailDirectoryListing[i]); }

// Release Resources
ftpClient = null;
-----------------------------------*/
