@echo off
REM 手動建立空的 Access 資料庫檔案的步驟

REM 如果您的系統無法自動建立 .mdb 檔案，可以使用以下方法：

REM 方法1：使用 PowerShell 創建
REM 在 PowerShell 中執行以下命令：
REM $catalog = New-Object -ComObject ADOX.Catalog
REM $catalog.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=%cd%\Data\fortunetelling.mdb;")

REM 方法2：使用 Microsoft Access 手動建立
REM 1. 打開 Microsoft Access
REM 2. 建立新的空白資料庫
REM 3. 另存為 fortunetelling.mdb
REM 4. 將檔案放在 [專案]\Data\ 目錄下

REM 方法3：使用本批次檔案自動建立
setlocal enabledelayedexpansion

REM 確保 Data 目錄存在
if not exist "Data" mkdir Data

REM 使用 PowerShell 創建空 mdb 檔案
powershell -Command ^
"^
try { ^
	$catalog = New-Object -ComObject ADOX.Catalog; ^
	$dbPath = (Get-Location).Path + '\Data\fortunetelling.mdb'; ^
	$catalog.Create('Provider=Microsoft.Jet.OLEDB.4.0;Data Source=' + $dbPath + ';'); ^
	Write-Host '成功建立數據庫：' $dbPath; ^
	$catalog = $null; ^
} ^
catch { ^
	Write-Host '建立失敗：' $_.Exception.Message; ^
	Write-Host '請確保安裝了 Microsoft Access Database Engine'; ^
}"

REM 驗證檔案是否已建立
if exist "Data\fortunetelling.mdb" (
	echo 數據庫檔案已成功建立！
) else (
	echo 失敗：無法建立數據庫檔案
	echo 請確保您有以下之一：
	echo 1. Microsoft Access 已安裝
	echo 2. Microsoft Access Database Engine 已安裝
	echo 3. 手動在 Data 資料夾中建立 fortunetelling.mdb 檔案
)

pause
