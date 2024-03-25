Đề tài: WEBSITE CHO THUÊ XE 
MỤC ĐÍCH: WEBSITE cho phép người dùng thuê xe từ công ty để di chuyển, du lịch cá nhân.
Xe có 4,7,9,11,16 ghế.
CSDL cơ bản:
•	Đối tượng (case studio)
BANGLAI:MABANG (
+ NHANVIENTHUNGAN ( 5 người mẫu giả) :MANV,HO,LOT,TEN,GIOITINH,TUOI,NGAYSINH,SDT,SONHA,DUONG/AP,CCCD,CHUCVU
+TAIKHOANNHANVIEN:MATK,TENTAIKHOAN,MATKHAU
+ KHACHHANG ( 5 người mẫu giả): MAKH,HỌ,LÓT,TÊN,GIOITINH,TUOI,NGAYSINH,SDT,EMAIL,SONHA,DUONG/AP,PHUONG/XA,THANHPHO/TINH,QUOCGIA,ANHCCCD,ANHDAODIEN,ANHBANGLAI,THOIGIANCUOIDANGNHAP,SOLANDANGNHAP
+TAIKHOANKHACHHANG:MATK,TENTAIKHOAN,MATKHAU
+TAIXE (10 người mẫu giả): MATX,HO,LOT,TEN,GIOITINH,TUOI,NGAYSINH,SDT,SONHA,DUONG/AP,QUOCGIA,ANHCCCD,ANHBANGLAI,ANHDAIDIEN,BANGLAI
+TAIKHOANTAIXE:MATK,TENTAIKHOAN,MATKHAU
+NHANVIENBAIXE (5 người mẫu giả):  MANVBX,LOT,TEN,GIOITINH,TUOI,NGAYSINH,SDT,SONHA,DUONG/AP,QUOCGIA,ANHDAIDIEN
•	VAT THE
+ HANG XE: MAHANG,TENHANG (honda,..)
+LOAI: MALOAI, TENLOAI (SUV,MIni...)
+SOGHE:MASL,SOLUONG (4,7,9,11,16)
+NHIENLIEU:MANHIENLIEU,TENNHIENLIEU (xăng,diện,dầu)
+TINHTRANG:MATT,TENTT (Đã thuê,Đang sử lý,Hoạt động,Đang bảo trì)
+ DONVITI: MADV,TENDV (NGAY,THANG,NAM)
+XE (40 mẫu xe hoặc hơn thì càng tốt có, mỗi hãng ít nhất 4 – 5 xe, và ít nhất 2 – 3 màu): MASXE,TENXE,NHIENLIEU,MAUSAC,NSX,SOKMDADI,TINHTRANG,LUOTTHUE,DANHGIA,DONGIA,DONVITINH 
•	Phiếu
+ PHIEUDATXE:MAPDX,NGAYDAT,TiENCOC,NOIDUNG,DIADIEM
+PHIEUBAODUONG: MAPBD,NGAYNHAN,TONGTIENBAODUONG
+PHIEUBAOHIEM:MAPBH,MAKH,MAXE,NGAYNHAN
+PHIEUDENBU:MAPHDB,MAXE
+HOADON:
•	CHITIETPHIEU
+CTTHUEXE : TAIXE(mặc định là “Có”),NGAYTHUE,NGAYTRA
+CTBAOTRI: NOIDUNGBAOTRI,TENBAOTRI
+CTDENBU:NOIDUNG, TIENPHAT
Ý tưởng:
Chức năng.
-	Khách hàng được 2 triệu tiền bảo hiểm lần đầu tạo tài khoản trong suốt quá trình thuê xê (có thể dùng hoặc không tùy khách hàng) chỉ sự dụng duy nhất một lần cho một xe,  khách hàng phải đặt cọc 15 triệu mỗi chiếc xe thuê và mặc định có tài xế, chỉ cho thuê tối đa 14 ngày, nếu trả xe trễ phải tính theo ngày thuê.
-	Công ty có nhiều nhân viên bao gồm nhân viên thu ngân, nhân viên bãi xe, tài xế
-	Mỗi nhân viên đều có tài khoản riêng
-	Nhân viên thu ngân kiểm tra số tiền đặt cọc của khách hoặc tiền bảo hiểm xe chon khách hàng, kiểm tra gplt, phiếu đăng ký, phiếu bảo hiểm
-	Nhân viên bãi xe kiểm tra số lượng xe, bảo trì, kế phiếu đền bù cho khách hàng (nếu có), có thể bảo trì nhiều xe trên 1 phiếu, kac
-	Tài xề nhận đơn lái xe từ khách hàng
-	Khách hàng phải đăng ký tài khoản mới có thể đặt xe, khách hàng có thể đặt nhiều xe cùng lúc, nếu muốn tự lái khách hàng phải cập nhật gplx và cccd, và chỉ một chiếu xe có thể tự lái (kiểm tra bằng lái có phù hợp với loại xe không) , 
Wesite:
-	Head và Footer chung một file html:
+ Head: logo, thanh tìm kiếm, đăng nhập, menu - đăng nhập, dịch vụ,đăng ký, xe đang đặt,lich sự thanh toan, giới thiệu,
+ footer : đỉa chi công ty, các logo hãng xe,... (có thể tìm thêm)
-	Body nằm ở các file html khác nhau vd: body index, body hóa đơn, body đăng nhập,...
+ index: danh sách xe gồm 3 cột 10 hàng có các trang 1,2... (mẫu 2 – 3 chiếc xe thôi), trên sản phẩm có trạng thái sản phẩm, có nút đặt ngay, thêm vào danh sách, tên xe, hình ảnh xe
+ hóa đơn : làm dạng thanh cuộn,  
+ chi tiết san phẩm: hình ảnh xe, tên xe,hãng xe, loại nguyên liệu , số lượng còn lại, màu sắc, có nút màu sắc ảnh sẻ đổi sang xe màu đó.
+ đăng nhập: tên đăng nhập( số điện thoại) , mật khẩu, nút đăng nhập, nút quên mật khẩu
+ đăng ký: tên khách hàng, số điện thoại, giới tính, email, cccd, ảnh cccd, bang lai, ảnh bằng lái...
+ lịch sử thanh toán
+ xe đang đặt: 
+trang quên mật khảu
+ trang thông tin tài khoản: có ảnh, thông tin khách hàng
+ trang cập nhật tài khoản: lấy giống trang thông tin, không thể cập nhật cccd, 
+ Trang giới thiệu: chém gió
Thuật toán (khải làm)
	+ tạo trang admin cho nhân viên thu ngân, tài xế, nhân viên bảo xe
	+ được sản phẩm lên website
	+ sự lý số lượng, trạng thái xe,...
	+ sự lý hóa đơn khách hàng
	+ sự lý cập nhật tài khoản, xe
	+sự lý đền bù, bảo hiểm

	
