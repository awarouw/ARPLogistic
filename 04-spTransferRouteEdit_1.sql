USE [ARPLogistic]
GO
/****** Object:  StoredProcedure [dbo].[spTransferRouteEdit]    Script Date: 12/21/2020 10:04:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spTransferRouteEdit]
	-- Add the parameters for the stored procedure here
	@TransferRouteID int = 0
	, @TransferfromCode varchar(10) = ''
	, @TransfertoCode varchar(10) = ''
	, @InTransitCode varchar(10) = ''
	, @ShippingAgentCode varchar(10) = ''
	, @ShippingAgentServiceCode varchar(10) = ''
	, @JarakTempuh dec(18,5) = 0
	, @BiayaToll dec(18,5) = 0
	, @BiayaBBM dec(18,5) = 0
	, @Retribusi dec(18,5) = 0
	, @BiayaLainLain dec(18,5) = 0
	, @RowStatus smallint 
	, @CreatedBy varchar(50) 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @TransferRouteID > 0
	BEGIN
		UPDATE [dbo].[TransferRoute]
		   SET  [TransferfromCode] = @TransferfromCode 
			  , [TransfertoCode] = @TransfertoCode 
			  , [InTransitCode] = @InTransitCode 
			  , [ShippingAgentCode] = @ShippingAgentCode 
			  , [ShippingAgentServiceCode] = @ShippingAgentServiceCode 
			  , [JarakTempuh] = @JarakTempuh  
			  , [BiayaToll] = @BiayaToll  
			  , [BiayaBBM] = @BiayaBBM  
			  , [Retribusi] = @Retribusi  
			  , [BiayaLainLain] = @BiayaLainLain  
			  , [RowStatus] = @RowStatus 
			  , [LastModifiedBy] = @CreatedBy
			  , [LastModifiedTime] = GetDate()

		WHERE TransferRouteID = @TransferRouteID

	END
	ELSE
	BEGIN
		INSERT INTO [dbo].[TransferRoute]
			( [TransferfromCode]
			, [TransfertoCode]
			, [InTransitCode]
			, [ShippingAgentCode]
			, [ShippingAgentServiceCode]
			, [JarakTempuh]
			, [BiayaToll]
			, [BiayaBBM]
			, [Retribusi]
			, [BiayaLainLain]
			, [RowStatus]
			, [CreatedBy]
			, [CreatedTime] )
		VALUES
			( @TransferfromCode 
			, @TransfertoCode 
			, @InTransitCode 
			, @ShippingAgentCode 
			, @ShippingAgentServiceCode 
			, @JarakTempuh  
			, @BiayaToll  
			, @BiayaBBM  
			, @Retribusi 
			, @BiayaLainLain 
			, @RowStatus 
			, @CreatedBy 
			, GetDate()  )
		Set @TransferRouteID = @@Identity

	END

	SELECT @TransferRouteID
END
