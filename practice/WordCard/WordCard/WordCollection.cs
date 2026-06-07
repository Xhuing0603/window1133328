using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCard
{
    internal class WordCollection : List<WordItem>
    {
        /// <summary>
        /// 從字串陣列載入單字資料
        /// </summary>
        /// <param name="lines">單字資料行陣列</param>
        public void LoadFromStringArray(string[] lines)
        {
            this.Clear();
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    WordItem item = new WordItem(line);
                    this.Add(item);
                }
            }
        }
        ///<summary>
        ///將WordCollection物件的資料儲存到檔案中
        ///</summary>
        ///<paramname="filePath"></param>
        public void SaveToFile(string filePath)
        {
            // 將WordCollection物件的資料儲存到檔案中
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (WordItem item in this)
                {
                    // 將每個單字項目轉換為字串並寫入檔案
                    writer.WriteLine(item.ToLineString());
                }
            }
        }
    }
}
