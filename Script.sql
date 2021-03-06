SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SequenceElements](
	[RunNumber] [int] NOT NULL,
	[Element] [bigint] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sequences](
	[RunNumber] [int] IDENTITY(1,1) NOT NULL,
	[SequenceType] [tinyint] NOT NULL,
 CONSTRAINT [PK_Sequences] PRIMARY KEY CLUSTERED 
(
	[RunNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE CLUSTERED INDEX [idx_RunNumber_Element] ON [dbo].[SequenceElements]
(
	[RunNumber] ASC,
	[Element] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SequenceElements]  WITH CHECK ADD  CONSTRAINT [FK_SequenceElements_Sequences] FOREIGN KEY([RunNumber])
REFERENCES [dbo].[Sequences] ([RunNumber])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SequenceElements] CHECK CONSTRAINT [FK_SequenceElements_Sequences]
GO
USE [master]
GO
ALTER DATABASE [Sequences] SET  READ_WRITE 
GO
