USE [ARPLogistic]
GO

alter table [dbo].[TransferRoute]
add JarakTempuh dec(18,5) default 0
, BiayaToll dec(18,5) default 0
, BiayaBBM dec(18,5) default 0
, Retribusi dec(18,5) default 0
, BiayaLainLain dec(18,5) default 0
