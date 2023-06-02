use master
go
IF EXISTS(SELECT 'True' FROM master.dbo.Sysdatabases WHERE NAME='ThucTapChuyenNganhHTTT')
DROP DATABASE ThucTapChuyenNganhHTTT
go
create database ThucTapChuyenNganhHTTT
go
use ThucTapChuyenNganhHTTT
go

Create table SanPham
(
	MaSP nChar(10) NOT NULL primary key,
	TenSP nvarChar(50) ,
	SoLuongTon Integer ,
	GioiThieu Nvarchar(100) ,
	GiaBan Money ,
	BaoQuan Nvarchar(100)
) 
go
CREATE TABLE NhanVien
(
	MaNV char(10) primary key,
	TenNV nvarchar(30),
	DiaChi nvarchar(30),
	SoDT char(10),
	Email char(30),
	GioiTinh bit
)
go
Create table TaiKhoan
(
	TenDN char(20) primary key,
	PhanQuyen Nvarchar(10),
	MatKhau Nchar(10),
	MaNV char(10),
	constraint fk_TK foreign key (MaNV) references NhanVien (MaNV) ON UPDATE CASCADE ON DELETE CASCADE
) 
go
Create table HoaDon
(
	MaHD nChar(10) primary key,
	ThoiGianMua Nvarchar(30),
	SoLuong Integer ,
	TrangThaiDon nvarChar(50) ,
	DiaChi nvarChar(50) ,
	HoTen nvarChar(50),
	SoDienThoai char(10),
	MaSP nChar(10) ,
	MaNV char(10),
	constraint fk_HD_NV foreign key (MaNV) references NhanVien (MaNV) ON UPDATE CASCADE ON DELETE CASCADE,
	constraint fk_HD_SanPham foreign key (MaSP) references SanPham (MaSP) ON UPDATE CASCADE ON DELETE CASCADE
) 

go
insert into SanPham values ('SP1','De men',30,'Day la tac pham kinh kien cua nha van To Hoai',50000,'Bao quan noi kho thoang'),
							('SP2','Tam Cam',50,'Truyen thuoc the loai truyen co tich dan gian Viet Nam',50000,'Bao quan noi kho thoang'),
							('SP3','So Dua',40,'Truyen thuoc the loai truyen co tich dan gian Viet Nam',50000,'Bao quan noi kho thoang')
insert into NhanVien values('NV1','Trang','Ha Noi','0982128843','trang@gmail.com',1),
							('NV2','Thuy','Ha Noi','0972364344','thuy@gmail.com',0),
							('NV3','Hue','Ha Noi','0932424444','hue@gmail.com',0),
							('NV4','Tuan','Ha Noi','098286643','tuan@gmail.com',1)
insert into TaiKhoan values ('trang','User','12345678','NV1'),
							('thuy','User','12345678','NV2'),
							('ngoctuan','admin','12345678','NV4'),
							('hue','User','12345678','NV3')
insert into HoaDon values ('HD1','20-JAN-2023',10,'Cho xac nhan','Ha Noi','Hoang Minh Hue','0868299812','SP1','NV1'),
							('HD2','20-JAN-2023',60,'Cho xac nhan','Ha Noi','Nguyen Thi Huyen Trang','0868299812','SP1','NV2'),
							('HD3','20-JAN-2023',90,'Cho xac nhan','Ha Noi','Ho Ngoc Tuan','0868299812','SP1','NV3'),
							('HD4','20-JAN-2023',6,'Cho xac nhan','Ha Noi','Nguyen Thi Thuy','0868299812','SP1','NV4')
go
select * from SanPham
select * from HOADON
select * from NhanVien
select * from TaiKhoan
go