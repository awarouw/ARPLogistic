-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE spFixedAssetEdit 
	-- Add the parameters for the stored procedure here
	@FixedAssetID int 
	, @No varchar(20) = ''
    , @Description varchar(30) = ''
    , @SearchDescription varchar(30) = ''
    , @Description2 varchar(30) = ''
    , @FAClassCode varchar(10) = ''
    , @FASubclassCode varchar(10) = ''
    , @GlobalDimension1Code varchar(20) = ''
    , @GlobalDimension2Code varchar(20) = ''
    , @LocationCode varchar(10) = ''
    , @FALocationCode varchar(10) = ''
    , @VendorNo varchar(20) = ''
    , @MainAssetComponent int = 0
    , @ComponentofMainAsset varchar(20) = ''
    , @BudgetedAsset tinyint = 0
    , @WarrantyDate datetime = null
    , @ResponsibleEmployee varchar(20) = ''
    , @SerialNo varchar(30) = ''
    , @Blocked tinyint = 0
    , @FileNamePicture varchar(100) = ''
    , @MaintenanceVendorNo varchar(20) = ''
    , @UnderMaintenance tinyint = 0
    , @NextServiceDate datetime = null
    , @NoSeries varchar(10) = ''
    , @FAPostingGroup varchar(10) = ''
    , @RowStatus smallint 
    , @CreatedBy varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @FixedAssetID > 0
	BEGIN
		UPDATE [dbo].[FixedAsset]
		   SET [No] = @No 
			  ,[Description] = @Description 
			  ,[SearchDescription] = @SearchDescription 
			  ,[Description2] = @Description2 
			  ,[FAClassCode] = @FAClassCode 
			  ,[FASubclassCode] = @FASubclassCode 
			  ,[GlobalDimension1Code] = @GlobalDimension1Code 
			  ,[GlobalDimension2Code] = @GlobalDimension2Code 
			  ,[LocationCode] = @LocationCode 
			  ,[FALocationCode] = @FALocationCode 
			  ,[VendorNo] = @VendorNo 
			  ,[MainAssetComponent] = @MainAssetComponent 
			  ,[ComponentofMainAsset] = @ComponentofMainAsset 
			  ,[BudgetedAsset] = @BudgetedAsset 
			  ,[WarrantyDate] = @WarrantyDate 
			  ,[ResponsibleEmployee] = @ResponsibleEmployee 
			  ,[SerialNo] = @SerialNo 
			  ,[Blocked] = @Blocked 
			  ,[FileNamePicture] = @FileNamePicture 
			  ,[MaintenanceVendorNo] = @MaintenanceVendorNo 
			  ,[UnderMaintenance] = @UnderMaintenance 
			  ,[NextServiceDate] = @NextServiceDate 
			  ,[NoSeries] = @NoSeries 
			  ,[FAPostingGroup] = @FAPostingGroup 
			  ,[RowStatus] = @RowStatus 
			  ,[LastModifiedBy] = @CreatedBy
			  ,[LastModifiedTime] = GetDate()
		WHERE FixedAssetID = @FixedAssetID

	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[FixedAsset]
				   ([No]
				   ,[Description]
				   ,[SearchDescription]
				   ,[Description2]
				   ,[FAClassCode]
				   ,[FASubclassCode]
				   ,[GlobalDimension1Code]
				   ,[GlobalDimension2Code]
				   ,[LocationCode]
				   ,[FALocationCode]
				   ,[VendorNo]
				   ,[MainAssetComponent]
				   ,[ComponentofMainAsset]
				   ,[BudgetedAsset]
				   ,[WarrantyDate]
				   ,[ResponsibleEmployee]
				   ,[SerialNo]
				   ,[Blocked]
				   ,[FileNamePicture]
				   ,[MaintenanceVendorNo]
				   ,[UnderMaintenance]
				   ,[NextServiceDate]
				   ,[NoSeries]
				   ,[FAPostingGroup]
				   ,[RowStatus]
				   ,[CreatedBy]
				   ,[CreatedTime] )
			 VALUES
				   ( @No 
				   , @Description 
				   , @SearchDescription 
				   , @Description2 
				   , @FAClassCode 
				   , @FASubclassCode 
				   , @GlobalDimension1Code 
				   , @GlobalDimension2Code 
				   , @LocationCode 
				   , @FALocationCode 
				   , @VendorNo 
				   , @MainAssetComponent 
				   , @ComponentofMainAsset 
				   , @BudgetedAsset 
				   , @WarrantyDate 
				   , @ResponsibleEmployee 
				   , @SerialNo 
				   , @Blocked 
				   , @FileNamePicture 
				   , @MaintenanceVendorNo 
				   , @UnderMaintenance 
				   , @NextServiceDate 
				   , @NoSeries 
				   , @FAPostingGroup 
				   , @RowStatus 
				   , @CreatedBy 
				   , GetDate() )

		SELECT @FixedAssetID = @@IDENTITY
	END

	SELECT @FixedAssetID

END
GO
