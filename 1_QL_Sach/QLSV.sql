USE [master]
GO
/****** Object:  Database [QLSV]    Script Date: 5/14/2022 11:44:01 PM ******/
CREATE DATABASE [QLSV]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLSV', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QLSV.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLSV_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\QLSV_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QLSV] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLSV].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLSV] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLSV] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLSV] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLSV] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLSV] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLSV] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLSV] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLSV] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLSV] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLSV] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLSV] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLSV] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLSV] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLSV] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLSV] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLSV] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLSV] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLSV] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLSV] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLSV] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLSV] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLSV] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLSV] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLSV] SET  MULTI_USER 
GO
ALTER DATABASE [QLSV] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLSV] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLSV] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLSV] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLSV] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLSV] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QLSV] SET QUERY_STORE = OFF
GO
USE [QLSV]
GO
/****** Object:  Table [dbo].[Diem]    Script Date: 5/14/2022 11:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diem](
	[MaMon] [varchar](255) NOT NULL,
	[MaSV] [varchar](255) NOT NULL,
	[DiemChuyenCan] [varchar](50) NULL,
	[DiemHe1] [varchar](50) NULL,
	[DiemHe21] [varchar](50) NULL,
	[DiemHe22] [varchar](50) NULL,
	[DiemQuaTrinh] [varchar](50) NULL,
	[DiemThi] [varchar](50) NULL,
	[DiemHocPhan] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMon] ASC,
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiaoVien]    Script Date: 5/14/2022 11:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiaoVien](
	[MaGV] [varchar](255) NOT NULL,
	[HoTen] [nvarchar](255) NULL,
	[NgaySinh] [nvarchar](255) NULL,
	[TenKhoa] [nvarchar](255) NULL,
	[TenDN] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC,
	[TenDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LopHoc]    Script Date: 5/14/2022 11:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHoc](
	[MaLop] [varchar](255) NOT NULL,
	[TenLop] [nvarchar](255) NULL,
	[KhoaHoc] [nvarchar](255) NULL,
	[HeDaoTao] [nvarchar](255) NULL,
	[NamNhapHoc] [int] NULL,
	[TenKhoa] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LopHocPhan]    Script Date: 5/14/2022 11:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHocPhan](
	[MaLop] [varchar](255) NOT NULL,
	[MaMon] [varchar](255) NOT NULL,
	[MaGV] [varchar](255) NULL,
	[HocKy] [int] NULL,
	[Nam] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC,
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 5/14/2022 11:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[MaMon] [varchar](255) NOT NULL,
	[TenMon] [nvarchar](255) NULL,
	[SoTin] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 5/14/2022 11:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[TenDN] [varchar](255) NOT NULL,
	[MatKhau] [nvarchar](255) NULL,
	[Loai] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[TenDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 5/14/2022 11:44:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[MaSV] [varchar](255) NOT NULL,
	[HoDem] [nvarchar](255) NULL,
	[Ten] [nvarchar](200) NULL,
	[NgaySinh] [varchar](10) NULL,
	[GioiTinh] [varchar](20) NULL,
	[QueQuan] [nvarchar](255) NULL,
	[Sdt] [varchar](20) NULL,
	[MaLop] [varchar](255) NULL,
	[TenDN] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'1', N'1', N'9', N'8', N'8', N'9', N'8.67', N'9', N'8.87')
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'1', N'2', N'10', N'8', N'8', N'8', N'8.89', N'8', N'8.36')
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'1', N'3', N'9', N'7', N'7', N'8', N'8.11', N'9', N'8.64')
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'1', N'4', N'10', N'9', N'9', N'9', N'9.44', N'10', N'9.78')
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'1', N'6', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'2', N'1', N'8', N'8', N'8', N'8', N'8', N'8', N'8')
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'2', N'2', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'2', N'3', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'2', N'4', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'2', N'6', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'3', N'1', N'10', N'7', N'9', N'8', N'9', N'9', N'9')
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'3', N'2', N'10', N'9', N'8', N'9', N'9.22', N'9', N'9.09')
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'3', N'3', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'3', N'4', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'3', N'6', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'4', N'1', N'9', N'6', N'7', N'8', N'7.71', N'8', N'7.88')
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'4', N'2', N'10', N'9', N'9', N'9', N'9.29', N'10', N'9.72')
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'4', N'3', N'10', N'9', N'9', N'9', N'9.29', N'9', N'9.12')
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'4', N'4', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Diem] ([MaMon], [MaSV], [DiemChuyenCan], [DiemHe1], [DiemHe21], [DiemHe22], [DiemQuaTrinh], [DiemThi], [DiemHocPhan]) VALUES (N'4', N'6', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[LopHoc] ([MaLop], [TenLop], [KhoaHoc], [HeDaoTao], [NamNhapHoc], [TenKhoa]) VALUES (N'DHTI', N'13A5', N'2019-2023', N'Đại Học', 2019, N'CNTT')
INSERT [dbo].[LopHoc] ([MaLop], [TenLop], [KhoaHoc], [HeDaoTao], [NamNhapHoc], [TenKhoa]) VALUES (N'MMT', N'12A7', N'2018-2022', N'Đại học', 2018, N'Mạng')
INSERT [dbo].[LopHoc] ([MaLop], [TenLop], [KhoaHoc], [HeDaoTao], [NamNhapHoc], [TenKhoa]) VALUES (N'NNA', N'13A8', N'2019-2023', N'Đại học', 2019, N'Ngôn ngữ anh')
GO
INSERT [dbo].[LopHocPhan] ([MaLop], [MaMon], [MaGV], [HocKy], [Nam]) VALUES (N'DHTI', N'1', N'1', 2, 2022)
INSERT [dbo].[LopHocPhan] ([MaLop], [MaMon], [MaGV], [HocKy], [Nam]) VALUES (N'MMT', N'2', N'2', 1, 2022)
INSERT [dbo].[LopHocPhan] ([MaLop], [MaMon], [MaGV], [HocKy], [Nam]) VALUES (N'NNA', N'4', N'3', 2, 2022)
GO
INSERT [dbo].[MonHoc] ([MaMon], [TenMon], [SoTin]) VALUES (N'1', N'Lập trình .Net', 4)
INSERT [dbo].[MonHoc] ([MaMon], [TenMon], [SoTin]) VALUES (N'2', N'Lập trình Web', 4)
INSERT [dbo].[MonHoc] ([MaMon], [TenMon], [SoTin]) VALUES (N'3', N'Cơ sở dữ liệu', 4)
INSERT [dbo].[MonHoc] ([MaMon], [TenMon], [SoTin]) VALUES (N'4', N'Đại số tuyến tính', 2)
GO
INSERT [dbo].[NguoiDung] ([TenDN], [MatKhau], [Loai]) VALUES (N'anh', N'123', N'SV')
INSERT [dbo].[NguoiDung] ([TenDN], [MatKhau], [Loai]) VALUES (N'CanBo', N'123', N'CB')
INSERT [dbo].[NguoiDung] ([TenDN], [MatKhau], [Loai]) VALUES (N'dong', N'12344', N'SV')
INSERT [dbo].[NguoiDung] ([TenDN], [MatKhau], [Loai]) VALUES (N'duong', N'333', N'SV')
INSERT [dbo].[NguoiDung] ([TenDN], [MatKhau], [Loai]) VALUES (N'GiaoVien', N'123', N'GV')
INSERT [dbo].[NguoiDung] ([TenDN], [MatKhau], [Loai]) VALUES (N'hieu', N'11111', N'SV')
INSERT [dbo].[NguoiDung] ([TenDN], [MatKhau], [Loai]) VALUES (N'khai', N'13246', N'SV')
INSERT [dbo].[NguoiDung] ([TenDN], [MatKhau], [Loai]) VALUES (N'khaixoan', N'1111111', N'SV')
INSERT [dbo].[NguoiDung] ([TenDN], [MatKhau], [Loai]) VALUES (N'nam', N'123', N'SV')
GO
INSERT [dbo].[SinhVien] ([MaSV], [HoDem], [Ten], [NgaySinh], [GioiTinh], [QueQuan], [Sdt], [MaLop], [TenDN]) VALUES (N'1', N'Trần Văn ', N'Đồng', N'13-03-2001', N'Nam', N'Bắc Ninh', N'02224444', N'DHTI', N'dong')
INSERT [dbo].[SinhVien] ([MaSV], [HoDem], [Ten], [NgaySinh], [GioiTinh], [QueQuan], [Sdt], [MaLop], [TenDN]) VALUES (N'2', N'Nguyễn Văn ', N'Hiệu', N'23-2-2001', N'Nam', N'Bắc Giang', N'034566', N'DHTI', N'hieu')
INSERT [dbo].[SinhVien] ([MaSV], [HoDem], [Ten], [NgaySinh], [GioiTinh], [QueQuan], [Sdt], [MaLop], [TenDN]) VALUES (N'3', N'Nguyễn Văn', N'Khải', N'3-7-2001', N'Nam', N'Bấc Giang', N'0325664', N'DHTI', N'khai')
INSERT [dbo].[SinhVien] ([MaSV], [HoDem], [Ten], [NgaySinh], [GioiTinh], [QueQuan], [Sdt], [MaLop], [TenDN]) VALUES (N'4', N'Đặng Xuân', N'Dương', N'23-2-2001', N'Nam', N'Quảng Ninh', N'03246', N'DHTI', N'duong')
INSERT [dbo].[SinhVien] ([MaSV], [HoDem], [Ten], [NgaySinh], [GioiTinh], [QueQuan], [Sdt], [MaLop], [TenDN]) VALUES (N'6', N'Đỗ  Văn ', N'Khải', N'23-10-2001', N'Nam', N'Bắc Giang', N'03336', N'DHTI', N'khaixoan')
INSERT [dbo].[SinhVien] ([MaSV], [HoDem], [Ten], [NgaySinh], [GioiTinh], [QueQuan], [Sdt], [MaLop], [TenDN]) VALUES (N'7', N'Nguyễn Văn', N'Nam', N'13-02-2001', N'Nam', N'Bắc Ninh', N'03332', N'MMT', N'nam')
GO
ALTER TABLE [dbo].[Diem]  WITH CHECK ADD FOREIGN KEY([MaMon])
REFERENCES [dbo].[MonHoc] ([MaMon])
GO
ALTER TABLE [dbo].[Diem]  WITH CHECK ADD FOREIGN KEY([MaSV])
REFERENCES [dbo].[SinhVien] ([MaSV])
GO
ALTER TABLE [dbo].[GiaoVien]  WITH CHECK ADD FOREIGN KEY([TenDN])
REFERENCES [dbo].[NguoiDung] ([TenDN])
GO
ALTER TABLE [dbo].[LopHocPhan]  WITH CHECK ADD FOREIGN KEY([MaLop])
REFERENCES [dbo].[LopHoc] ([MaLop])
GO
ALTER TABLE [dbo].[LopHocPhan]  WITH CHECK ADD FOREIGN KEY([MaMon])
REFERENCES [dbo].[MonHoc] ([MaMon])
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD FOREIGN KEY([TenDN])
REFERENCES [dbo].[NguoiDung] ([TenDN])
GO
USE [master]
GO
ALTER DATABASE [QLSV] SET  READ_WRITE 
GO
