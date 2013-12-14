--stored procedures

/****** Object:  StoredProcedure [dbo].[usp_GetCalledAPI]    Script Date: 12/13/2013 01:42:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetCalledAPI]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_GetCalledAPI]
GO


/****** Object:  StoredProcedure [dbo].[usp_GetCalledAPI]    Script Date: 12/13/2013 01:42:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC	[dbo].[usp_GetCalledAPI]
AS 
BEGIN
	SELECT  ID,dtAgg,StringIn,StringCode,KeyCode FROM dbo.CalledAPI
END
GO


/****** Object:  StoredProcedure [dbo].[usp_CreateCalledAPI]    Script Date: 12/13/2013 01:42:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_CreateCalledAPI]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[usp_CreateCalledAPI]
GO

/****** Object:  StoredProcedure [dbo].[usp_CreateCalledAPI]    Script Date: 12/13/2013 01:42:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC	[dbo].[usp_CreateCalledAPI]

@StringIn nvarchar(50),
@StringCode nvarchar(50),
@KeyCode nvarchar(50)
AS 
BEGIN
	INSERT INTO dbo.CalledAPI
        ( dtAgg ,
          StringIn ,
          StringCode ,
          KeyCode
        )
VALUES  (	GETDATE(),
			@StringIn,
			@StringCode,
			@KeyCode
        )
END
GO


--Tables

/****** Object:  Table [dbo].[CalledAPI]    Script Date: 12/13/2013 01:42:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CalledAPI]') AND type in (N'U'))
DROP TABLE [dbo].[CalledAPI]
GO

/****** Object:  Table [dbo].[CalledAPI]    Script Date: 12/13/2013 01:42:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalledAPI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[dtAgg] [datetime] NULL,
	[StringIn] [nvarchar](50) NULL,
	[StringCode] [nvarchar](50) NULL,
	[KeyCode] [nvarchar](50) NULL,
 CONSTRAINT [PK_Test_CalledAPI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


