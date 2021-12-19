--create database ql_khachsan
--go

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
