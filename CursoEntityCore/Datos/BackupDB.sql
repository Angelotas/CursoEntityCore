
CREATE DATABASE DbEntityCore;

-- DROP SCHEMA dbo;

CREATE SCHEMA dbo;
-- DbEntityCore.dbo.Categoria definition

-- Drop table

-- DROP TABLE DbEntityCore.dbo.Categoria;

CREATE TABLE DbEntityCore.dbo.Categoria (
	Id int IDENTITY(1,1) NOT NULL,
	Name nvarchar COLLATE Modern_Spanish_CI_AS NOT NULL,
	Activo bit DEFAULT CONVERT([bit],(0)) NOT NULL,
	FechaCreacion datetime2 DEFAULT '0001-01-01T00:00:00.0000000' NOT NULL,
	CONSTRAINT PK_Categoria PRIMARY KEY (Id)
);


-- DbEntityCore.dbo.DetalleUsuario definition

-- Drop table

-- DROP TABLE DbEntityCore.dbo.DetalleUsuario;

CREATE TABLE DbEntityCore.dbo.DetalleUsuario (
	DetalleUsuarioId int IDENTITY(1,1) NOT NULL,
	Cedula nvarchar COLLATE Modern_Spanish_CI_AS NOT NULL,
	Deporte nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Mascota nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	CONSTRAINT PK_DetalleUsuario PRIMARY KEY (DetalleUsuarioId)
);


-- DbEntityCore.dbo.Etiqueta definition

-- Drop table

-- DROP TABLE DbEntityCore.dbo.Etiqueta;

CREATE TABLE DbEntityCore.dbo.Etiqueta (
	Etiqueta_Id int IDENTITY(1,1) NOT NULL,
	Titulo nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Fecha datetime2 NOT NULL,
	CONSTRAINT PK_Etiqueta PRIMARY KEY (Etiqueta_Id)
);


-- DbEntityCore.dbo.[__EFMigrationsHistory] definition

-- Drop table

-- DROP TABLE DbEntityCore.dbo.[__EFMigrationsHistory];

CREATE TABLE DbEntityCore.dbo.[__EFMigrationsHistory] (
	MigrationId nvarchar(150) COLLATE Modern_Spanish_CI_AS NOT NULL,
	ProductVersion nvarchar(32) COLLATE Modern_Spanish_CI_AS NOT NULL,
	CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY (MigrationId)
);


-- DbEntityCore.dbo.sysdiagrams definition

-- Drop table

-- DROP TABLE DbEntityCore.dbo.sysdiagrams;

CREATE TABLE DbEntityCore.dbo.sysdiagrams (
	name sysname COLLATE Modern_Spanish_CI_AS NOT NULL,
	principal_id int NOT NULL,
	diagram_id int IDENTITY(1,1) NOT NULL,
	version int NULL,
	definition varbinary(MAX) NULL,
	CONSTRAINT PK__sysdiagr__C2B05B61D033A26F PRIMARY KEY (diagram_id),
	CONSTRAINT UK_principal_name UNIQUE (principal_id,name)
);
CREATE UNIQUE NONCLUSTERED INDEX UK_principal_name ON DbEntityCore.dbo.sysdiagrams (principal_id, name);


-- DbEntityCore.dbo.Article definition

-- Drop table

-- DROP TABLE DbEntityCore.dbo.Article;

CREATE TABLE DbEntityCore.dbo.Article (
	Articulo_Id int IDENTITY(1,1) NOT NULL,
	Titulo nvarchar(50) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Descripcion nvarchar(500) COLLATE Modern_Spanish_CI_AS NOT NULL,
	Fecha nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Calificacion float DEFAULT 0.0000000000000000e+000 NOT NULL,
	Categoria_Id int DEFAULT 0 NOT NULL,
	CONSTRAINT PK_Article PRIMARY KEY (Articulo_Id),
	CONSTRAINT FK_Article_Categoria_Categoria_Id FOREIGN KEY (Categoria_Id) REFERENCES DbEntityCore.dbo.Categoria(Id) ON DELETE CASCADE
);
 CREATE NONCLUSTERED INDEX IX_Article_Categoria_Id ON dbo.Article (  Categoria_Id ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- DbEntityCore.dbo.ArticuloEtiqueta definition

-- Drop table

-- DROP TABLE DbEntityCore.dbo.ArticuloEtiqueta;

CREATE TABLE DbEntityCore.dbo.ArticuloEtiqueta (
	Articulo_Id int NOT NULL,
	EtiquetaId int NOT NULL,
	CONSTRAINT PK_ArticuloEtiqueta PRIMARY KEY (EtiquetaId,Articulo_Id),
	CONSTRAINT FK_ArticuloEtiqueta_Article_Articulo_Id FOREIGN KEY (Articulo_Id) REFERENCES DbEntityCore.dbo.Article(Articulo_Id) ON DELETE CASCADE,
	CONSTRAINT FK_ArticuloEtiqueta_Etiqueta_EtiquetaId FOREIGN KEY (EtiquetaId) REFERENCES DbEntityCore.dbo.Etiqueta(Etiqueta_Id) ON DELETE CASCADE
);
 CREATE NONCLUSTERED INDEX IX_ArticuloEtiqueta_Articulo_Id ON dbo.ArticuloEtiqueta (  Articulo_Id ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- DbEntityCore.dbo.Usuario definition

-- Drop table

-- DROP TABLE DbEntityCore.dbo.Usuario;

CREATE TABLE DbEntityCore.dbo.Usuario (
	Id int IDENTITY(1,1) NOT NULL,
	Nombre nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	Email nvarchar COLLATE Modern_Spanish_CI_AS NULL,
	DetalleUsuarioId int NULL,
	CONSTRAINT PK_Usuario PRIMARY KEY (Id),
	CONSTRAINT FK_Usuario_DetalleUsuario_DetalleUsuarioId FOREIGN KEY (DetalleUsuarioId) REFERENCES DbEntityCore.dbo.DetalleUsuario(DetalleUsuarioId)
);
 CREATE  UNIQUE NONCLUSTERED INDEX IX_Usuario_DetalleUsuarioId ON dbo.Usuario (  DetalleUsuarioId ASC  )  
	 WHERE  ([DetalleUsuarioId] IS NOT NULL)
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
