SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([Type], [Name], [Email], [Password], [CPF]) VALUES (1, N'string', N'string', N'string', N'string')
INSERT INTO [dbo].[Users] ([Type], [Name], [Email], [Password], [CPF]) VALUES (2, N'Marcos', N'mplbruno@cursos.com', N'1234', N'12345678901')
SET IDENTITY_INSERT [dbo].[Users] OFF
