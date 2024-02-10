GO
CREATE DATABASE [dbbase_SelvinMedina]
GO
USE [dbbase_SelvinMedina]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 25/01/2024 09:41:29 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[PermissionId] [int] IDENTITY(1,1) NOT NULL,
	[Path] [varchar](100) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[FatherId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[Icon] [varchar](100) NOT NULL,
	[TypeId] [int] NOT NULL,
	[Position] [int] NOT NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermission]    Script Date: 25/01/2024 09:41:29 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermission](
	[RolePermissionId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[PermissionId] [int] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_RolePermission] PRIMARY KEY CLUSTERED 
(
	[RolePermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Theme]    Script Date: 25/01/2024 09:41:29 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Theme](
	[ThemeId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](80) NOT NULL,
	[Description] [varchar](200) NOT NULL,
	[Active] [bit] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Theme] PRIMARY KEY CLUSTERED 
(
	[ThemeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypePermission]    Script Date: 25/01/2024 09:41:29 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypePermission](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TypePermission] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 25/01/2024 09:41:29 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](120) NOT NULL,
	[UserName] [varchar](22) NOT NULL,
	[Password] [varchar](500) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[Active] [bit] NOT NULL,
	[RoleId] [int] NOT NULL,
	[ThemeId] [int] NOT NULL,
	[WhsCode] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRol]    Script Date: 25/01/2024 09:41:29 A.M. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRol](
	[RolId] [int] IDENTITY(1,1) NOT NULL,
	[RolName] [varchar](255) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_ROL] PRIMARY KEY CLUSTERED 
(
	[RolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Permission] ON 

INSERT [dbo].[Permission] ([PermissionId], [Path], [Description], [FatherId], [Active], [Icon], [TypeId], [Position]) VALUES (1, N'/', N'Inicio', 0, 1, N'pi pi-fw pi-home', 1, 1)
INSERT [dbo].[Permission] ([PermissionId], [Path], [Description], [FatherId], [Active], [Icon], [TypeId], [Position]) VALUES (2, N'/', N'Configuracion', 0, 1, N'pi pi-fw pi-cog', 1, 1)
INSERT [dbo].[Permission] ([PermissionId], [Path], [Description], [FatherId], [Active], [Icon], [TypeId], [Position]) VALUES (3, N'/', N'Dashboard', 1, 1, N'pi pi-fw pi-chart-bar', 1, 1)
INSERT [dbo].[Permission] ([PermissionId], [Path], [Description], [FatherId], [Active], [Icon], [TypeId], [Position]) VALUES (4, N'/usuarios', N'Lista de Usuarios', 2, 1, N'pi pi-fw pi-users', 1, 7)
INSERT [dbo].[Permission] ([PermissionId], [Path], [Description], [FatherId], [Active], [Icon], [TypeId], [Position]) VALUES (5, N'btn_add_user', N'Boton agregar usuario', 4, 1, N'pi pi-fw pi-plus-circle', 2, 1)
INSERT [dbo].[Permission] ([PermissionId], [Path], [Description], [FatherId], [Active], [Icon], [TypeId], [Position]) VALUES (6, N'btn_edit_user', N'Boton editar usuario', 4, 1, N'pi pi-fw pi-pencil', 2, 1)
INSERT [dbo].[Permission] ([PermissionId], [Path], [Description], [FatherId], [Active], [Icon], [TypeId], [Position]) VALUES (7, N'/roles', N'Listado de roles', 2, 1, N'pi pi-fw pi-user-edit', 1, 7)
INSERT [dbo].[Permission] ([PermissionId], [Path], [Description], [FatherId], [Active], [Icon], [TypeId], [Position]) VALUES (8, N'btn_add_role', N'Boton agregar rol', 7, 1, N'pi pi-fw pi-plus-circle', 2, 1)
INSERT [dbo].[Permission] ([PermissionId], [Path], [Description], [FatherId], [Active], [Icon], [TypeId], [Position]) VALUES (9, N'btn_edit_role', N'Boton edit rol', 7, 1, N'pi pi-fw pi-pencil', 2, 1)
INSERT [dbo].[Permission] ([PermissionId], [Path], [Description], [FatherId], [Active], [Icon], [TypeId], [Position]) VALUES (10, N'/permisos', N'Listado de objetos', 2, 1, N'pi pi-fw pi-briefcase', 1, 8)
INSERT [dbo].[Permission] ([PermissionId], [Path], [Description], [FatherId], [Active], [Icon], [TypeId], [Position]) VALUES (11, N'btn_add_permission', N'Boton agregar permiso', 10, 1, N'pi pi-fw pi-plus-circle', 2, 1)
INSERT [dbo].[Permission] ([PermissionId], [Path], [Description], [FatherId], [Active], [Icon], [TypeId], [Position]) VALUES (12, N'btn_edit_permission', N'Boton editar permiso', 10, 1, N'pi pi-fw pi-pencil', 2, 1)
SET IDENTITY_INSERT [dbo].[Permission] OFF
GO
SET IDENTITY_INSERT [dbo].[RolePermission] ON 

INSERT [dbo].[RolePermission] ([RolePermissionId], [RoleId], [PermissionId], [Active]) VALUES (1, 1, 1, 1)
INSERT [dbo].[RolePermission] ([RolePermissionId], [RoleId], [PermissionId], [Active]) VALUES (2, 1, 2, 1)
INSERT [dbo].[RolePermission] ([RolePermissionId], [RoleId], [PermissionId], [Active]) VALUES (3, 1, 3, 1)
INSERT [dbo].[RolePermission] ([RolePermissionId], [RoleId], [PermissionId], [Active]) VALUES (4, 1, 4, 1)
INSERT [dbo].[RolePermission] ([RolePermissionId], [RoleId], [PermissionId], [Active]) VALUES (5, 1, 5, 1)
INSERT [dbo].[RolePermission] ([RolePermissionId], [RoleId], [PermissionId], [Active]) VALUES (6, 1, 6, 1)
INSERT [dbo].[RolePermission] ([RolePermissionId], [RoleId], [PermissionId], [Active]) VALUES (7, 1, 7, 1)
INSERT [dbo].[RolePermission] ([RolePermissionId], [RoleId], [PermissionId], [Active]) VALUES (8, 1, 8, 1)
INSERT [dbo].[RolePermission] ([RolePermissionId], [RoleId], [PermissionId], [Active]) VALUES (9, 1, 9, 1)
INSERT [dbo].[RolePermission] ([RolePermissionId], [RoleId], [PermissionId], [Active]) VALUES (10, 1, 10, 1)
INSERT [dbo].[RolePermission] ([RolePermissionId], [RoleId], [PermissionId], [Active]) VALUES (11, 1, 11, 1)
INSERT [dbo].[RolePermission] ([RolePermissionId], [RoleId], [PermissionId], [Active]) VALUES (12, 1, 12, 1)
SET IDENTITY_INSERT [dbo].[RolePermission] OFF
GO
SET IDENTITY_INSERT [dbo].[Theme] ON 

INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (2, N'mdc-light-indigo', N'MDC Indigo Light', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (4, N'lara-light-indigo', N'Lara Indigo Light', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (5, N'bootstrap4-light-blue', N'Bootstrap4 Light Blue', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (6, N'tailwind-light', N'Tailwind Light', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (7, N'lara-dark-teal', N'Lara Dark Teal', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (8, N'fluent-light', N'Fluent Light', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (9, N'arya-blue', N'arya-blue', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (10, N'arya-green', N'arya-green', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (11, N'arya-orange', N'arya-orange', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (12, N'arya-purple', N'arya-purple', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (13, N'bootstrap4-dark-blue', N'bootstrap4-dark-blue', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (14, N'bootstrap4-dark-purple', N'bootstrap4-dark-purple', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (15, N'bootstrap4-light-purple', N'bootstrap4-light-purple', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (16, N'lara-dark-blue', N'lara-dark-blue', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (17, N'lara-dark-indigo', N'lara-dark-indigo', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (18, N'lara-dark-purple', N'lara-dark-purple', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (19, N'lara-light-blue', N'lara-light-blue', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (20, N'lara-light-purple', N'lara-light-purple', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (21, N'lara-light-teal', N'lara-light-teal', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (22, N'mdc-dark-deeppurple', N'mdc-dark-deeppurple', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (23, N'mdc-dark-indigo', N'mdc-dark-indigo', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (24, N'mdc-light-deeppurple', N'mdc-light-deeppurple', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (25, N'md-dark-deeppurple', N'md-dark-deeppurple', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (26, N'md-dark-indigo', N'md-dark-indigo', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (27, N'md-light-deeppurple', N'md-light-deeppurple', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (28, N'md-light-indigo', N'md-light-indigo', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (29, N'saga-blue', N'saga-blue', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (30, N'saga-green', N'saga-green', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (31, N'saga-orange', N'saga-orange', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (32, N'saga-purple', N'saga-purple', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (33, N'vela-blue', N'vela-blue', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (34, N'vela-green', N'vela-green', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (35, N'vela-orange', N'vela-orange', 1, 1)
INSERT [dbo].[Theme] ([ThemeId], [Code], [Description], [Active], [UserId]) VALUES (36, N'vela-purple', N'vela-purple', 1, 1)
SET IDENTITY_INSERT [dbo].[Theme] OFF
GO
SET IDENTITY_INSERT [dbo].[TypePermission] ON 

INSERT [dbo].[TypePermission] ([TypeId], [Description]) VALUES (1, N'Pantalla')
INSERT [dbo].[TypePermission] ([TypeId], [Description]) VALUES (2, N'Boton')
SET IDENTITY_INSERT [dbo].[TypePermission] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Name], [UserName], [Password], [Email], [Active], [RoleId], [ThemeId], [WhsCode]) VALUES (1, N'Administrador', N'admin', N'CtXimlKRoVlYbfweQUxw0Q==', N'admin@admin.com', 1, 1, 29, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRol] ON 

INSERT [dbo].[UserRol] ([RolId], [RolName], [Active]) VALUES (1, N'Administrador', 1)
SET IDENTITY_INSERT [dbo].[UserRol] OFF
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT ((1)) FOR [WhsCode]
GO
ALTER TABLE [dbo].[UserRol] ADD  CONSTRAINT [DF__UserRol__Active__05D8E0BE]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_TypePermission] FOREIGN KEY([TypeId])
REFERENCES [dbo].[TypePermission] ([TypeId])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_TypePermission]
GO
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission_Permission] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([PermissionId])
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission_Permission]
GO
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[UserRol] ([RolId])
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission_Role]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Theme] FOREIGN KEY([ThemeId])
REFERENCES [dbo].[Theme] ([ThemeId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Theme]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserRol] FOREIGN KEY([RoleId])
REFERENCES [dbo].[UserRol] ([RolId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserRol]
GO

-- 
GO
CREATE TABLE Document(
Id				INT IDENTITY(1,1),
CreateBy		INT,
CreatebyDate	DATETIME,
UpdateBy		INT,
UpdateDate		DATETIME

CONSTRAINT Pk_TbPrueba_Id PRIMARY KEY(Id),
CONSTRAINT [Fk.tbprueba.CreateBy -> dbo.User.Id] FOREIGN KEY (CreateBy) REFERENCES [dbo].[User]([UserId]),
CONSTRAINT [Fk.tbprueba.UpdateBy -> dbo.User.Id] FOREIGN KEY (UpdateBy) REFERENCES [dbo].[User]([UserId])

);

 
INSERT INTO [dbo].Document
           ([CreateBy]
           ,[CreatebyDate]
           ,[UpdateBy]
           ,[UpdateDate])
     VALUES
           (1
           ,GETDATE()
           ,1
           ,GETDATE())
GO

