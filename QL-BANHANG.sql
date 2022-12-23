CREATE DATABASE QL_BANHANG
GO

USE QL_BANHANG
GO

	-- KHACHANG
	CREATE TABLE TAIKHOAN
	(
		MATK	INT NOT NULL IDENTITY(1, 1),
		MATKHAU	VARCHAR(20),
		MAQUYEN INT,	
		HOTEN	NVARCHAR(30),
		EMAIL	VARCHAR(30),
		SODT	VARCHAR(10),
		NGAYSINH DATE,
		CONSTRAINT PK_KHACHHANG PRIMARY KEY(MATK)
	);

	---------------------------------------------

	-- QUYỀN TRUY CẬP
	CREATE TABLE QUYENTRUYCAP
	(
		MAQUYEN	INT NOT NULL IDENTITY(1, 1),	
		TENQUYEN	NVARCHAR(40),
		CONSTRAINT PK_QUYENTRUYCAP PRIMARY KEY(MAQUYEN)
	);
	---------------------------------------------

	-- SANPHAM
	CREATE TABLE SANPHAM
	(
		MASP INT NOT NULL IDENTITY(1, 1),
		TENSP NVARCHAR(60),
		NUOCSX	NVARCHAR(40),
		CHATLIEU NVARCHAR(30),
		HINH VARCHAR(100),
		GIA DECIMAL(18, 0),
		MALOAISP INT,
		CONSTRAINT PK_SANPHAM PRIMARY KEY(MASP)
	);
	
	---------------------------------------------


	-- LOAISANPHAM
	CREATE TABLE LOAISANPHAM
	(
		MALOAISP INT NOT NULL IDENTITY(1, 1),
		TENLOAISP NVARCHAR(60),
		CONSTRAINT PK_LOAISANPHAM PRIMARY KEY(MALOAISP)
	);

	---------------------------------------------

	-- HOADON
	CREATE TABLE HOADON
	(
		SOHD INT NOT NULL IDENTITY(1, 1),
		NGHD DATE,
		MATK INT,
		TRIGIA DECIMAL(18, 0),
		CONSTRAINT PK_HOADON PRIMARY KEY(SOHD)
	);

	---------------------------------------------

	-- CTHD
	   CREATE TABLE CTHD
	(
		SOHD INT NOT NULL,
		MASP INT NOT NULL,
		SL INT,
		CONSTRAINT PK_CTHD PRIMARY KEY(SOHD,MASP)
	);
---------------------------------------------
-- Khoa ngoai cho bang TAIKHOAN
ALTER TABLE TAIKHOAN 
ADD CONSTRAINT FK_TAIKHOAN_QUYENTRUYCAP FOREIGN KEY(MAQUYEN) REFERENCES QUYENTRUYCAP(MAQUYEN)

-- Khoa ngoai cho bang SANPHAM
ALTER TABLE SANPHAM 
ADD CONSTRAINT FK_SANPHAM_LOAISANPHAM FOREIGN KEY(MALOAISP) REFERENCES LOAISANPHAM(MALOAISP)

-- Khoa ngoai cho bang HOADON
ALTER TABLE HOADON 
ADD CONSTRAINT FK_HOADON_TAIKHOAN FOREIGN KEY(MATK) REFERENCES TAIKHOAN(MATK)

-- Khoa ngoai cho bang CTHD
ALTER TABLE CTHD 
ADD CONSTRAINT FK_CTHD_HOADON FOREIGN KEY(SOHD) REFERENCES HOADON(SOHD)

ALTER TABLE CTHD 
ADD CONSTRAINT FK_CTHD_SANPHAM FOREIGN KEY(MASP) REFERENCES SANPHAM(MASP)

------------THÊM RÀNG BUỘC-----------------------------------------
ALTER TABLE SANPHAM
ADD CONSTRAINT CHK_GIA CHECK (GIA > 0)
ALTER TABLE HOADON 
ADD CONSTRAINT CHK_TRIGIA CHECK (TRIGIA > 0)
ALTER TABLE TAIKHOAN
ADD CONSTRAINT DF_MATK DEFAULT 1 FOR MAQUYEN

-------------------------------
-- LOAITAIKHOAN
INSERT INTO QUYENTRUYCAP(TENQUYEN)
VALUES
(N'Khách hàng'),
(N'Nhân viên');

-------------------------------
-- TAIKHOAN
SET DATEFORMAT DMY
INSERT INTO TAIKHOAN(HOTEN, EMAIL, SODT, NGAYSINH, MATKHAU, MAQUYEN)
VALUES
(N'Phạm Trần Tấn Đạt','tandat.pham292@gmail.com','0862616215','22/09/2002','123456', 2),
(N'Nguyễn Văn A', 'anguyen123@gmail.com','0123456789','22/10/1960','123456', 1),
(N'Trần Ngọc Hân', 'hantran123@gmail.com','0122456389','03/04/1974','123456', 1),
(N'Trần Ngọc Linh','linhtran123@gmail.com','0121736789','12/06/1980','123456', 1),
(N'Trần Minh Long','longtran123@gmail.com','0116367890','09/03/1965','123456', 1),
(N'Lê Nhật Minh','minhle123@gmail.com','0323284789','10/03/1950','123456', 1),
(N'Lê Hoài Thương','thuongle123@gmail.com','0483428589','31/12/1981','123456', 1),
(N'Nguyễn Văn Tám','tamnguyen123@gmail.com','0125438739','06/04/1971','123456', 1),
(N'Phan Thị Thanh','thanhphan123@gmail.com','0323456789','10/01/1971','123456', 1),
(N'Lê Hà Vinh','vinhle123@gmail.com','0123437789','03/09/1979','123456', 1),
(N'Hà Duy Lập','lapha123@gmail.com','0127476789','02/05/1983','123456', 1);

-------------------------------
-- LOAISANPHAM
INSERT INTO LOAISANPHAM(TENLOAISP)
VALUES
(N'Áo'),
(N'Quần'),
(N'Outerwear'),
(N'Balo');

-------------------------------
-- SANPHAM
INSERT INTO SANPHAM(TENSP, NUOCSX, CHATLIEU, HINH, GIA, MALOAISP)
VALUES
(N'COACHELLA HEAVY TEE', N'Việt Nam',N'Cotton', 'coachella-beaty-tee.png', 895000, 1),
(N'JURASSIC GIRL TEE', N'Việt Nam',N'Cotton', 'furassic-girl-tee.png', 1250000, 1),
(N'TWO ANGELS SHORTS', N'Việt Nam',N'Nỉ Da Cá','two-angels-shorts.png', 450000, 2),
(N'STICK TALK TEE', N'Việt Nam',N'Cotton', 'stick-talk-tee.png', 895000, 1),
(N'THE FACE TEE', N'Việt Nam',N'Cotton', 'the-face-tee.png', 895000, 1),
(N'TWO ANGELS HEAVY HOODIE', N'Việt Nam',N'Nỉ Da Cá', 'two-angels-beaty-hoodie.png', 450000, 3),
(N'TWO ANGELS SHIRT', N'Việt Nam',N'Cotton', 'two-angle-shirt.png', 895000, 1),
(N'COACHELLA HEAVY FLEECE PANTS', N'Việt Nam',N'Cotton', 'coachella-beaty-fleece-pants.png', 895000, 2);

-------------------------------
---- HOADON
--SET DATEFORMAT DMY
--INSERT INTO HOADON(NGHD, MATK, TRIGIA)
--VALUES
--('23/07/2022',1, 800000),
--('12/08/2022', 10, 2200000),
--('23/08/2022',2, 2000000),
--('01/09/2022',6, 1200000),
--('20/10/2022',5, 1000000);

---------------------------------
---- CTHD
--INSERT INTO CTHD (SOHD, MASP, SL)
--VALUES
--(1, 1, 1),
--(1, 2, 1),
--(2, 2, 2),
--(2, 3, 3),
--(3, 2 ,4),
--(4, 3, 3),
--(5, 2, 4);

----------------------------------------------------------------
----------------------------------------------------------------