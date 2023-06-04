drop database ThucTapChuyenNganhHTTT
create DATABASE ThucTapChuyenNganhHTTT
use ThucTapChuyenNganhHTTT

-- Tao ma hoa don tu dong
create function Auto_Orders_OrderCode()
returns char(10)
as 
begin declare @id varchar(10)
     if (select count(MaHD) from HoaDon)=0
	   set @id='0'
	else
	   select @id=max(right(MaHD,8)) from HoaDon
	   select @id=case
	      when @id>=0 and @id<9 then 'hd00'+convert(char,convert(int,@id)+1)
		  when @id>=9 then 'hd0'+convert(char,convert(int,@id)+1)
	end
	return @id
end

-- Tao ma san pham tu dong
CREATE FUNCTION Auto_Products_ProductCode()
RETURNS char(10)
AS 
BEGIN
    DECLARE @id varchar(10);
    
    IF (SELECT COUNT(MaSP) FROM SanPham) = 0
        SET @id = '0';
    ELSE
        SELECT @id = MAX(RIGHT(MaSP, 8)) FROM SanPham;
        
    SET @id = 
        CASE
            WHEN CAST(@id AS int) >= 0 AND CAST(@id AS int) < 9 THEN 'sp00' + CAST(CAST(@id AS int) + 1 AS varchar(10))
            WHEN CAST(@id AS int) >= 9 THEN 'sp0' + CAST(CAST(@id AS int) + 1 AS varchar(10))
        END;
        
    RETURN @id;
END;

-- Tao ma nhan vien tu dong
CREATE FUNCTION Auto_Staffs_StaffCode()
RETURNS nvarchar(10)
AS 
BEGIN
    DECLARE @id nvarchar(10);
    IF (SELECT COUNT(MaNV) FROM NhanVien) = 0
        SET @id = '0';
    ELSE
        SELECT @id = MAX(RIGHT(MaNV, 8)) FROM NhanVien;
        
    SET @id = 
        CASE
            WHEN CAST(@id AS int) >= 0 AND CAST(@id AS int) < 9 THEN 'nv00' + CAST(CAST(@id AS int) + 1 AS nvarchar(10))
            WHEN CAST(@id AS int) >= 9 THEN 'nv0' + CAST(CAST(@id AS int) + 1 AS nvarchar(10))
        END;
        
    RETURN @id;
END;

--Tao bang san pham
Create table SanPham
(
	MaSP nChar(10) NOT NULL primary key,
	TenSP nvarChar(50) ,
	SoLuongTon Integer ,
	GioiThieu Nvarchar(100) ,
	GiaBan Money ,
	BaoQuan Nvarchar(100)
) 

--Tao bang nhan vien
CREATE TABLE NhanVien
(
	MaNV char(10) primary key,
	TenNV nvarchar(30),
	DiaChi nvarchar(30),
	SoDT char(10),
	Email char(30),
	GioiTinh bit
)

--Tao bang tai khoan
Create table TaiKhoan
(
	TenDN char(20) primary key,
	PhanQuyen Nvarchar(10),
	MatKhau Nchar(10),
	MaNV char(10),
	constraint fk_TK foreign key (MaNV) references NhanVien (MaNV) ON UPDATE CASCADE ON DELETE CASCADE
) 

--Tao bang hoa don
Create table HoaDon
(
	MaHD char(10) primary key,
	ThoiGianMua DateTime,
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

insert into SanPham values (dbo.Auto_Products_ProductCode(),'De men',30,'Day la tac pham kinh kien cua nha van To Hoai',50000,'Bao quan noi kho thoang');
insert into SanPham values (dbo.Auto_Products_ProductCode(),'Tam Cam',50,'Truyen thuoc the loai truyen co tich dan gian Viet Nam',50000,'Bao quan noi kho thoang');
insert into SanPham values (dbo.Auto_Products_ProductCode(),'So Dua',40,'Truyen thuoc the loai truyen co tich dan gian Viet Nam',50000,'Bao quan noi kho thoang');

INSERT INTO NhanVien VALUES (dbo.Auto_Staffs_StaffCode(), N'Nguyễn Thị Huyền Trang', N'Ninh Bình', '0982128843', 'trang@gmail.com', 1);
INSERT INTO NhanVien VALUES (dbo.Auto_Staffs_StaffCode(), N'Nguyễn Thị Thủy', N'Hải Dương', '0972364344', 'thuy@gmail.com', 0);
INSERT INTO NhanVien VALUES (dbo.Auto_Staffs_StaffCode(), N'Hoàng Minh Huệ', N'Sóc Sơn - Hà Nội', '0932424444', 'hue@gmail.com', 0);
INSERT INTO NhanVien VALUES (dbo.Auto_Staffs_StaffCode(), N'Hồ Ngọc Tuấn', N'Hà Nội', '098286643', 'tuan@gmail.com', 1);


insert into TaiKhoan values ('trang','User','12345678','nv001'),
							('thuy','User','12345678','nv002'),
							('ngoctuan','admin','12345678','nv003'),
							('hue','User','12345678','nv004')

insert into HoaDon values (dbo.Auto_Orders_OrderCode(),'2023-01-02',10,'Cho xac nhan','Ha Noi','Hoang Minh Hue','0868299812','sp001','nv001')
insert into HoaDon values (dbo.Auto_Orders_OrderCode(),'2023-03-06',60,'Cho xac nhan','Ha Noi','Nguyen Thi Huyen Trang','0868299812','sp002','nv002')
insert into HoaDon values (dbo.Auto_Orders_OrderCode(),'2023-05-04',90,'Cho xac nhan','Ha Noi','Ho Ngoc Tuan','0868299812','sp003','nv003')
insert into HoaDon values (dbo.Auto_Orders_OrderCode(),'2023-01-01',6,'Cho xac nhan','Ha Noi','Nguyen Thi Thuy','0868299812','sp001','nv004')

select * from NhanVien
select * from SanPham
select * from HoaDon
select * from TaiKhoan

