# Quản Lý Khách Sạn (223277_DoanVinhHung)

Ứng dụng WinForms mẫu dùng để quản lý khách hàng, phòng, đặt phòng và sử dụng dịch vụ.

## Mô tả
- Ứng dụng được phát triển bằng .NET (WinForms).
- Bao gồm các form chính: quản lý phòng (`frmPhong`), quản lý khách hàng (`frmKhachHang`), đặt phòng (`frmDatPhong`), sử dụng dịch vụ (`frmSuDungDV`).

## Tính năng chính
- Thêm / sửa / xóa khách hàng.
- Quản lý phòng (trạng thái, loại phòng).
- Đặt phòng và quản lý đặt phòng.
- Ghi nhận sử dụng dịch vụ cho từng khách.

## Yêu cầu
- Windows 10/11
- .NET Framework phù hợp (kiểm tra target framework trong `223277_DoanVinhHung.csproj`).
  - Nếu project target .NET Framework (ví dụ 4.7.2), máy người dùng cần cài .NET Framework tương ứng.
- Visual Studio (nếu muốn build từ source) hoặc chỉ cần file exe trong `bin\Release` để chạy.

## Cách build (máy có Visual Studio / Build Tools)
1. Mở Visual Studio, chọn cấu hình `Release` → Build → Build Solution.

Hoặc dùng PowerShell + MSBuild (ví dụ khi có Visual Studio Build Tools):

```powershell
& 'C:\Program Files\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\MSBuild.exe' 'd:\FullStack\File đã học\LT.Net\QuanLyKhachSan\223277_DoanVinhHung\223277_DoanVinhHung\223277_DoanVinhHung.csproj' /p:Configuration=Release
```

Sau khi build xong, file thực thi sẽ nằm trong `bin\Release`.

## Chạy ứng dụng
- Chạy `bin\Release\223277_DoanVinhHung.exe` trên máy có .NET Framework tương thích.
- Nếu thiếu runtime, cài .NET Framework hoặc .NET Desktop Runtime tương ứng từ trang chính thức của Microsoft.

## Tạo gói release để chia sẻ
1. Gói ZIP nhanh:

```powershell
Compress-Archive -Path 'bin\Release\*' -DestinationPath 'QuanLyKhachSan-v1.0.zip'
```
Upload file ZIP lên GitHub Releases / Google Drive / Dropbox và chia sẻ link.

2. ClickOnce (publish trực tiếp từ Visual Studio):
- Visual Studio → Project → Publish → Chọn folder/URL → Publish. ClickOnce tạo installer và hỗ trợ cập nhật tự động.

3. Tạo installer chuyên nghiệp:
- Dùng Inno Setup hoặc WiX để tạo `setup.exe`/MSI (tự động tạo shortcut, thêm registry, kèm runtime nếu cần).
- MSIX để publish lên Microsoft Store (nâng cao).

4. Code signing (tuỳ chọn):
- Ký số file installer/exe để tránh cảnh báo SmartScreen và tăng độ tin cậy.

## Đưa dự án vào portfolio (gợi ý)
1. Tạo repository trên GitHub và push source (loại trừ `bin/`, `obj/`, `*.user`, `*.vs/` bằng `.gitignore`).

Ví dụ lệnh Git (PowerShell):

```powershell
git init
git add .
git commit -m "Initial commit"
git branch -M main
git remote add origin https://github.com/<username>/QuanLyKhachSan.git
git push -u origin main
```

2. Tạo GitHub Release và upload file ZIP hoặc installer để người xem có thể tải.
3. Trong `README.md` repo: thêm mô tả ngắn, hướng dẫn chạy, ảnh chụp màn hình (`screenshots/`), video demo (YouTube) và thông tin tech stack.
4. Viết phần "Vai trò của tôi" (nêu rõ bạn làm gì trong project) trên trang portfolio cá nhân.

## Kiểm tra trước khi public
- Chạy file exe trên một máy khác (không có Visual Studio) để kiểm tra thiếu runtime hoặc thiếu file cấu hình.
- Đảm bảo tập tin cấu hình (`app.config`/`exe.config`) đi kèm nếu cần.

## Các tài nguyên bổ sung (gợi ý)
- Inno Setup: https://jrsoftware.org/isinfo.php
- WiX Toolset: https://wixtoolset.org/
- Hướng dẫn ClickOnce trong Visual Studio: tra cứu trong tài liệu Microsoft.

## Liên hệ
- Nếu cần, tôi có thể: tạo `.gitignore` phù hợp, viết hướng dẫn release chi tiết, hoặc tạo sẵn GitHub Release và file ZIP.

---

(Cấu trúc file dựa trên nội dung hiện có trong thư mục dự án. Sửa `Yêu cầu` nếu bạn biết chính xác phiên bản .NET target.)
