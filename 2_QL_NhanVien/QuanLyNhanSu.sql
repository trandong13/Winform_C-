USE [master]
GO
/****** Object:  Database [QuanLyNhanSu]    Script Date: 11/2/2022 3:29:16 PM ******/
CREATE DATABASE [QuanLyNhanSu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyNhanSu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyNhanSu.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyNhanSu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\QuanLyNhanSu_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyNhanSu] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyNhanSu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyNhanSu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyNhanSu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyNhanSu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyNhanSu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyNhanSu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyNhanSu] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyNhanSu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyNhanSu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyNhanSu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyNhanSu] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QuanLyNhanSu] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QuanLyNhanSu]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 11/2/2022 3:29:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaCV] [nvarchar](50) NOT NULL,
	[TenCV] [nvarchar](50) NULL,
	[PhuCap] [float] NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DangNhap]    Script Date: 11/2/2022 3:29:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangNhap](
	[TaiKhoan] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NULL,
	[Kieu] [nvarchar](50) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Luong]    Script Date: 11/2/2022 3:29:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luong](
	[BacLuong] [int] NOT NULL,
	[LuongCoBan] [int] NULL,
	[HeSoLuong] [float] NULL,
	[HeSoPhuCap] [float] NULL,
 CONSTRAINT [PK_Luong] PRIMARY KEY CLUSTERED 
(
	[BacLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/2/2022 3:29:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [nvarchar](50) NOT NULL,
	[TenNV] [nvarchar](50) NULL,
	[DanToc] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[QueQuan] [nvarchar](50) NULL,
	[NgaySinh] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[MaCV] [nvarchar](50) NULL,
	[MaTDHV] [nvarchar](50) NULL,
	[BacLuong] [int] NULL,
	[MaPB] [nvarchar](50) NULL,
	[TaiKhoan] [nvarchar](50) NULL,
	[SoNgay] [int] NULL,
	[TongLuong] [decimal](18, 3) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 11/2/2022 3:29:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPB] [nvarchar](50) NOT NULL,
	[TenPB] [nvarchar](50) NULL,
	[DiachiPB] [nvarchar](50) NULL,
	[SDTPB] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhongBan] PRIMARY KEY CLUSTERED 
(
	[MaPB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrinhDoHocVan]    Script Date: 11/2/2022 3:29:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrinhDoHocVan](
	[MaTDHV] [nvarchar](50) NOT NULL,
	[TenTDHV] [nvarchar](50) NULL,
	[ChuyenNganh] [nvarchar](50) NULL,
 CONSTRAINT [PK_TrinhDoHocVan] PRIMARY KEY CLUSTERED 
(
	[MaTDHV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[ChucVu] ([MaCV], [TenCV], [PhuCap]) VALUES (N'1', N'Giám đốc', 3000000)
INSERT [dbo].[ChucVu] ([MaCV], [TenCV], [PhuCap]) VALUES (N'2', N'Trưởng phòng', 2000000)
INSERT [dbo].[ChucVu] ([MaCV], [TenCV], [PhuCap]) VALUES (N'3', N'Phó phòng', 1500000)
INSERT [dbo].[ChucVu] ([MaCV], [TenCV], [PhuCap]) VALUES (N'4', N'Nhân viên', 1000000)
INSERT [dbo].[DangNhap] ([TaiKhoan], [MatKhau], [Kieu]) VALUES (N'CB', N'123', N'CB')
INSERT [dbo].[DangNhap] ([TaiKhoan], [MatKhau], [Kieu]) VALUES (N'NV', N'123', N'NV')
INSERT [dbo].[Luong] ([BacLuong], [LuongCoBan], [HeSoLuong], [HeSoPhuCap]) VALUES (1, 2000000, 2, 1.5)
INSERT [dbo].[Luong] ([BacLuong], [LuongCoBan], [HeSoLuong], [HeSoPhuCap]) VALUES (2, 2500000, 2, 1.5)
INSERT [dbo].[Luong] ([BacLuong], [LuongCoBan], [HeSoLuong], [HeSoPhuCap]) VALUES (3, 3000000, 3, 2)
INSERT [dbo].[Luong] ([BacLuong], [LuongCoBan], [HeSoLuong], [HeSoPhuCap]) VALUES (4, 3500000, 3, 2.5)
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [DanToc], [GioiTinh], [QueQuan], [NgaySinh], [SDT], [MaCV], [MaTDHV], [BacLuong], [MaPB], [TaiKhoan], [SoNgay], [TongLuong]) VALUES (N'1', N'Đồng', N'kinh', N'nam', N'bn', N'13/03/2001', N'035984', N'1', N'1', 3, N'2', NULL, 23, CAST(14500000.000 AS Decimal(18, 3)))
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [DanToc], [GioiTinh], [QueQuan], [NgaySinh], [SDT], [MaCV], [MaTDHV], [BacLuong], [MaPB], [TaiKhoan], [SoNgay], [TongLuong]) VALUES (N'2', N'Hiệu', N'kinh', N'nam', N'bn', N'14/03/2002', N'035984', N'3', N'3', 1, N'2', NULL, 23, CAST(6866666.667 AS Decimal(18, 3)))
INSERT [dbo].[NhanVien] ([MaNV], [TenNV], [DanToc], [GioiTinh], [QueQuan], [NgaySinh], [SDT], [MaCV], [MaTDHV], [BacLuong], [MaPB], [TaiKhoan], [SoNgay], [TongLuong]) VALUES (N'3', N'Hưng', N'kinh', N'nữ', N'bn', N'14/03/2002', N'035984', N'2', N'3', 2, N'2', NULL, 23, CAST(8708333.333 AS Decimal(18, 3)))
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [DiachiPB], [SDTPB]) VALUES (N'1', N'Phòng IT', N'Hà Nội', N'03569877')
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [DiachiPB], [SDTPB]) VALUES (N'2', N'Phòng nhân sự', N'Bác Ninh', N'035984')
INSERT [dbo].[PhongBan] ([MaPB], [TenPB], [DiachiPB], [SDTPB]) VALUES (N'3', N'Phòng điều hành', N'Bác Ninh', N'035984346')
INSERT [dbo].[TrinhDoHocVan] ([MaTDHV], [TenTDHV], [ChuyenNganh]) VALUES (N'1', N'Kỹ sư', N'CNTT')
INSERT [dbo].[TrinhDoHocVan] ([MaTDHV], [TenTDHV], [ChuyenNganh]) VALUES (N'2', N'Cử Nhân', N'Hóa')
INSERT [dbo].[TrinhDoHocVan] ([MaTDHV], [TenTDHV], [ChuyenNganh]) VALUES (N'3', N'Kỹ sư', N'Mạng máy tính')
INSERT [dbo].[TrinhDoHocVan] ([MaTDHV], [TenTDHV], [ChuyenNganh]) VALUES (N'4', N'Cử nhân', N'Ngôn ngữ anh')
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_ChucVu] FOREIGN KEY([MaCV])
REFERENCES [dbo].[ChucVu] ([MaCV])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_ChucVu]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_DangNhap] FOREIGN KEY([TaiKhoan])
REFERENCES [dbo].[DangNhap] ([TaiKhoan])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_DangNhap]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_Luong] FOREIGN KEY([BacLuong])
REFERENCES [dbo].[Luong] ([BacLuong])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_Luong]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_PhongBan] FOREIGN KEY([MaPB])
REFERENCES [dbo].[PhongBan] ([MaPB])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_PhongBan]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_TrinhDoHocVan] FOREIGN KEY([MaTDHV])
REFERENCES [dbo].[TrinhDoHocVan] ([MaTDHV])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_TrinhDoHocVan]
GO
USE [master]
GO
ALTER DATABASE [QuanLyNhanSu] SET  READ_WRITE 
GO
