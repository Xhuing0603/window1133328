using System;
using System.Collections.Generic;

namespace Fortune_telling.Models
{
    /// <summary>
    /// 單個爻的類型
    /// </summary>
    public enum YaoType
    {
        LaoYang = 0,        // 老陽 (3陽)
        ShaoYang = 1,       // 少陽 (2陽1陰)
        ShaoYin = 2,        // 少陰 (2陰1陽)
        LaoYin = 3          // 老陰 (3陰)
    }

    /// <summary>
    /// 卦象爻（陽爻或陰爻）
    /// </summary>
    public enum GuaLine
    {
        Yang = 0,           // 陽爻 ─
        Yin = 1             // 陰爻 ─ ─
    }

    /// <summary>
    /// 單個爻的結果
    /// </summary>
    public class Yao
    {
        public int Position { get; set; }       // 位置 (1-6)
        public YaoType Type { get; set; }       // 爻的類型
        public GuaLine Line { get; set; }       // 對應的卦線

        public override string ToString()
        {
            string typeName;
            switch (Type)
            {
                case YaoType.LaoYang:
                    typeName = "老陽";
                    break;
                case YaoType.ShaoYang:
                    typeName = "少陽";
                    break;
                case YaoType.ShaoYin:
                    typeName = "少陰";
                    break;
                case YaoType.LaoYin:
                    typeName = "老陰";
                    break;
                default:
                    typeName = "未知";
                    break;
            }

            string lineName = Line == GuaLine.Yang ? "陽爻" : "陰爻";
            return $"第{Position}爻：{typeName}({lineName})";
        }
    }

    /// <summary>
    /// 完整的卦象（包含六個爻）
    /// </summary>
    public class GuaXiang
    {
        public int GuaNumber { get; set; }              // 卦序號 (1-64)
        public string GuaName { get; set; }            // 卦名
        public string GuaSymbol { get; set; }          // 卦符號
        public string Meaning { get; set; }            // 卦意
        public List<Yao> Yaos { get; set; }            // 六個爻
        public DateTime CreatedAt { get; set; }        // 占卜時間

        public GuaXiang()
        {
            Yaos = new List<Yao>();
        }

        public override string ToString()
        {
            return $"【{GuaName}】\n" +
                   $"卦序：{GuaNumber}\n" +
                   $"含義：{Meaning}\n" +
                   $"時間：{CreatedAt:yyyy-MM-dd HH:mm:ss}";
        }
    }
}
