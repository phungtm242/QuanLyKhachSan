create database ql_khachsan
go

use ql_khachsan
go

create table khachhang(
	makh varchar(100) primary key,
	tenkh nvarchar(100),
	gtinh bit,
	cmnd int,
	sdt int,
	email varchar(100)
)
go

create table quanly(
	maquanly varchar(100) primary key,
	tenquanly nvarchar(100),
	gtinh bit
)

create table vitri(
	mavitri varchar(100) primary key,
	bophan varchar(100),
	tenvitri varchar(100),
	maquanly varchar(100)
)

create table nhanvien(
	manv varchar(100) primary key,
	tennv nvarchar(100),
	gtinh bit,
	ngaysinh datetime,
	mavitri varchar(100),
	ngayvao datetime,
	cmnd int,
	diachi varchar(100),
	sdt int
)
go

create table phong(
	maphong varchar(100) primary key,
	tenphong nvarchar(100),
	loaiphong varchar(100),
	giaphong int
)
go

create table dichvu(
	madv varchar(100) primary key,
	tendv nvarchar(100),
	giadv int
)
go

create table hoadon(
	mahd varchar(100) primary key,
	thoigian datetime,
	makh varchar(100),
	tong int,
	loaitt varchar(100),
	matour varchar(100)
)
go

create table datphong(
	madatphong varchar(100) primary key,
	maphong varchar(100),
	makh varchar(100),
	tgnhanphong datetime,
	tgtradukien datetime,
	tgtraphong datetime,
	tiencoc int,
	matour varchar(100),
	letan varchar(100),
	thungan varchar(100)
)
go

create table sddv(
	masd int primary key identity(1,1),
	madv varchar(100),
	soluong int,
	madatphong varchar(100),
	thoigian datetime
)
go

create table tour(
	matour varchar(100) primary key,
	tentour nvarchar(100),
	tgbatdau datetime,
	tgketthuc datetime,
	songuoi int,
	giatour int,
	dandoan varchar(100),
	trangthai varchar(100)
)
go

create table dattour(
	madattour varchar(100) primary key,
	matour varchar(100),
	makh varchar(100),
	ngaydat varchar(100)
)
go

ALTER TABLE vitri
ADD CONSTRAINT fk_vitri_quanly
FOREIGN KEY (maquanly) REFERENCES quanly(maquanly);
go 

ALTER TABLE nhanvien
ADD CONSTRAINT fk_nhanvien_vitri
FOREIGN KEY (mavitri) REFERENCES vitri(mavitri);
go

ALTER TABLE hoadon
ADD CONSTRAINT fk_hoadon_khachhang
FOREIGN KEY (makh) REFERENCES khachhang(makh);
go

ALTER TABLE hoadon
ADD CONSTRAINT fk_hoadon_tour
FOREIGN KEY (matour) REFERENCES tour(matour);
go

ALTER TABLE datphong
ADD CONSTRAINT fk_datphong_phong
FOREIGN KEY (maphong) REFERENCES phong(maphong);
go

ALTER TABLE sddv
ADD CONSTRAINT fk_sddv_datphong
FOREIGN KEY (madatphong) REFERENCES datphong(madatphong);
go

ALTER TABLE sddv
ADD CONSTRAINT fk_sddv_dichvu
FOREIGN KEY (madv) REFERENCES dichvu(madv);
go

ALTER TABLE tour
ADD CONSTRAINT fk_tour_nhanvien
FOREIGN KEY (dandoan) REFERENCES nhanvien(manv);
go

ALTER TABLE datphong
ADD CONSTRAINT fk_datphong_tour
FOREIGN KEY (matour) REFERENCES tour(matour);
go

ALTER TABLE datphong
ADD CONSTRAINT fk_datphong_khachhang
FOREIGN KEY (makh) REFERENCES khachhang(makh);
go

ALTER TABLE datphong
ADD CONSTRAINT fk_datphong_nhanvien_letan
FOREIGN KEY (letan) REFERENCES nhanvien(manv);
go

ALTER TABLE datphong
ADD CONSTRAINT fk_datphong_nhanvien_thungan
FOREIGN KEY (thungan) REFERENCES nhanvien(manv);
go

ALTER TABLE dattour
ADD CONSTRAINT fk_dattour_tour
FOREIGN KEY (matour) REFERENCES tour(matour);
go

ALTER TABLE dattour
ADD CONSTRAINT fk_dattour_khachhang
FOREIGN KEY (makh) REFERENCES khachhang(makh);
go


-- Them du lieu co ban
insert into phong(maphong, tenphong, loaiphong, giaphong) values
	('p101', N'Phòng 101', 'don', 100000),
	('p102', N'Phòng 102', 'don', 100000),
	('p103', N'Phòng 103', 'don', 100000),
	('p104', N'Phòng 104', 'don', 100000),
	('p105', N'Phòng 105', 'don', 100000),
	('p106', N'Phòng 106', 'don', 100000),
	('p201', N'Phòng 201', 'don', 100000),
	('p202', N'Phòng 202', 'don', 100000),
	('p203', N'Phòng 203', 'don', 100000),
	('p204', N'Phòng 204', 'don', 100000),
	('p205', N'Phòng 205', 'don', 100000),
	('p206', N'Phòng 206', 'don', 100000),
	('p301', N'Phòng 301', 'don', 100000),
	('p302', N'Phòng 302', 'don', 100000),
	('p303', N'Phòng 303', 'don', 100000),
	('p304', N'Phòng 304', 'don', 100000),
	('p305', N'Phòng 305', 'don', 100000),
	('p306', N'Phòng 306', 'don', 100000),
	('p107', N'Phòng 107', 'doi', 180000),
	('p108', N'Phòng 108', 'doi', 180000),
	('p109', N'Phòng 109', 'doi', 180000),
	('p110', N'Phòng 110', 'doi', 180000),
	('p111', N'Phòng 111', 'doi', 180000),
	('p112', N'Phòng 112', 'doi', 180000),
	('p207', N'Phòng 207', 'doi', 180000),
	('p208', N'Phòng 208', 'doi', 180000),
	('p209', N'Phòng 209', 'doi', 180000),
	('p210', N'Phòng 210', 'doi', 180000),
	('p307', N'Phòng 307', 'doi', 180000),
	('p308', N'Phòng 308', 'doi', 180000),
	('p309', N'Phòng 309', 'doi', 180000),
	('p310', N'Phòng 310', 'doi', 180000),
	('p401', N'Phòng 401', 'deluxe', 500000),
	('p402', N'Phòng 402', 'deluxe', 500000),
	('p403', N'Phòng 403', 'deluxe', 500000),
	('p404', N'Phòng 404', 'deluxe', 500000),
	('p405', N'Phòng 405', 'deluxe', 500000),
	('p406', N'Phòng 406', 'deluxe', 500000),
	('p407', N'Phòng 407', 'deluxe', 500000),
	('p408', N'Phòng 408', 'deluxe', 500000);
go

insert into quanly(maquanly, tenquanly, gtinh) values 
('qldl01','Quan ly du lich 01', 0),
('qldl02','Quan ly du lich 02', 1),
('qlks01','Quan ly khach san 01', 0);
go

insert into khachhang(makh, tenkh, gtinh, cmnd,  sdt, email) values 
('kht01', N'Nguyễn Thúy', 0, 31232345, 911112113, 'thuy@khachhang'),
('kht02', N'Nguyễn An', 1, 31232685, 921112113, 'thuy@khachhang'),
('kht03', N'Nguyễn Loan', 0, 31232355, 931112113, 'thuy@khachhang');
go

insert into vitri(mavitri, bophan, tenvitri, maquanly) values
('letan', 'khach san', N'Lễ Tân', 'qlks01'),
('thungan', 'khach san', N'Thu Ngân', 'qlks01'),
('donphong', 'khach san', N'Dọn Phòng', 'qlks01'),
('tvtour', 'khach san', N'Tiếp viên tour', 'qldl01');