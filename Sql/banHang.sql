use master
go
Create database CSDLSieuThi
go
use CSDLSieuThi
go
create table TaiKhoan
(
	tenTaiKhoan varchar(30) not null primary key,
	matKhau varchar(20) not null,
	quyen nvarchar(10) not null,
)
go
insert into TaiKhoan values('longnv','1234',N'Quản lý')
insert into TaiKhoan values('duclh','1234',N'Nhân viên')
insert into TaiKhoan values('sangdh','1234',N'Nhân viên')

go
create table NhanVien
(
	maNhanVien int not null primary key IDENTITY(1,1),
	tenNhanVien nvarchar(50) not null,
	soDienThoai varchar(15) not null,
	chungMinhThu varchar(20) not null,
	tenTaiKhoan varchar(30),
	CONSTRAINT TK_NV FOREIGN KEY (tenTaiKhoan) REFERENCES TaiKhoan(tenTaiKhoan) on update cascade on delete cascade
)
GO
insert into NhanVien values(N'Nguyễn Văn Long','0969010998','122244567','longnv')
insert into NhanVien values(N'Lê Huỳnh Đức','0349010998','123444567','duclh')
insert into NhanVien values(N'Đinh Huy Sáng','0969010348','122244534','sangdh')

go
create table LoaiHang
(
	maLoaiHang int not null primary key IDENTITY(1,1),
	tenLoaiHang nvarchar(50) not null,
)
GO
insert into LoaiHang values(N'Thực phẩm đông lạnh')
insert into LoaiHang values(N'Hoa quả')
insert into LoaiHang values(N'Bánh kẹo')
insert into LoaiHang values(N'Mỹ phẩm')
insert into LoaiHang values(N'Sữa')
insert into LoaiHang values(N'Đồ gia dụng')
insert into LoaiHang values(N'Nước ngọt')
insert into LoaiHang values(N'Bia')
insert into LoaiHang values(N'Đồ khô')
insert into LoaiHang values(N'Đồ điện tử')
insert into LoaiHang values(N'Quần áo')
insert into LoaiHang values(N'Giày dép')

create table NhaCungCap
(
	maNhaCungCap int not null primary key IDENTITY(1,1),
	tenNhaCungCap nvarchar(50) not null,
	diaChi nvarchar(200) not null
)
GO
insert into NhaCungCap values(N'Hữu Nghị',N'Hà Nội')
insert into NhaCungCap values(N'Kinh Đô',N'Hà Nội')
insert into NhaCungCap values(N'Long Hải',N'Hồ Chí Minh')
insert into NhaCungCap values(N'Hoàng Lan',N'Hải Phòng')
insert into NhaCungCap values(N'Ajnomoto',N'Hà Nội')
insert into NhaCungCap values(N'Hòa Phát',N'Hưng Yên')
insert into NhaCungCap values(N'Thăng Long',N'Hà Nội')
insert into NhaCungCap values(N'Hải Hà',N'Bắc Ninh')
insert into NhaCungCap values(N'Ngân Hương',N'Bắc Giang')
insert into NhaCungCap values(N'Pepsi',N'Hà Nội')

go
create table Hang
(
	maHang int not null primary key IDENTITY(1,1),
	tenHang nvarchar(50) not null,
	donViTinh nvarchar(50) not null,
	donGia float not null,
	soLuongCon int not null,
	maLoaiHang int not null,
	maNhaCungCap int not null,
	CONSTRAINT Hang_LoaiHang FOREIGN KEY (maLoaiHang) REFERENCES LoaiHang(maLoaiHang) on update cascade on delete cascade,
	CONSTRAINT Hang_NCC FOREIGN KEY (maNhaCungCap) REFERENCES NhaCungCap(maNhaCungCap) on update cascade on delete cascade
	
)
GO
insert into Hang values(N'Twister',N'Việt Nam đồng',20000,100,7,10)
insert into Hang values(N'Cam ép',N'Việt Nam đồng',15000,100,7,10)
insert into Hang values(N'Coca',N'Việt Nam đồng',10000,100,7,10)
insert into Hang values(N'Thạch Dừa',N'Việt Nam đồng',20000,100,2,3)
insert into Hang values(N'Bánh rồng vàng',N'Việt Nam đồng',40000,100,3,1)
insert into Hang values(N'Bánh Bông Lan',N'Việt Nam đồng',50000,100,3,1)
insert into Hang values(N'Chocolate',N'Việt Nam đồng',60000,100,3,1)
insert into Hang values(N'Twister',N'Việt Nam đồng',20000,100,7,10)
insert into Hang values(N'Dao phay',N'Việt Nam đồng',25000,100,6,6)
insert into Hang values(N'Chảo chống dính',N'Việt Nam đồng',35000,100,6,6)
insert into Hang values(N'Chảo chống dính',N'Việt Nam đồng',59000,100,6,6)
go
create table LoaiKhachHang
(
	maLoaiKhachHang int not null primary key IDENTITY(1,1),
	tenLoaiKhachHang nvarchar(50) not null,
)
GO
insert into LoaiKhachHang values(N'Khách hàng mới')
insert into LoaiKhachHang values(N'Khách hàng cũ')
insert into LoaiKhachHang values(N'Khách hàng thường xuyên')
go
create table KhachHang
(
	maKhachHang int not null primary key IDENTITY(1,1),
	hoten nvarchar(50) not null,
	diaChi nvarchar(200) not null,
	soDienThoai varchar(15) not null,
	maLoaiKhachHang int not null,
	CONSTRAINT KhachHang_LoaiKhachHang FOREIGN KEY (maLoaiKhachHang) REFERENCES LoaiKhachHang(maLoaiKhachHang) on update cascade on delete cascade,
	
)
GO
insert into KhachHang values(N'Hoàng Thu Trang',N'Bắc Ninh','0969222000',1)
insert into KhachHang values(N'Hoàng Bắc',N'Tuyên Quang','0969222345',3)
insert into KhachHang values(N'Nguyễn Thị An',N'Bắc Ninh','0969222765',1)
insert into KhachHang values(N'Nông Văn Huy',N'Cao Bằng','0969222678',2)
insert into KhachHang values(N'Hứa Thanh Huy',N'Cao Bằng','0969222242',1)
insert into KhachHang values(N'Nguyễn Văn Thành',N'Gia Lai','0969222333',3)
insert into KhachHang values(N'Quách Tĩnh',N'Hà Nội','0969222000',3)
insert into KhachHang values(N'Hứa Huyền Trang',N'Bắc Ninh','0969222043',1)
insert into KhachHang values(N'Hà Văn Đạt',N'Hải Phòng','0969222066',1)
insert into KhachHang values(N'Nguyễn Minh Lăng',N'Bắc Ninh','0969222765',3)
insert into KhachHang values(N'Trần Văn Toàn',N'Thái Bình','0969222678',1)
insert into KhachHang values(N'Ngô Thị Phương',N'Bắc Giang','0969222654',3)
insert into KhachHang values(N'Nguyễn Thị Thư',N'Bắc Ninh','0969222045',2)
insert into KhachHang values(N'Nguyễn Bá An',N'Hà Tĩnh','0969222032',1)
insert into KhachHang values(N'Lương Văn Hà',N'Bắc Ninh','0969222023',1)
insert into KhachHang values(N'Hoàng Dung',N'Nam Định','0969222065',2)
go
create table HoaDon
(
	maHoaDon int not null primary key IDENTITY(1,1),
	ngayGioTao datetime not null,
	maKhachHang int not null,
	maNhanVien int not null,
	CONSTRAINT HoaDon_KhachHang FOREIGN KEY (maKhachHang) REFERENCES KhachHang(maKhachHang) on update cascade on delete cascade,
	CONSTRAINT HoaDon_NhanVien FOREIGN KEY (maNhanVien) REFERENCES NhanVien(maNhanVien) on update cascade on delete cascade
)
go
insert into HoaDon values('5-18-2021',1,1)
select * from HoaDon
go
create table ChiTietHoaDon
(
	maHang int not null,
	maHoaDon int not null,
	soLuong int not null,
	thanhTien float not null,
	PRIMARY KEY (maHang,maHoaDon),
	CONSTRAINT ChiTiet_Hang FOREIGN KEY (maHang) REFERENCES Hang(maHang) on update cascade on delete cascade,
	CONSTRAINT ChiTiet_HoaDon FOREIGN KEY (maHoaDon) REFERENCES HoaDon(maHoaDon) on update cascade on delete cascade
)
select * from ChiTietHoaDon
select * from HoaDon
go
insert into ChiTietHoaDon values(1,3,10,200000)
insert into ChiTietHoaDon values(2,3,20,300000)