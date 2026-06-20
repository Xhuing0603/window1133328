/*
 * 如果 Access 資料庫無法建立，使用此備選方案：SQLite
 * 
 * SQLite 優勢：
 * - 跨平台支持
 * - 無需安裝驅動程序
 * - 自動建立檔案
 * - 開源免費
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

// 注意：使用此方案需要安裝 NuGet 包：
// Install-Package System.Data.SQLite.Core

/*
using System.Data.SQLite;

namespace Fortune_telling.Database.Alternative
{
    public class SQLiteDatabaseManager
    {
        private static readonly string DbPath = GetDatabasePath();

        private static string GetDatabasePath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            if (baseDir.Contains(@"\bin\Debug") || baseDir.Contains(@"\bin\Release"))
            {
                baseDir = Directory.GetParent(Directory.GetParent(baseDir).FullName).FullName;
            }

            return Path.Combine(baseDir, "Data", "fortunetelling.db");
        }

        private static readonly string ConnectionString = $"Data Source={DbPath};";

        public SQLiteDatabaseManager()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            try
            {
                // 確保目錄存在
                string directory = Path.GetDirectoryName(DbPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // SQLite 會自動建立數據庫檔案
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();
                    conn.Close();
                }

                // 建立表格
                CreateTables();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"初始化數據庫失敗：{ex.Message}");
            }
        }

        private void CreateTables()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();

                    // 建立使用者表格
                    string userTableSql = @"
                        CREATE TABLE IF NOT EXISTS Users (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Username TEXT UNIQUE NOT NULL,
                            Password TEXT NOT NULL,
                            CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";

                    // 建立占卜記錄表格
                    string recordTableSql = @"
                        CREATE TABLE IF NOT EXISTS FortuneRecords (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            UserId INTEGER NOT NULL,
                            Result TEXT NOT NULL,
                            CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
                            FOREIGN KEY (UserId) REFERENCES Users(Id)
                        );";

                    using (SQLiteCommand cmd = new SQLiteCommand(userTableSql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(recordTableSql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"建立表格失敗：{ex.Message}");
            }
        }

        public bool RegisterUser(string username, string password)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO Users (Username, Password) VALUES (@username, @password);";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"註冊失敗：{ex.Message}");
                return false;
            }
        }

        public bool LoginUser(string username, string password)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password;";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        int result = (int)cmd.ExecuteScalar();

                        conn.Close();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"登入失敗：{ex.Message}");
                return false;
            }
        }

        public int GetUserId(string username)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT Id FROM Users WHERE Username = @username;";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        object result = cmd.ExecuteScalar();

                        conn.Close();
                        return result != null ? (int)(long)result : -1;
                    }
                }
            }
            catch
            {
                return -1;
            }
        }

        public bool UserExists(string username)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Users WHERE Username = @username;";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        int result = (int)cmd.ExecuteScalar();

                        conn.Close();
                        return result > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool SaveFortuneRecord(int userId, string result)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "INSERT INTO FortuneRecords (UserId, Result) VALUES (@userId, @result);";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@result", result);
                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"保存占卜結果失敗：{ex.Message}");
                return false;
            }
        }

        public List<Fortune_telling.Models.FortuneRecord> GetUserFortuneRecords(int userId)
        {
            List<Fortune_telling.Models.FortuneRecord> records = 
                new List<Fortune_telling.Models.FortuneRecord>();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(ConnectionString))
                {
                    conn.Open();
                    string sql = "SELECT Id, UserId, Result, CreatedAt FROM FortuneRecords " +
                                 "WHERE UserId = @userId ORDER BY CreatedAt DESC;";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);

                        using (IDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                records.Add(new Fortune_telling.Models.FortuneRecord
                                {
                                    Id = (int)(long)reader["Id"],
                                    UserId = (int)(long)reader["UserId"],
                                    Result = reader["Result"].ToString(),
                                    CreatedAt = (DateTime)reader["CreatedAt"]
                                });
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"取得占卜記錄失敗：{ex.Message}");
            }

            return records;
        }
    }
}
*/
