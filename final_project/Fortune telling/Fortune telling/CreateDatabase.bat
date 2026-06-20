@echo off
REM Post-Build Event Script - 用於在編譯時建立空的 mdb 數據庫檔案

setlocal enabledelayedexpansion

set DataDir=%~dp0Data
set DbFile=%DataDir%\fortunetelling.mdb

REM 建立 Data 資料夾
if not exist "%DataDir%" (
	mkdir "%DataDir%"
	echo Created Data directory: %DataDir%
)

REM 如果檔案不存在，則建立空的 mdb 檔案
if not exist "%DbFile%" (
	REM 使用 Windows 內建的 ADOX 來建立 Access 資料庫
	powershell -Command "^
	$conn = New-Object -ComObject ADODB.Connection; ^
	$conn.Create('Provider=Microsoft.Jet.OLEDB.4.0;Data Source=%DbFile%'); ^
	$conn.Close(); ^
	Write-Host 'Created database: %DbFile%'
	"
)

echo Post-Build: Database initialization complete
