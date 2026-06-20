using System;
using System.IO;

namespace Fortune_telling.Utilities
{
    /// <summary>
    /// 應用初始化工具 - 負責在應用啟動時準備必要的資源
    /// </summary>
    public static class ApplicationInitializer
    {
        public static void Initialize()
        {
            try
            {
                // 初始化數據庫
                InitializeDatabase();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    $"應用初始化失敗：{ex.Message}\n\n" +
                    "請查看 DATABASE_TROUBLESHOOTING.md 文件獲取解決方案。",
                    "初始化錯誤",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error
                );
            }
        }

        private static void InitializeDatabase()
        {
            try
            {
                // 確保 Data 資料夾存在
                string dataDir = Path.Combine(GetApplicationDataPath(), "Data");
                if (!Directory.Exists(dataDir))
                {
                    Directory.CreateDirectory(dataDir);
                }

                // 數據庫管理器會自動初始化和建立表格
                var dbManager = new Fortune_telling.Database.DatabaseManager();

                // 驗證數據庫
                string dbPath = GetDatabasePath();
                if (!File.Exists(dbPath))
                {
                    System.Windows.Forms.MessageBox.Show(
                        $"警告：無法自動建立數據庫檔案。\n\n" +
                        $"預期位置：{dbPath}\n\n" +
                        "請執行 CreateAccessDatabase.bat 或查看 DATABASE_TROUBLESHOOTING.md",
                        "數據庫初始化警告"
                    );
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"數據庫初始化失敗：{ex.Message}", ex);
            }
        }

        public static string GetApplicationDataPath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            if (baseDir.Contains(@"\bin\Debug") || baseDir.Contains(@"\bin\Release"))
            {
                return Directory.GetParent(Directory.GetParent(baseDir).FullName).FullName;
            }

            return baseDir;
        }

        public static string GetDatabasePath()
        {
            return Path.Combine(GetApplicationDataPath(), "Data", "fortunetelling.mdb");
        }
    }
}
