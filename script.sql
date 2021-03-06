USE [master]
GO
/****** Object:  Database [HastaneProje]    Script Date: 20.01.2022 14:43:31 ******/
CREATE DATABASE [HastaneProje]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HastaneProje', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HastaneProje.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HastaneProje_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\HastaneProje_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [HastaneProje] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HastaneProje].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HastaneProje] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HastaneProje] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HastaneProje] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HastaneProje] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HastaneProje] SET ARITHABORT OFF 
GO
ALTER DATABASE [HastaneProje] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HastaneProje] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HastaneProje] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HastaneProje] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HastaneProje] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HastaneProje] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HastaneProje] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HastaneProje] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HastaneProje] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HastaneProje] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HastaneProje] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HastaneProje] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HastaneProje] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HastaneProje] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HastaneProje] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HastaneProje] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HastaneProje] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HastaneProje] SET RECOVERY FULL 
GO
ALTER DATABASE [HastaneProje] SET  MULTI_USER 
GO
ALTER DATABASE [HastaneProje] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HastaneProje] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HastaneProje] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HastaneProje] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HastaneProje] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HastaneProje] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HastaneProje', N'ON'
GO
ALTER DATABASE [HastaneProje] SET QUERY_STORE = OFF
GO
USE [HastaneProje]
GO
/****** Object:  Table [dbo].[Doktorlar]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doktorlar](
	[DoktorNo] [int] IDENTITY(1,1) NOT NULL,
	[DoktorAdSoyad] [varchar](50) NULL,
	[Tc] [char](11) NULL,
	[UzmanlikAlani] [varchar](50) NULL,
	[Unvan] [varchar](50) NULL,
	[Telefon] [char](15) NULL,
	[Adres] [varchar](50) NULL,
	[DogumTarihi] [varchar](50) NULL,
	[PolNo] [int] NULL,
 CONSTRAINT [PK_Doktorlar] PRIMARY KEY CLUSTERED 
(
	[DoktorNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hastalar]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hastalar](
	[HastaNo] [int] IDENTITY(1,1) NOT NULL,
	[HastaAdSoyad] [varchar](50) NULL,
	[TcNo] [char](11) NULL,
	[DogumTarihi] [varchar](50) NULL,
	[Boy] [int] NULL,
	[Yas] [int] NULL,
	[Recete] [varchar](50) NULL,
	[RaporDurumu] [varchar](50) NULL,
	[RandevuTarih] [varchar](50) NULL,
	[DoktorNo] [int] NULL,
 CONSTRAINT [PK_Hastalar] PRIMARY KEY CLUSTERED 
(
	[HastaNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[KullaniciNo] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAd] [varchar](50) NULL,
	[Sifre] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[TelefonNo] [char](20) NULL,
 CONSTRAINT [PK_Kullanicilar] PRIMARY KEY CLUSTERED 
(
	[KullaniciNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Polikinilikler]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Polikinilikler](
	[PolNo] [int] IDENTITY(1,1) NOT NULL,
	[PolAdi] [varchar](50) NULL,
	[PolUzmanSayisi] [int] NULL,
	[PolBaskan] [varchar](50) NULL,
	[PolBasHekim] [varchar](50) NULL,
	[YatakSayisi] [int] NULL,
 CONSTRAINT [PK_Polikinilikler,] PRIMARY KEY CLUSTERED 
(
	[PolNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Doktorlar] ON 

INSERT [dbo].[Doktorlar] ([DoktorNo], [DoktorAdSoyad], [Tc], [UzmanlikAlani], [Unvan], [Telefon], [Adres], [DogumTarihi], [PolNo]) VALUES (1, N'3242', N'3242       ', N'asd', NULL, N'asd            ', N'sadaj', N'20 Ocak 2022 Perşembe', 2)
INSERT [dbo].[Doktorlar] ([DoktorNo], [DoktorAdSoyad], [Tc], [UzmanlikAlani], [Unvan], [Telefon], [Adres], [DogumTarihi], [PolNo]) VALUES (2, N'3242', N'3242       ', N'asd', N'as', N'asd            ', N'sadaj', N'20 Ocak 2022 Perşembe', 3)
SET IDENTITY_INSERT [dbo].[Doktorlar] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanicilar] ON 

INSERT [dbo].[Kullanicilar] ([KullaniciNo], [KullaniciAd], [Sifre], [Email], [TelefonNo]) VALUES (1, N'admin', N'1234', N'asdja@gmail.com', N'23423423            ')
SET IDENTITY_INSERT [dbo].[Kullanicilar] OFF
GO
SET IDENTITY_INSERT [dbo].[Polikinilikler] ON 

INSERT [dbo].[Polikinilikler] ([PolNo], [PolAdi], [PolUzmanSayisi], [PolBaskan], [PolBasHekim], [YatakSayisi]) VALUES (1, N'Dahiliye', 5, N'Muzaffer', N'Mustafa', 7)
INSERT [dbo].[Polikinilikler] ([PolNo], [PolAdi], [PolUzmanSayisi], [PolBaskan], [PolBasHekim], [YatakSayisi]) VALUES (2, N'Kardiyoloji', 7, N'Ender', N'Özge', 15)
INSERT [dbo].[Polikinilikler] ([PolNo], [PolAdi], [PolUzmanSayisi], [PolBaskan], [PolBasHekim], [YatakSayisi]) VALUES (3, N'Kulak Burun Boğaz', 4, N'Hakan', N'Yaren', 50)
SET IDENTITY_INSERT [dbo].[Polikinilikler] OFF
GO
ALTER TABLE [dbo].[Doktorlar]  WITH CHECK ADD  CONSTRAINT [FK_Doktorlar_Polikinilikler] FOREIGN KEY([PolNo])
REFERENCES [dbo].[Polikinilikler] ([PolNo])
GO
ALTER TABLE [dbo].[Doktorlar] CHECK CONSTRAINT [FK_Doktorlar_Polikinilikler]
GO
ALTER TABLE [dbo].[Hastalar]  WITH CHECK ADD  CONSTRAINT [FK_Hastalar_Doktorlar] FOREIGN KEY([DoktorNo])
REFERENCES [dbo].[Doktorlar] ([DoktorNo])
GO
ALTER TABLE [dbo].[Hastalar] CHECK CONSTRAINT [FK_Hastalar_Doktorlar]
GO
/****** Object:  StoredProcedure [dbo].[DoktorEkle]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DoktorEkle]
@DoktorAdiSoyad varchar(50),
@TcNo char(11),
@UzmanlikAlani varchar(50),
@Unvan varchar(50),
@Telefon char(15),
@Adres varchar(50),
@DogumTarihi varchar(50),
@PolNo int 
as begin
insert into Doktorlar(DoktorAdSoyad,Tc,UzmanlikAlani,Unvan,Telefon,Adres,DogumTarihi,PolNo)
values(@DoktorAdiSoyad,@TcNo,@UzmanlikAlani,@Unvan,@Telefon,@Adres,@DogumTarihi,@PolNo)
end
GO
/****** Object:  StoredProcedure [dbo].[DoktorGuncelleme]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DoktorGuncelleme]
@DoktorNo int,
@DoktorAdiSoyad varchar(50),
@TcNo char(11),
@UzmanlikAlani varchar(50),
@Unvan varchar(50),
@Telefon char(15),
@Adres varchar(50),
@DogumTarihi varchar(50),
@PolNo int 
as begin
update Doktorlar set DoktorAdSoyad=@DoktorAdiSoyad,Tc=@TcNo,UzmanlikAlani=@UzmanlikAlani,Unvan=@Unvan,Telefon=@Telefon,Adres=@Adres,DogumTarihi=@DogumTarihi,PolNo= @PolNo where DoktorNo=@DoktorNo
end
GO
/****** Object:  StoredProcedure [dbo].[DoktorListele]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DoktorListele]
as begin
select * from Doktorlar 
end
GO
/****** Object:  StoredProcedure [dbo].[DoktorListeleAZ]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DoktorListeleAZ]
as begin
select * from Doktorlar order by DoktorAdSoyad 
end
GO
/****** Object:  StoredProcedure [dbo].[DoktorListeleZA]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DoktorListeleZA]
as begin
select * from Doktorlar order by DoktorAdSoyad desc
end
GO
/****** Object:  StoredProcedure [dbo].[DoktorSil]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[DoktorSil]
@DoktorNo int
as begin 
delete Doktorlar where DoktorNo= @DoktorNo
end
GO
/****** Object:  StoredProcedure [dbo].[HastaListele]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[HastaListele]
as begin
select * from Hastalar 
end
GO
/****** Object:  StoredProcedure [dbo].[HastaListeleAZ]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[HastaListeleAZ]
as begin
select * from Hastalar order by HastaAdSoyad 
end
GO
/****** Object:  StoredProcedure [dbo].[HastaListeleZA]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[HastaListeleZA]
as begin
select * from Hastalar order by HastaAdSoyad desc
end
GO
/****** Object:  StoredProcedure [dbo].[KullaniciAdSorgulama]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[KullaniciAdSorgulama]
@Ad varchar(50)
as begin
select KullaniciAd from Kullanicilar where KullaniciAd=@Ad
end
GO
/****** Object:  StoredProcedure [dbo].[KullaniciEkle]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[KullaniciEkle](
@KullaniciAdSoyad varchar(50),
@Sifre varchar(50),
@Email varchar(50),
@TelefonNo char(20))
as begin	
insert into Kullanicilar(KullaniciAd,Sifre,Email,TelefonNo)
values(@KullaniciAdSoyad,@Sifre,@Email,@TelefonNo)
end
GO
/****** Object:  StoredProcedure [dbo].[KullaniciGiris]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[KullaniciGiris]
@Ad varchar(50),
@Sifre varchar(50)
as begin
select KullaniciAd, Sifre from Kullanicilar where KullaniciAd = @Ad and Sifre =@Sifre 
end
GO
/****** Object:  StoredProcedure [dbo].[PolAdBul]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[PolAdBul]
@PolNo int
as begin
select PolAdi from Polikinilikler where PolNo = @PolNo
end
GO
/****** Object:  StoredProcedure [dbo].[PolEkle]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[PolEkle]
@PolAdi varchar(50),
@PolUzmanSayisi int,
@PolBaskan varchar(50),
@PolBasHekim varchar(50),
@YatakSayisi int
as begin
insert into Polikinilikler(PolAdi,PolUzmanSayisi,PolBaskan,PolBasHekim,YatakSayisi)
values(@PolAdi,@PolUzmanSayisi,@PolBaskan,@PolBasHekim,@YatakSayisi)
end
GO
/****** Object:  StoredProcedure [dbo].[PolGuncelleme]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[PolGuncelleme]
@PolNo int,
@PolAdi varchar(50),
@PolUzmanSayisi int,
@PolBaskan varchar(50),
@PolBasHekim varchar(50),
@YatakSayisi int
as begin
update Polikinilikler set PolAdi=@PolAdi,PolUzmanSayisi=@PolUzmanSayisi,PolBaskan = @PolBaskan,PolBasHekim = @PolBasHekim,YatakSayisi=@YatakSayisi where PolNo=@PolNo
end
GO
/****** Object:  StoredProcedure [dbo].[PolListele]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[PolListele]
as begin
select * from Polikinilikler 
end
GO
/****** Object:  StoredProcedure [dbo].[PolListeleAZ]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[PolListeleAZ]
as begin
select * from Polikinilikler order by PolAdi
end
GO
/****** Object:  StoredProcedure [dbo].[PolListeleZA]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[PolListeleZA]
as begin
select * from Polikinilikler order by PolAdi DESC
end
GO
/****** Object:  StoredProcedure [dbo].[PolNoBul]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[PolNoBul]
@Pol varchar(50)
as begin
select PolNo from Polikinilikler where PolAdi = @Pol
end
GO
/****** Object:  StoredProcedure [dbo].[PolSilme]    Script Date: 20.01.2022 14:43:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[PolSilme]
@PolNo int
as begin
delete Polikinilikler where PolNo = @PolNo
end
GO
USE [master]
GO
ALTER DATABASE [HastaneProje] SET  READ_WRITE 
GO
