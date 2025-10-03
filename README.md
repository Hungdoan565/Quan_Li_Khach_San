# Quản Lý Khách Sạn

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
- Hệ điều hành: Windows 10/11.
- .NET Framework hoặc .NET Desktop Runtime phù hợp với target framework của project. Kiểm tra thông tin target trong file `*.csproj`.
- Nếu muốn build từ source: Visual Studio hoặc Visual Studio Build Tools.

## Cách build
1. Mở project bằng Visual Studio → chọn cấu hình `Release` → Build → Build Solution.

Hoặc dùng PowerShell + MSBuild (nếu dùng Build Tools):

```powershell
# Thay <PathToProject.csproj> bằng đường dẫn tới file .csproj của bạn
& 'C:\Program Files\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\MSBuild.exe' '<PathToProject.csproj>' /p:Configuration=Release
```

Sau khi build, file thực thi sẽ nằm trong thư mục `bin\Release` của project (ví dụ `QuanLyKhachSan.exe`).

## Chạy ứng dụng
- Mở `bin\Release\<YourApp>.exe` trên máy có runtime tương thích.
- Nếu thiếu runtime, tải và cài đặt .NET Framework / .NET Desktop Runtime tương ứng từ trang chính thức của Microsoft.

## Tạo gói release để chia sẻ
- Gói ZIP nhanh:

```powershell
Compress-Archive -Path 'bin\Release\*' -DestinationPath 'QuanLyKhachSan-v1.0.zip'
```

- ClickOnce: Visual Studio → Project → Publish → Chọn folder/URL → Publish. Phù hợp nếu muốn auto-update.

- Installer chuyên nghiệp: dùng Inno Setup hoặc WiX để tạo `setup.exe`/MSI (có thể đóng gói runtime nếu cần).

- MSIX: để publish lên Microsoft Store (tùy nhu cầu).

- Ký số (code signing) installer/exe là lựa chọn có lợi cho phân phối rộng.

## Đưa dự án lên GitHub / Portfolio
1. Thêm `.gitignore` cho Visual Studio (loại trừ `bin/`, `obj/`, file cá nhân, v.v.).
2. Tạo repository công khai và push source để cộng đồng có thể clone và đóng góp.

Ví dụ (thay `<repo-url>` bằng URL repo của bạn):

```powershell
git init
git add .
git commit -m "Initial commit"
git branch -M main
git remote add origin <repo-url>
git push -u origin main
```

3. Tạo GitHub Release và upload file ZIP hoặc installer.
4. Trong `README.md` repo nên có:
   - Mô tả ngắn, hướng dẫn chạy.
   - Ảnh chụp màn hình trong thư mục `screenshots/`.
   - Link tới video demo (nếu có).
   - Thông tin công nghệ và hướng dẫn đóng góp (Contributing).
   - Ghi rõ license nếu muốn cho phép cộng đồng dùng / sửa đổi.

## Kiểm tra trước khi public
- Thử chạy trên máy khác (không có Visual Studio) để kiểm tra thiếu runtime hoặc file cấu hình.
- Đảm bảo file cấu hình (`app.config` / `*.exe.config`) và tài nguyên (hình ảnh, database mẫu) đi kèm nếu cần.

## Gợi ý cho repo cộng đồng
- Thêm tệp `CONTRIBUTING.md` hướng dẫn cách mở issue, pull request và coding style.
- Thêm `LICENSE` (ví dụ MIT) nếu muốn cấp phép rõ ràng cho người khác sử dụng.
- Tạo các release có tag để người dùng dễ tải phiên bản ổn định.

## Tài nguyên
- Inno Setup: https://jrsoftware.org/isinfo.php
- WiX Toolset: https://wixtoolset.org/
- Tài liệu ClickOnce: Microsoft docs

---

Nếu muốn, tôi có thể:
- Tạo sẵn `.gitignore` cho Visual Studio.
- Thêm mẫu `CONTRIBUTING.md` và `LICENSE`.
- Hướng dẫn chi tiết tạo installer bằng Inno Setup.
