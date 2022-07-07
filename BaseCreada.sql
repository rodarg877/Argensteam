USE [master]
GO
/****** Object:  Database [Argensteam]    Script Date: 6/7/2022 22:10:30 ******/
CREATE DATABASE [Argensteam]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Argensteam', FILENAME = N'C:\Users\rodri\Argensteam.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Argensteam_log', FILENAME = N'C:\Users\rodri\Argensteam_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Argensteam] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Argensteam].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Argensteam] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Argensteam] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Argensteam] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Argensteam] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Argensteam] SET ARITHABORT OFF 
GO
ALTER DATABASE [Argensteam] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Argensteam] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Argensteam] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Argensteam] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Argensteam] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Argensteam] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Argensteam] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Argensteam] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Argensteam] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Argensteam] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Argensteam] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Argensteam] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Argensteam] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Argensteam] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Argensteam] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Argensteam] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Argensteam] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Argensteam] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Argensteam] SET  MULTI_USER 
GO
ALTER DATABASE [Argensteam] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Argensteam] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Argensteam] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Argensteam] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Argensteam] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Argensteam] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Argensteam] SET QUERY_STORE = OFF
GO
USE [Argensteam]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/7/2022 22:10:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Juegos]    Script Date: 6/7/2022 22:10:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Juegos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[urllVideo] [nvarchar](max) NULL,
	[Imagenes] [nvarchar](max) NULL,
	[Precio] [float] NOT NULL,
	[Categoria] [int] NULL,
 CONSTRAINT [PK_Juegos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Noticias]    Script Date: 6/7/2022 22:10:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Noticias](
	[NoticiaId] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
 CONSTRAINT [PK_Noticias] PRIMARY KEY CLUSTERED 
(
	[NoticiaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Soporte]    Script Date: 6/7/2022 22:10:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Soporte](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Mensaje] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Soporte] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioJuegos]    Script Date: 6/7/2022 22:10:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioJuegos](
	[UsuarioId] [int] NOT NULL,
	[JuegoId] [int] NOT NULL,
	[tipoLista] [nvarchar](1) NOT NULL,
 CONSTRAINT [PK_UsuarioJuegos] PRIMARY KEY CLUSTERED 
(
	[JuegoId] ASC,
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 6/7/2022 22:10:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FotoPerfil] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220609010723_Argensteam1.Context.ArgensteamDatabaseContext', N'5.0.17')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220609012918_Argensteam1', N'5.0.17')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220609015641_ModCat', N'5.0.17')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220615233751_clasesCompletas', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[Juegos] ON 
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (1, N'Overwatch', N'Overwatch es un videojuego de disparos en primera persona multijugador, desarrollado por Blizzard Entertainment. Fue lanzado al público el 24 de mayo del 2016, para las plataformas PlayStation 4, Xbox One y Microsoft Windows; posteriormente fue lanzado para Nintendo Switch', N'https://www.youtube.com/embed/yPy4IbvFR5Q', N'~/images/overwatch.jpg', 1500, 0)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (2, N'Witcher3', N'The Witcher 3: Wild Hunt es un videojuego de rol desarrollado y publicado por la compañía polaca CD Projekt RED. Esta compañía es la desarrolladora mientras que la distribución corre a cargo de la Warner Bros. Interactive, en el caso de Norteamérica y Bandai Namco para Europa', N'https://www.youtube.com/embed/6qpf3YWbCcE', N'~/images/witcher3.jpg', 1300, 1)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (3, N'Age of Empires 2', N'Age of Empires II: Definitive Edition es un videojuego de estrategia en tiempo real desarrollado por Forgotten Empires y publicado por Xbox Game Studios. Es una remasterización definitiva del juego original Age of Empires II: The Age of Kings, que celebra el vigésimo aniversario del original', N'https://www.youtube.com/embed/QGAh6IwahqE', N'~/images/age.jpg', 1300, 1)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (4, N'Need For Speed', N'Need for Speed es una franquicia de videojuegos de carreras publicada por Electronic Arts y actualmente desarrollada por Criterion Games.', N'https://www.youtube.com/embed/40IyEmCGdcs', N'~/images/nfs.jpg', 200, 2)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (5, N'World of Warcraft', N'World of Warcraft es un videojuego de rol multijugador masivo en línea desarrollado por Blizzard Entertainment. Es el cuarto juego lanzado establecido en el universo fantástico de Warcraft, el cual fue introducido por primera vez por Warcraft: Orcs & Humans en 1994', N'https://www.youtube.com/embed/pU0uaUkYus8', N'~/images/wow.jpg', 10, 1)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (6, N'League of legends', N'League of Legends es un videojuego del género multijugador de arena de batalla en línea y deporte electrónico el cual fue desarrollado por Riot Games para Microsoft Windows y OS X y para consolas digitales.', N'https://www.youtube.com/embed/0zzokQ7zpDM', N'~/images/lol.jpg', 0, 1)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (7, N'Elden Ring', N'Elden Ring es un videojuego de rol de acción desarrollado por FromSoftware y publicado por Bandai Namco Entertainment. El videojuego surge de una colaboración entre el director y diseñador Hidetaka Miyazaki y el novelista de fantasía George R. R. Martin. ', N'https://www.youtube.com/embed/CptaXqVY6-E', N'~/images/er.jpg', 1600, 0)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (8, N'GTA San Andreas', N'Grand Theft Auto: San Andreas es un videojuego de acción-aventura de mundo abierto desarrollado por Rockstar North y publicado por Rockstar Games.', N'https://www.youtube.com/embed/u_CbHrBbHNQ', N'~/images/gta.jpg', 400, 1)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (9, N'Turbo Golf Racing', N'Turbo Golf Racing se presenta como un trepidante juego de deporte estilo arcade con multijugador online para ocho usuarios donde se ha de pilotar coches turbopropulsados hasta el hoyo, hacer un putt y golpear una gigantesca bola en una apasionante carrera para llegar antes que los demás a metas. En otras palabras, su propuesta une Rocket League con una experiencia de minigolf.', N'https://www.youtube.com/embed/OCVwzMISEEM', N'~/images/tr.jpg', 2000, 2)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (10, N'OlliOlli World', N'OlliOlli World es un videojuego deportivo desarrollado por Roll7 y publicado por Private Division. Como el tercer juego de la serie OlliOlli, el juego se lanzó para Microsoft Windows, Nintendo Switch, PlayStation 4, PlayStation 5, Xbox One y Xbox Series X/S en febrero de 2022.', N'https://www.youtube.com/embed/ewYAHb7gE3c', N'~/images/olli.jpg', 2010, 2)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (11, N'Matchpoint - Tennis Championships', N'Matchpoint – Tennis Championships releases on July 7th 2022 for PlayStation®4|5, Xbox One, Xbox Series X|S, and PC, and is coming on day one to console, PC, and cloud with Xbox Game Pass. Learn more in the FAQ and play the free demo on Steam: Play the demo.', N'https://www.youtube.com/embed/-1ghTXhvcaQ', N'~/images/match.jpg', 1400, 2)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (12, N'FIFA 23: Ultimate Team', N'FIFA 23 - Ultimate Team permite un año más a los jugadores crear el equipo de sus sueños en la última entrega que llevará la marca FIFA. De momento hay pocos detalles sobre qué novedades incluirá esta exitosa propuesta de EA Sports, pero los jugadores pueden esperar un refinamiento de la fórmula que tantas horas de diversión les ha dado hasta la fecha.', N'https://www.youtube.com/embed/Udva8oBc0RM', N'~/images/fifa.jpg', 2400, 2)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (13, N'S.T.A.L.K.E.R. 2', N'STALKER 2 será un videojuego del género de disparos en primera persona ambientado en un futuro postapocalíptico, el cual se ambientará de nuevo en la Zona, un lugar inspirado en el área de exclusión de la central nuclear de Chernóbil, en la actual Ucrania.', N'https://www.youtube.com/embed/CtMFM_z3hRw', N'~/images/sta.jpg', 2300, 0)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (14, N'Tom Clancys Rainbow Six: Extraction', N'Tom Clancy''s Rainbow Six: Extraction es un videojuego de acción y primera persona del fabricante de videojuegos Ubisoft. Es una entrega de la saga Tom Clancy''s Rainbow Six. Su lanzamiento fue en enero del 2022. ', N'https://www.youtube.com/embed/K4rApF8_ND8', N'~/images/rain.jpg', 1750, 0)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (15, N'Horizon Forbidden West', N'Horizon Forbidden West es un videojuego de rol de acción, aventura y mundo abierto desarrollado por Guerrilla Games y distribuido por Sony Interactive Entertainment, exclusivamente para PlayStation 4 y PlayStation 5. Es la secuela de Horizon Zero Dawn.', N'https://www.youtube.com/embed/LbxCGWMUCnc', N'~/images/hr.jpg', 1550, 0)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (16, N'Dying Light 2', N'Nosotros encarnaremos, en primera persona, a Aiden Caldwell, que tiene poderes especiales por culpa del virus, y trata de encontrar a su hermana perdida. Nuestras decisiones a lo largo del juego no sólo alterarán la historia, sino que transforman el escenario. ', N'https://youtu.be/2MD4gTitmzw', N'~/images/dl.jpg', 1450, 3)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (17, N'Evil Dead The Game', N'La saga que en España conocimos como Posesión Infernal (original de Sam Raimi y remake de Fede Álvarez) vuelve a los videojuegos, y es una gran noticia. Saber Interactive (con estudio en España) recupera a Ash y a los principales personajes de la saga para un juego de terror y acción con componente multijugador.

Armados con la icónica motosierra y el palo de fuego (la escopeta de cartuchos recortada) tendremos que hacer frente a oleadas de demonios en modo cooperativo o contra un jugador que decida encarnar a las fuerzas de Kandarian. ', N'https://www.youtube.com/embed/ifQEyxmQ-WE', N'~/images/edg.jpg', 1450, 3)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (18, N'Ghostwire Tokyo', N'Tango Gameworks (el estudio de Shinji Mikami que pertenece a Microsoft) lanzará este juego de terror y acción en PS5 y PC el próximo 25 de marzo. Nos presenta una ciudad de Tokyo post apocalíptica, en que la mayor parte de la población ha desaparecido tras unos fenómenos paranormales.

Para hacer frente a las criaturas que vagan por los lugares más icónicos de la ciudad, nosotros podremos aliarnos con un ente espiritual y usar poderes especiales. Son ataques elementales vinculados con el fuego, el viento o el agua.', N'https://www.youtube.com/embed/rYfaC63jXhc', N'~/images/gw.jpg', 1650, 3)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (19, N'Dark Pictures Anthology: The Devil In Me', N'Siguiendo la saga Dark Pictures Anthology (que arrancó con Man of Medan y también nos ha ofrecido Little Hope y House of Ashes) el estudio británico Supermassive nos ofrece una nueva perspectiva del terror. 

En esta ocasión, como miembros de un equipo de rodaje, visitamos la réplica de un castillo en Estados Unidos en que se han producido numerosos asesinatos. Una "curiosidad" que esconde un peligroso secreto.', N'https://www.youtube.com/embed/lrrJQ4qcs5E', N'~/images/dinme.jpg', 1850, 3)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (20, N'Dead Space Remake', N'EA Motive (Star Wars Squadrons) se encuentra detrás de este proyecto, que los fans llevábamos esperando durante años. Dead Space toma como referencia todo el material original de Visceral Games, pero reformulando sus mecánicas y dando un lavado de cara a sus gráficos.

Volveremos a encarnar al ingeniero de la nave USG Ishimura Isaac Clarke, para embarcarnos en un viaje aterrador que desvele el origen de los necromorfos y también qué pasó con su mujer desaparecida. ', N'https://www.youtube.com/embed/Pp4m4xixEek', N'~/images/ds.jpg', 1850, 3)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (21, N'Oxenfree 2: Lost Signals', N'xenfree II: Lost Signals es un videojuego de aventuras de corte narrativo y una temática sobrenatural en el que una investigadora debe lidiar con una serie de sucesos fantasmagóricos. ', N'https://www.youtube.com/embed/LH8dYVPVxfM', N'~/images/oxe.jpg', 950, 4)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (22, N'Escape Academy', N'Escape Academy se presenta como uno de los primeros videojuegos capaces de capturar la experiencia verdaderamente alucinante de las escape rooms.', N'https://www.youtube.com/embed/RBX6LGc7AwQ', N'~/images/ea.jpg', 850, 4)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (23, N'Super Bomberman R 2', N'Super Bomberman 2 se presenta por Konami omo el siguiente capítulo de la historia de los Hermanos Bomberman en una nueva aventura para salvar la galaxia.', N'https://www.youtube.com/embed/c2brADq94ao', N'~/images/bomb.jpg', 850, 4)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (24, N'Lorelei and the Laser Eyes', N'Lorelei and the Laser Eyes es un videojuego de acción, aventura y puzles donde el jugador se encontrará con enigmas surrealistas y una historia espeluznante en un mundo dantesco. "El escenario está preparado. Imagina una antigua casa señorial barroca, tal vez un hotel o un museo, en algún lugar del Europa Central. Una mujer deambula en busca de respuestas".', N'https://www.youtube.com/embed/-O4Q33l05js', N'~/images/tle.jpg', 1050, 4)
GO
INSERT [dbo].[Juegos] ([Id], [Name], [Descripcion], [urllVideo], [Imagenes], [Precio], [Categoria]) VALUES (25, N'COCOON', N'COCOON busca ofrecer una genuina aventuras de rompecabezas, donde cada mundo existe dentro de un orbe que puede llevar a la espalda su protagonista.', N'https://www.youtube.com/embed/qMsPcrbRFSQ', N'~/images/co.jpg', 1450, 4)
GO
SET IDENTITY_INSERT [dbo].[Juegos] OFF
GO
SET IDENTITY_INSERT [dbo].[Noticias] ON 
GO
INSERT [dbo].[Noticias] ([NoticiaId], [Titulo], [Descripcion], [Url]) VALUES (1, N'Steam Summer Sale 2022: cuándo comienzan las ofertas y qué juegos tendrán descuentos', N'El evento en la plataforma de Valve ofrecerá enormes promociones y precios realmente para aprovechar en muchos videojuegos de PC.', N'https://www.tycsports.com/gaming/steam-summer-sale-2022-cuando-comienza-descuentos-horarios-id443608.html')
GO
INSERT [dbo].[Noticias] ([NoticiaId], [Titulo], [Descripcion], [Url]) VALUES (2, N'Los juegos rumoreados para PS Plus en julio 2022 que más están sonando en internet', N'Acabamos de pasar el ecuador del mes de junio, y yo solo pienso en dos cosas: lo primero es que odio el calor pero tengo muchas ganas de que llegue oficialmente el verano; no sabéis las ganas que tengo de ir a la playa, de piscina, de tener más tiempo libre, de salir por la noche a tomar algo... aunque no soy mucho de salir, pero da igual. Bueno, lo otro en lo que pienso es en los juegos de PS Plus de julio de 2022 y en el nuevo PlayStation Plus que va a llegar el 22 de este mes a Europa.', N'https://areajugones.sport.es/videojuegos/los-juegos-rumoreados-para-ps-plus-en-julio-2022-que-mas-estan-sonando-en-internet/')
GO
INSERT [dbo].[Noticias] ([NoticiaId], [Titulo], [Descripcion], [Url]) VALUES (3, N'Free Fire | Códigos de hoy 19 de junio de 2022; recompensas gratis', N'Os contamos cuáles son todos los códigos de recompensa gratis para Free Fire del día 19 de junio de 2022 para este battle royale en iOS y Android.', N'https://as.com/meristation/2022/06/19/noticias/1655632398_564139.html')
GO
SET IDENTITY_INSERT [dbo].[Noticias] OFF
GO
INSERT [dbo].[UsuarioJuegos] ([UsuarioId], [JuegoId], [tipoLista]) VALUES (10, 1, N'B')
GO
INSERT [dbo].[UsuarioJuegos] ([UsuarioId], [JuegoId], [tipoLista]) VALUES (10, 2, N'B')
GO
INSERT [dbo].[UsuarioJuegos] ([UsuarioId], [JuegoId], [tipoLista]) VALUES (10, 3, N'B')
GO
INSERT [dbo].[UsuarioJuegos] ([UsuarioId], [JuegoId], [tipoLista]) VALUES (10, 9, N'W')
GO
INSERT [dbo].[UsuarioJuegos] ([UsuarioId], [JuegoId], [tipoLista]) VALUES (13, 12, N'B')
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 
GO
INSERT [dbo].[Usuarios] ([UserId], [FotoPerfil], [Username], [Password], [Email]) VALUES (5, NULL, N'rod', N'rod', N'aldanaalmiron95@gmail.com')
GO
INSERT [dbo].[Usuarios] ([UserId], [FotoPerfil], [Username], [Password], [Email]) VALUES (6, NULL, N'rod', N'2e24', N'rodarg87@gmail.com')
GO
INSERT [dbo].[Usuarios] ([UserId], [FotoPerfil], [Username], [Password], [Email]) VALUES (7, NULL, N'rod', N'123', N'sd')
GO
INSERT [dbo].[Usuarios] ([UserId], [FotoPerfil], [Username], [Password], [Email]) VALUES (8, NULL, N're', NULL, NULL)
GO
INSERT [dbo].[Usuarios] ([UserId], [FotoPerfil], [Username], [Password], [Email]) VALUES (9, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Usuarios] ([UserId], [FotoPerfil], [Username], [Password], [Email]) VALUES (10, N'/images/avatar3.jpg', N'pepepepe', N'12345678', N'email@email.com')
GO
INSERT [dbo].[Usuarios] ([UserId], [FotoPerfil], [Username], [Password], [Email]) VALUES (11, NULL, N'pepepepe', N'12345678', N'rodarg87@gmail.com')
GO
INSERT [dbo].[Usuarios] ([UserId], [FotoPerfil], [Username], [Password], [Email]) VALUES (12, NULL, N'arturo', N'12345678', NULL)
GO
INSERT [dbo].[Usuarios] ([UserId], [FotoPerfil], [Username], [Password], [Email]) VALUES (13, N'/images/avatar4.jpg', N'aldana', N'12345', N'aldanaalmiron95@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
/****** Object:  Index [IX_UsuarioJuegos_UsuarioId]    Script Date: 6/7/2022 22:10:30 ******/
CREATE NONCLUSTERED INDEX [IX_UsuarioJuegos_UsuarioId] ON [dbo].[UsuarioJuegos]
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UsuarioJuegos]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioJuegos_Juegos_JuegoId] FOREIGN KEY([JuegoId])
REFERENCES [dbo].[Juegos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioJuegos] CHECK CONSTRAINT [FK_UsuarioJuegos_Juegos_JuegoId]
GO
ALTER TABLE [dbo].[UsuarioJuegos]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioJuegos_Usuarios_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioJuegos] CHECK CONSTRAINT [FK_UsuarioJuegos_Usuarios_UsuarioId]
GO
USE [master]
GO
ALTER DATABASE [Argensteam] SET  READ_WRITE 
GO
