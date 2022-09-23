# JPFigure
Đồ án SE347
Ứng dụng bán mô hình đồ chơi Nhật Bản

## Yêu cầu
Ứng dụng này sử dụng postgresql để quản lý CSDL.

Tải postgresql tại đây: https://www.postgresql.org/download/ 

**!! Lưu ý khi cài postgresql, đặt username và password cho superuser là 'postgres' để ứng dụng có thể chạy được, nếu không thì phải tự sửa lại connection string của chương trình trong file "appsettings.json"!!**
 

## Setup
1. Clone repository: chạy `git clone https://github.com/yyyanhkhoa/Salary-management.git` và `cd Salary-management`

2. cài dependency packages: chạy `dotnet restore`

3. thiết lập CSDL trên máy: run `dotnet ef database update`

4. Build và chạy ứng dụng
