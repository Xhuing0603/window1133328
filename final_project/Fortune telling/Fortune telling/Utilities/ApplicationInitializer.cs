using System;
using System.IO;

namespace Fortune_telling.Utilities
{
    public static class ApplicationInitializer
    {
        public static void Initialize()
        {
            try
            {
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
                string dataDir = Path.Combine(GetApplicationDataPath(), "Data");
                if (!Directory.Exists(dataDir))
                {
                    Directory.CreateDirectory(dataDir);
                }

                var dbManager = new Fortune_telling.Database.DatabaseManager();

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
