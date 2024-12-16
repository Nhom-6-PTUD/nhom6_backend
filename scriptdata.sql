CREATE DATABASE CHIC_CHARM2

CREATE TABLE NGUOIDUNG (
    tendangnhap VARCHAR(50) NOT NULL PRIMARY KEY, -- Khóa chính
    matkhau NVARCHAR(255) NOT NULL,
    loainguoidung NVARCHAR(50) CHECK (loainguoidung IN ('Khách hàng', 'Admin')) NOT NULL
);

CREATE TABLE THANHVIEN (
    matv char(4) NOT NULL PRIMARY KEY , -- Khóa chính
    tendangnhap VARCHAR(50) NOT NULL, -- Khóa ngoại
    Hoten NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15),
    Email NVARCHAR(100),
    Sonha Nvarchar(100), Duong Nvarchar(100), Quan Nvarchar(100), ThanhPho Nvarchar(100)

    CONSTRAINT FK_THANHVIEN_NGUOIDUNG FOREIGN KEY (tendangnhap) REFERENCES NGUOIDUNG(tendangnhap) 
);

CREATE TABLE NHANVIEN (
    manv char(4) NOT NULL PRIMARY KEY, -- Khóa chính
    tendangnhap VARCHAR(50) NOT NULL, -- Khóa ngoại
    Hoten NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15),
    Chucvu NVARCHAR(100),
    Anhdaidien TEXT,
    Sonha NVARCHAR(50),
    Duong NVARCHAR(100),
    Quan NVARCHAR(100),
    Thanhpho NVARCHAR(100),
    CONSTRAINT FK_NHANVIEN_NGUOIDUNG FOREIGN KEY (tendangnhap) REFERENCES NGUOIDUNG(tendangnhap) 
);



CREATE TABLE DANHMUCSP (
    madm char(4) PRIMARY KEY NOT NULL,
    Tendanhmuc NVARCHAR(255) NOT NULL,
    mota Nvarchar(1000)
);

CREATE TABLE SANPHAM (
    masp char(4) PRIMARY KEY NOT NULL,
    tensp NVARCHAR(255) NOT NULL,
    dongia INT NOT NULL,
    mota Nvarchar(1000),
    tinhtrang nvarchar(30) CHECK (tinhtrang IN (N'Đang hiển thị', N'Hết hàng', N'Ẩn')) NOT NULL,
    hinhchinh TEXT,
     madm CHAR(4) ,
    FOREIGN KEY (madm) REFERENCES DANHMUCSP(madm)

);
CREATE TABLE DONHANG (
    madonhang char(4)  PRIMARY KEY NOT NULL,
    ngaydat DATE NOT NULL,
    trangthai nvarchar(30) CHECK (trangthai IN (N'Đang đóng gói', N'Đang chờ xác nhận', N'Giao hàng thành công',  N'Đang giao hàng')) NOT NULL,
    tongtien INT NOT NULL,
    matv char(4) not null,
    FOREIGN KEY (matv) REFERENCES THANHVIEN(matv) 
);

-- Table: CHITIETDONHANG
CREATE TABLE CHITIETDONHANG (
    madonhang char(4) not null,
    masp char(4) not null,
    soluong INT NOT NULL,
    PRIMARY KEY (madonhang, masp),
    FOREIGN KEY (madonhang) REFERENCES DONHANG(madonhang) ,
    FOREIGN KEY (masp) REFERENCES SANPHAM(masp) 
);

-- Table: GIOHANG
CREATE TABLE GIOHANG (
    magh char(4) PRIMARY KEY NOT NULL,
    ngaythem DATE NOT NULL
);

-- Table: CHITIETGIOHANG
CREATE TABLE CHITIETGIOHANG (
    magh char(4) not null,
    masp char(4) not null,
    soluong INT NOT NULL,
    hinhanhsp TEXT,
    PRIMARY KEY (magh, masp),
    FOREIGN KEY (magh) REFERENCES GIOHANG(magh) ON DELETE CASCADE,
    FOREIGN KEY (masp) REFERENCES SANPHAM(masp) ON DELETE CASCADE
);

-- Table: DANHGIA
CREATE TABLE DANHGIA (
    madanhgia char(4) not null PRIMARY KEY ,
    matv char(4) not null,
    masp char(4) not null,
    noidung Nvarchar(1000),
    xepsao INT CHECK (xepsao BETWEEN 1 AND 5),
    FOREIGN KEY (matv) REFERENCES THANHVIEN(matv) ,
    FOREIGN KEY (masp) REFERENCES SANPHAM(masp)
);



INSERT INTO NGUOIDUNG (tendangnhap, matkhau, loainguoidung)
VALUES
('thanhvy_sales', 'password123', 'Admin'),
('ngocnhi_sales', 'password123', 'Admin'),
('danghai_sales', 'password123', 'Admin'),
('anhtran_manager', 'password123', 'Admin'),
('haivo_manager', 'password123', 'Admin'),
('cobexinhxan', '12345@678', 'Khách hàng'),
('traitimbanggia', '12345678@', 'Khách hàng'),
('hoangtulanhlung', '98765@432', 'Khách hàng'),
('toidangoday', '44334332dmnmc', 'Khách hàng'),
('mnmnmn2929', 'password5', 'Khách hàng'),
('xinhxanlamquen', 'dkksms02@', 'Khách hàng'),
('muahahahaa', '120504@2004', 'Khách hàng'),
('xuanhathudong123', 'donghathuxuan@', 'Khách hàng'),
('xinchaoban0202', 'password9', 'Khách hàng'),
('user10', 'password10', 'Khách hàng');

INSERT INTO NHANVIEN (manv, tendangnhap, Hoten, SDT, Chucvu, Anhdaidien, Sonha, Duong, Quan, Thanhpho)
VALUES
('NV01', 'thanhvy_sales', N'Nguyễn Thanh Vy', '0911111111', N'Sales', 'images/admin001.png', N'12A', N'Trần Phú', N'Hai Bà Trưng', N'Thành Phố Hồ Chí Minh'),
('NV02', 'ngocnhi_sales', N'Trần Ngọc Nhi', '0922222222', N'Sales', 'images/admin002.png', N'45B', N'Lê Lợi', N'Hoàn Kiếm', N'Thành Phố Hồ Chí Minh'),
('NV03', 'danghai_sales', N'Phạm Đăng Hải', '0933333333', N'Sales', 'images/admin003.png', N'78C', N'Nguyễn Trãi', N'Thanh Xuân', N'Thành Phố Hồ Chí Minh'),
('NV04', 'anhtran_manager', N'Trần Ngọc Ánh', '0944444444', N'Quản lý', 'images/admin004.png', N'101D', N'Tôn Đức Thắng', N'Ba Đình', N'Thành Phố Hồ Chí Minh'),
('NV05', 'haivo_manager', N'Võ Văn Hải', '0955555555', N'Quản lý', 'images/admin005.png', N'202E', N'Kim Mã', N'Cầu Giấy', N'Thành Phố Hồ Chí Minh');

-- Thêm dữ liệu vào bảng THANHVIEN
INSERT INTO THANHVIEN (matv, tendangnhap, Hoten, SDT, Email, Sonha, Duong, Quan, ThanhPho)
VALUES
('TV01', 'cobexinhxan', N'Nguyễn Văn A', '0912345678', 'user1@example.com', N'12/3', N'Trần Phú', N'Hai Bà Trưng', N'Thành Phố Hồ Chí Minh'),
('TV02', 'traitimbanggia', N'Trần Thị B', '0923456789', 'user2@example.com', N'45A', N'Lê Lợi', N'Đống Đa', N'Thành Phố Hồ Chí Minh'),
('TV03', 'hoangtulanhlung', N'Phạm Văn C', '0934567890', 'user3@example.com', N'789/12', N'Nguyễn Trãi', N'Thanh Xuân', N'Thành Phố Hồ Chí Minh'),
('TV04', 'toidangoday', N'Nguyễn Thị D', '0945678901', 'user4@example.com', N'101/10', N'Tôn Đức Thắng', N'Đống Đa', N'Hà Nội'),
('TV05', 'mnmnmn2929', N'Hoàng Văn E', '0956789012', 'user5@example.com', N'202/10', N'Kim Mã', N'Ba Đình', N'Bình Dương'),
('TV06', 'xinhxanlamquen', N'Lê Thị F', '0967890123', 'user6@example.com', N'303/10', N'Dê La Thành', N'Đống Đa', N'Hà Nội'),
('TV07', 'muahahahaa', N'Nguyễn Văn G', '0978901234', 'user7@example.com', N'404/12', N'Hai Bà Trưng', N'Hoàn Kiếm', N'Vĩnh Long'),
('TV08', 'xuanhathudong123', N'Trần Văn H', '0989012345', 'user8@example.com', N'505/14', N'Nguyễn Chí Thanh', N'Đống Đa', N'Thành phố Hồ Chí Minh'),
('TV09', 'xinchaoban0202', N'Phạm Thị I', '0990123456', 'user9@example.com', N'606B', N'Trung Hòa', N'Cầu Giấy', N'Bình Dương'),
('TV10', 'user10', N'Hoàng Thị J', '0901234567', 'user10@example.com', N'707/3A', N'Phạm Hùng', N'Nam Từ Liêm', N'Bình Thuận');


-- Insert data into DANHMUCSP
INSERT INTO DANHMUCSP (madm, Tendanhmuc, Mota) VALUES
('DM01', N'Kẹp vuông', N'Thuần khiết và thanh lịch'),
('DM02', N'Kẹp nhỏ', N'Bùng nổ phong cách và tỏa sáng chất riêng'),
('DM03', N'Kẹp tròn', N'Quyến rũ và nổi bật như chính bạn'),
('DM04', N'Gương', N'Phản chiếu chính mình, yêu thương trọn vẹn');

-- Insert data into SANPHAM
INSERT INTO SANPHAM (masp, tensp, dongia, mota, tinhtrang, hinhchinh, madm) VALUES
('SP01', N'Kẹp bí ẩn đêm đen', '98000', N'Kẹp vuông màu đen bí ẩn', N'Đang hiển thị', 'product5.1.png', 'DM01'),
('SP02', N'Kẹp tinh tú mơ màng', '140000', N'Kẹp vuông màu trắng tinh tú', N'Đang hiển thị', 'product6.1.png', 'DM01'),
('SP03', N'Kẹp trái tim rực rỡ', '60000', N'Kẹp nhỏ hình trái tim', N'Đang hiển thị', 'product7.1.png', 'DM02'),
('SP04', N'Kẹp ánh trăng lấp lánh', '50000', N'Kẹp nhỏ ánh trăng tím', N'Đang hiển thị', 'product9.1.png', 'DM02'),
('SP05', N'Gương lọ lem', '200000', N'Gương thiết kế cổ tích', N'Đang hiển thị', 'product11.1.png', 'DM04'),
('SP06', N'Gương sa mạc vàng', '200000', N'Gương màu vàng sang trọng', N'Đang hiển thị', 'product10.1.png', 'DM04'),
('SP07', N'Kẹp Cherry Ngọt Ngào', '130000', N'Họa tiết cherry xinh yêu', N'Đang hiển thị', 'product3.1.png', 'DM03'),
('SP08', N'Kẹp Hoa Sứ Xinh Xắn', '60000', N'Kẹp hoa sứ sang trọng', N'Đang hiển thị', 'product2.1.png', 'DM03'),
('SP09', N'Kẹp martini', '60000', N'Kẹp nhỏ màu cam', N'Đang hiển thị', 'martini2.jpg', 'DM02'),
('SP10', N'Kẹp pink lady', '60000', N'Kẹp nhỏ màu hồng', N'Đang hiển thị', 'pinklady2.jpg', 'DM02'),
('SP11', N'Set alcoholicity', '95000', N'Set kẹp và phụ kiện độc đáo', N'Đang hiển thị', 'alcoholicity.jpg', 'DM01'),
('SP12', N'Set urban chic', '95000', N'Set kẹp phong cách đô thị', N'Đang hiển thị', 'urbanxmas.jpg', 'DM01');

-- Insert data into DONHANG
-- Insert data into DONHANG
INSERT INTO DONHANG (madonhang, ngaydat, trangthai, tongtien, matv) VALUES
('DH01', '2024-12-01', N'Đang đóng gói', '400000', 'TV01'),
('DH02', '2024-12-02', N'Giao hàng thành công', '150000', 'TV03'),
('DH03', '2024-12-03', N'Đang chờ xác nhận', '73000', 'TV05'),
('DH04', '2024-12-04', N'Đang giao hàng', '98000', 'TV02'),
('DH05', '2024-12-05', N'Giao hàng thành công', '150000', 'TV09'),
('DH06', '2024-12-06', N'Đang đóng gói', '62000', 'TV06'),
('DH07', '2024-12-07', N'Giao hàng thành công', '109000', 'TV10');

-- Insert data into CHITIETDONHANG
INSERT INTO CHITIETDONHANG (madonhang, masp, soluong) VALUES
('DH01', 'SP01', '2'),
('DH01', 'SP03', '1'),
('DH02', 'SP05', '1'),
('DH03', 'SP10', '1'),
('DH04', 'SP01', '1'),
('DH05', 'SP05', '1'),
('DH06', 'SP08', '1'),
('DH07', 'SP02', '1');

-- Insert data into CHITIETDONHANG
INSERT INTO CHITIETDONHANG (madonhang, masp, soluong) VALUES
('DH01', 'SP01', '2'),
('DH01', 'SP03', '1'),
('DH02', 'SP05', '1'),
('DH03', 'SP10', '1'),
('DH04', 'SP01', '1'),
('DH05', 'SP05', '1'),
('DH06', 'SP08', '1'),
('DH07', 'SP02', '1');

-- Insert data into GIOHANG
INSERT INTO GIOHANG (magh, ngaythem) VALUES
('GH01', '2024-12-01'),
('GH02', '2024-12-02'),
('GH03', '2024-12-03'),
('GH04', '2024-12-04'),
('GH05', '2024-12-05');

-- Insert data into CHITIETGIOHANG
INSERT INTO CHITIETGIOHANG (magh, masp, soluong, hinhanhsp) VALUES
('GH01', 'SP01', '1', 'hinh1.jpg'),
('GH01', 'SP02', '1', 'hinh2.jpg'),
('GH02', 'SP04', '2', 'hinh4.jpg'),
('GH03', 'SP10', '1', 'hinh10.jpg'),
('GH04', 'SP01', '1', 'hinh1.jpg'),
('GH05', 'SP08', '1', 'hinh8.jpg');

-- Insert data into DANHGIA
INSERT INTO DANHGIA (madanhgia, matv, masp, noidung, xepsao) VALUES
('DG01', 'TV01', 'SP01', N'Sản phẩm rất đẹp và chất lượng!', '5'),
('DG02', 'TV05', 'SP05', N'Gương thiết kế tinh tế, rất hài lòng.', '4'),
('DG03', 'TV04', 'SP10', N'Kẹp rất dễ thương!', '5'),
('DG04', 'TV06', 'SP01', N'Hàng ổn, giao đúng thời gian.', '4'),
('DG05', 'TV02', 'SP08', N'Sản phẩm đẹp, chất lượng tốt.', '5');

