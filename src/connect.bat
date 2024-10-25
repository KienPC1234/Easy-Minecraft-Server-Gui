@echo off
setlocal

REM Đường dẫn đến file codezrok.tmp trong thư mục tạm
set "tmpFile=%TEMP%\codezrok.tmp"

REM Đọc mã từ file
for /f "delims=" %%i in (%tmpFile%) do set "accessCode=%%i"

REM Chạy zrok.exe với mã
start zrok.exe access private %accessCode%

endlocal
