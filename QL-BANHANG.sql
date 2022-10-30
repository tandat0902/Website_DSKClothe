CREATE DATABASE QL_BANHANG
GO

USE QL_BANHANG
GO


---- TĂNG MÃ TỰ ĐỘNG
--CREATE FUNCTION AUTO_IDKH()
--RETURNS VARCHAR(10)
--AS
--BEGIN
--	DECLARE @ID VARCHAR(10)
--	IF (SELECT COUNT(MAKH) FROM KHACHHANG) = 0
--		SET @ID = '0'
--	ELSE
--		SELECT @ID = MAX(RIGHT(MAKH, 8)) FROM KHACHHANG
--		SELECT @ID = CASE
--			WHEN @ID >= 1 AND @ID <= 9 THEN 'KH0000000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
--			WHEN @ID >= 10 AND @ID <= 99 THEN 'KH000000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
--			WHEN @ID >= 100 AND @ID <= 999 THEN 'KH00000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
--			WHEN @ID >= 1000 AND @ID <= 9999 THEN 'KH0000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
--			WHEN @ID >= 10000 AND @ID <= 99999 THEN 'KH000' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
--			WHEN @ID >= 100000 AND @ID <= 999999 THEN 'KH00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
--			WHEN @ID >= 1000000 AND @ID <= 9999999 THEN 'KH0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
--			WHEN @ID >= 10000000 AND @ID <= 99999999 THEN 'KH' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
--		END
--	RETURN @ID
--END
--GO

-- KHACHANG
CREATE TABLE KHACHHANG
(
	MAKH	INT NOT NULL IDENTITY(1, 1),	
	HOTEN	NVARCHAR(30),
	EMAIL	VARCHAR(30),
	SODT	VARCHAR(10),
	NGAYSINH DATE,
	MATKHAU	VARCHAR(20),
	CONSTRAINT PK_KHACHHANG PRIMARY KEY(MAKH)
);



---------------------------------------------
-- NHANVIEN
CREATE TABLE NHANVIEN
(
	MANV	INT NOT NULL IDENTITY(1, 1),	
	HOTEN	NVARCHAR(40),
	SODT	VARCHAR(10),
	VITRI	NVARCHAR(60),
	CONSTRAINT PK_NHANVIEN PRIMARY KEY(MANV)
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
	CONSTRAINT PK_SANPHAM PRIMARY KEY(MASP)
);
	
---------------------------------------------
-- HOADON
CREATE TABLE HOADON
(
	SOHD INT NOT NULL IDENTITY(1, 1),
	NGHD DATE,
	MAKH INT,
	MANV INT,
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

-- Khoa ngoai cho bang HOADON
ALTER TABLE HOADON 
ADD CONSTRAINT FK_HOADON_KHACHHANG FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)

ALTER TABLE HOADON 
ADD CONSTRAINT FK_HOADON_NHANVIEN FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)

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


-------------------------------
-- KHACHHANG
SET DATEFORMAT DMY
INSERT INTO KHACHHANG(HOTEN, EMAIL, SODT, NGAYSINH, MATKHAU)
VALUES
(N'Phạm Trần Tấn Đạt','tandat.pham292@gmail.com','0862616215','22/09/2002','123456'),
(N'Nguyễn Văn A', 'anguyen123@gmail.com','0123456789','22/10/1960','123456'),
(N'Trần Ngọc Hân', 'hantran123@gmail.com','0122456389','03/04/1974','123456'),
(N'Trần Ngọc Linh','linhtran123@gmail.com','0121736789','12/06/1980','123456'),
(N'Trần Minh Long','longtran123@gmail.com','0116367890','09/03/1965','123456'),
(N'Lê Nhật Minh','minhle123@gmail.com','0323284789','10/03/1950','123456'),
(N'Lê Hoài Thương','thuongle123@gmail.com','0483428589','31/12/1981','123456'),
(N'Nguyễn Văn Tám','tamnguyen123@gmail.com','0125438739','06/04/1971','123456'),
(N'Phan Thị Thanh','thanhphan123@gmail.com','0323456789','10/01/1971','123456'),
(N'Lê Hà Vinh','vinhle123@gmail.com','0123437789','03/09/1979','123456'),
(N'Hà Duy Lập','lapha123@gmail.com','0127476789','02/05/1983','123456');

-------------------------------
-- NHANVIEN
INSERT INTO NHANVIEN(HOTEN, SODT, VITRI)
VALUES
(N'Phạm Trần Tấn Đạt','0123456789',N'CEO'),
(N'Kiều Đạo Nhất San','0122456389',N'Bảo vệ'),
( N'Nguyễn Minh Khoa','0121736789',N'CEO'),
(N'Ngô Thanh Tuấn','0116367890',N'Bán Hàng'),
(N'Nguyễn Thị Trúc Anh','0483428589',N'Bán Hàng'),
(N'Nguyễn Trần Duy Nhất','0323456789',N'Bán Hàng'),
(N'Lê Thị Mộng Gấm','0323456789',N'Nhân viên chăm sóc khách hàng');

-------------------------------
-- SANPHAM
INSERT INTO SANPHAM(TENSP, NUOCSX, CHATLIEU, HINH, GIA)
VALUES
(N'COACHELLA HEAVY TEE', N'Việt Nam',N'Cotton', '/Images/img-home/coachella-beaty-tee.png', 895000),
(N'JURASSIC GIRL TEE', N'Việt Nam',N'Cotton', '/Images/img-home/furassic-girl-tee.png', 1250000),
(N'TWO ANGELS SHORTS', N'Việt Nam',N'Nỉ Da Cá','/Images/img-home/two-angels-shorts.png', 450000),
(N'STICK TALK TEE', N'Việt Nam',N'Cotton', '/Images/img-home/stick-talk-tee.png', 895000),
(N'THE FACE TEE', N'Việt Nam',N'Cotton', '/Images/img-home/the-face-tee.png', 895000),
(N'TWO ANGELS HEAVY HOODIE', N'Việt Nam',N'Nỉ Da Cá', '/Images/img-home/two-angels-beaty-hoodie.png', 450000),
(N'TWO ANGELS SHIRT', N'Việt Nam',N'Cotton', '/Images/img-home/two-angle-shirt.png', 895000),
(N'COACHELLA HEAVY FLEECE PANTS', N'Việt Nam',N'Cotton', '/Images/img-home/coachella-beaty-fleece-pants.png', 895000);

-------------------------------
-- HOADON
SET DATEFORMAT DMY
INSERT INTO HOADON(NGHD, MAKH, MANV, TRIGIA)
VALUES
('23/07/2022',1, 5, 800000),
('12/08/2022', 10, 4, 2200000),
('23/08/2022',2, 5, 2000000),
('01/09/2022',6, 6, 1200000),
('20/10/2022',5, 4, 1000000);

-------------------------------
-- CTHD
INSERT INTO CTHD (SOHD, MASP, SL)
VALUES
(1, 1, 1),
(1, 2, 1),
(2, 2, 2),
(2, 3, 3),
(3, 2 ,4),
(4, 3, 3),
(5, 2, 4);

----------------------------------------------------------------
----------------------------------------------------------------

SELECT * 
FROM KHACHHANG