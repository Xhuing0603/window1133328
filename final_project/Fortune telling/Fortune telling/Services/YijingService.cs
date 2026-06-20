using System;
using System.Collections.Generic;
using Fortune_telling.Models;

namespace Fortune_telling.Services
{
    /// <summary>
    /// 易經卦象生成和查詢服務
    /// </summary>
    public class YijingService
    {
        private Random random = new Random();
        private Dictionary<string, GuaInfo> guaDictionary;

        public YijingService()
        {
            InitializeGuaDictionary();
        }

        /// <summary>
        /// 生成單個爻（返回3個隨機的陰陽組合）
        /// </summary>
        public YaoType GenerateYao()
        {
            int yangCount = 0;
            // 生成3次，每次隨機決定陰(0)或陽(1)
            for (int i = 0; i < 3; i++)
            {
                if (random.Next(2) == 1)
                    yangCount++;
            }

            // 根據陽的數量判斷爻的類型
            if (yangCount == 3)
                return YaoType.LaoYang;        // 3陽
            else if (yangCount == 2)
                return YaoType.ShaoYang;       // 2陽1陰
            else if (yangCount == 1)
                return YaoType.ShaoYin;        // 2陰1陽
            else
                return YaoType.LaoYin;         // 3陰
        }

        /// <summary>
        /// 將爻的類型轉換為卦線
        /// 一卦：老陽、少陽 = 陽爻；少陰、老陰 = 陰爻
        /// </summary>
        public GuaLine ConvertToGuaLine(YaoType yaoType, bool isSecondGua = false)
        {
            if (!isSecondGua)
            {
                // 第一卦的規則
                return (yaoType == YaoType.LaoYang || yaoType == YaoType.ShaoYang) 
                    ? GuaLine.Yang 
                    : GuaLine.Yin;
            }
            else
            {
                // 第二卦的規則（變卦）
                // 老陰、老陽為陽爻，老陽、少陰為陰爻？
                // 根據易經規則，變卦是老陽老陰變爻
                return (yaoType == YaoType.LaoYang || yaoType == YaoType.LaoYin) 
                    ? GuaLine.Yang 
                    : GuaLine.Yin;
            }
        }

        /// <summary>
        /// 生成完整的占卜結果（第一卦和第二卦）
        /// </summary>
        public (GuaXiang primaryGua, GuaXiang changedGua) GenerateFullDivination(List<YaoType> yaoTypes)
        {
            if (yaoTypes.Count != 6)
                throw new ArgumentException("必須提供6個爻的結果");

            // 計算老陽老陰的數量
            int oldYangYinCount = 0;
            foreach (var yao in yaoTypes)
            {
                if (yao == YaoType.LaoYang || yao == YaoType.LaoYin)
                    oldYangYinCount++;
            }

            // 生成第一卦
            GuaXiang primaryGua = GenerateGua(yaoTypes, false);

            // 根據老陽老陰的數量決定是否需要第二卦
            GuaXiang changedGua = null;
            if (oldYangYinCount >= 4)
            {
                // 生成變卦（老陽老陰轉換為相反的爻）
                var changedYaoTypes = new List<YaoType>(yaoTypes);
                for (int i = 0; i < changedYaoTypes.Count; i++)
                {
                    if (changedYaoTypes[i] == YaoType.LaoYang)
                        changedYaoTypes[i] = YaoType.ShaoYin;  // 老陽變成陰爻
                    else if (changedYaoTypes[i] == YaoType.LaoYin)
                        changedYaoTypes[i] = YaoType.ShaoYang; // 老陰變成陽爻
                }
                changedGua = GenerateGua(changedYaoTypes, true);
            }

            return (primaryGua, changedGua);
        }

        /// <summary>
        /// 根據6個爻生成對應的卦象
        /// </summary>
        private GuaXiang GenerateGua(List<YaoType> yaoTypes, bool isSecondGua)
        {
            // 轉換為卦線（從下到上）
            var lines = new List<GuaLine>();
            for (int i = 0; i < yaoTypes.Count; i++)
            {
                lines.Add(ConvertToGuaLine(yaoTypes[i], isSecondGua));
            }

            // 計算卦序（易經的卦序由下向上計算）
            int guaNumber = CalculateGuaNumber(lines);

            // 查詢卦象信息
            var guaInfo = GetGuaInfo(guaNumber);

            var gua = new GuaXiang
            {
                GuaNumber = guaNumber,
                GuaName = guaInfo.Name,
                GuaSymbol = guaInfo.Symbol,
                Meaning = guaInfo.Meaning,
                CreatedAt = DateTime.Now
            };

            // 添加爻信息（從下到上，爻的位置從1到6）
            for (int i = 0; i < yaoTypes.Count; i++)
            {
                gua.Yaos.Add(new Yao
                {
                    Position = i + 1,
                    Type = yaoTypes[i],
                    Line = lines[i]
                });
            }

            return gua;
        }

        /// <summary>
        /// 根據爻線計算卦序號（1-64）
        /// 易經卦序的計算方式
        /// </summary>
        private int CalculateGuaNumber(List<GuaLine> lines)
        {
            // 轉換為二進制：陽=1，陰=0
            // 從下到上計算
            int value = 0;
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i] == GuaLine.Yang)
                    value += (1 << i);  // 2的i次方
            }

            // 卦序號從1到64
            return value + 1;
        }

        /// <summary>
        /// 初始化64卦信息字典
        /// </summary>
        private void InitializeGuaDictionary()
        {
            guaDictionary = new Dictionary<string, GuaInfo>
            {
                { "0", new GuaInfo(1, "乾", "☰☰☰", "天，象徵強健、創始、領導力") },
                { "1", new GuaInfo(2, "坤", "☷☷☷", "地，象徵順從、柔軟、包容") },
                { "2", new GuaInfo(3, "屯", "☳☴☷", "雷水，象徵困難中的初生") },
                { "3", new GuaInfo(4, "蒙", "☷☴☳", "山水，象徵蒙昧、開蒙") },
                { "4", new GuaInfo(5, "需", "☰☴☳", "天水，象徵等待、需要") },
                { "5", new GuaInfo(6, "訟", "☳☴☰", "水天，象徵爭訟、對立") },
                { "6", new GuaInfo(7, "師", "☷☴☰", "地水，象徵軍隊、集眾") },
                { "7", new GuaInfo(8, "比", "☰☴☷", "水地，象徵親比、親近") },
                { "8", new GuaInfo(9, "小畜", "☴☰☰", "風天，象徵小的積累") },
                { "9", new GuaInfo(10, "履", "☰☰☴", "天風，象徵步履、踐踏") },
                { "10", new GuaInfo(11, "泰", "☷☷☰", "地天，象徵亨通、和諧") },
                { "11", new GuaInfo(12, "否", "☰☰☷", "天地，象徵閉塞、阻滯") },
                { "12", new GuaInfo(13, "同人", "☴☰☰", "火天，象徵同類、團結") },
                { "13", new GuaInfo(14, "大有", "☰☰☴", "天火，象徵豐富、大展") },
                { "14", new GuaInfo(15, "謙", "☶☷☷", "山地，象徵謙虛、謙遜") },
                { "15", new GuaInfo(16, "豫", "☷☷☶", "地山，象徵歡樂、逸樂") },
                { "16", new GuaInfo(17, "隨", "☶☴☰", "澤雷，象徵跟隨、隨從") },
                { "17", new GuaInfo(18, "蠱", "☰☴☶", "山風，象徵蠱毒、腐敗") },
                { "18", new GuaInfo(19, "臨", "☷☷☶", "地澤，象徵臨界、臨近") },
                { "19", new GuaInfo(20, "觀", "☶☷☷", "風地，象徵觀看、觀察") },
                { "20", new GuaInfo(21, "噬嗑", "☴☳☶", "火雷，象徵咬合、合一") },
                { "21", new GuaInfo(22, "賁", "☶☳☴", "山火，象徵裝飾、文明") },
                { "22", new GuaInfo(23, "剝", "☶☷☷", "山地，象徵剝落、衰退") },
                { "23", new GuaInfo(24, "復", "☰☷☷", "地雷，象徵回復、反復") },
                { "24", new GuaInfo(25, "無妄", "☰☳☰", "天雷，象徵無妄、真實") },
                { "25", new GuaInfo(26, "大畜", "☶☰☰", "山天，象徵大積累") },
                { "26", new GuaInfo(27, "頤", "☶☷☶", "山地，象徵咬合、養育") },
                { "27", new GuaInfo(28, "大過", "☶☶☷", "澤風，象徵過大、超越") },
                { "28", new GuaInfo(29, "坎", "☳☴☳", "水，象徵危險、陷阱") },
                { "29", new GuaInfo(30, "離", "☴☳☴", "火，象徵光明、文明") },
                { "30", new GuaInfo(31, "咸", "☶☴☷", "澤山，象徵感應、感應") },
                { "31", new GuaInfo(32, "恆", "☷☴☶", "風雷，象徵恆久、堅持") },
                { "32", new GuaInfo(33, "遯", "☶☰☰", "天山，象徵退避、隱遁") },
                { "33", new GuaInfo(34, "大壯", "☰☰☶", "雷天，象徵力量、強壯") },
                { "34", new GuaInfo(35, "晉", "☴☷☰", "火地，象徵進展、升進") },
                { "35", new GuaInfo(36, "明夷", "☰☷☴", "地火，象徵光明受傷") },
                { "36", new GuaInfo(37, "家人", "☴☳☷", "火雷，象徵家庭、親屬") },
                { "37", new GuaInfo(38, "睽", "☷☳☴", "澤火，象徵乖離、分離") },
                { "38", new GuaInfo(39, "蹇", "☶☳☰", "山水，象徵困難、艱難") },
                { "39", new GuaInfo(40, "解", "☰☳☶", "雷水，象徵解釋、解放") },
                { "40", new GuaInfo(41, "損", "☶☷☶", "山澤，象徵損耗、減損") },
                { "41", new GuaInfo(42, "益", "☶☷☶", "風雷，象徵增益、好處") },
                { "42", new GuaInfo(43, "夬", "☶☶☶", "澤天，象徵決斷、決別") },
                { "43", new GuaInfo(44, "姤", "☰☰☰", "天風，象徵相遇、遭遇") },
                { "44", new GuaInfo(45, "萃", "☶☷☷", "澤地，象徵聚集、聚合") },
                { "45", new GuaInfo(46, "升", "☷☷☶", "地風，象徵上升、升遷") },
                { "46", new GuaInfo(47, "困", "☶☴☰", "澤水，象徵困難、困窘") },
                { "47", new GuaInfo(48, "井", "☰☴☶", "水風，象徵井水、資源") },
                { "48", new GuaInfo(49, "革", "☶☴☰", "澤火，象徵變革、改變") },
                { "49", new GuaInfo(50, "鼎", "☰☴☶", "火風，象徵鼎器、成器") },
                { "50", new GuaInfo(51, "震", "☳☳☳", "雷，象徵震動、警惕") },
                { "51", new GuaInfo(52, "艮", "☶☶☶", "山，象徵靜止、停頓") },
                { "52", new GuaInfo(53, "漸", "☶☴☰", "風山，象徵漸進、漸次") },
                { "53", new GuaInfo(54, "歸妹", "☰☴☶", "雷澤，象徵歸女、女歸") },
                { "54", new GuaInfo(55, "豐", "☴☳☶", "火雷，象徵豐富、繁盛") },
                { "55", new GuaInfo(56, "旅", "☶☳☴", "山火，象徵旅行、流離") },
                { "56", new GuaInfo(57, "巽", "☴☴☴", "風，象徵柔和、進展") },
                { "57", new GuaInfo(58, "兌", "☶☶☶", "澤，象徵喜悅、說話") },
                { "58", new GuaInfo(59, "渙", "☴☴☷", "風水，象徵渙散、分散") },
                { "59", new GuaInfo(60, "節", "☷☴☴", "水澤，象徵節制、限制") },
                { "60", new GuaInfo(61, "中孚", "☶☴☴☶", "澤風，象徵誠信、信任") },
                { "61", new GuaInfo(62, "小過", "☶☳☴", "山雷，象徵小超越") },
                { "62", new GuaInfo(63, "既濟", "☴☳☰", "火水，象徵既成、完成") },
                { "63", new GuaInfo(64, "未濟", "☰☳☴", "水火，象徵未成、未完") }
            };
        }

        /// <summary>
        /// 根據卦序號獲取卦象信息
        /// </summary>
        public GuaInfo GetGuaInfo(int guaNumber)
        {
            string key = (guaNumber - 1).ToString();
            if (guaDictionary.TryGetValue(key, out var info))
                return info;

            return new GuaInfo(guaNumber, "未知卦", "？", "查詢失敗");
        }
    }

    /// <summary>
    /// 卦象基本信息
    /// </summary>
    public class GuaInfo
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Meaning { get; set; }

        public GuaInfo(int number, string name, string symbol, string meaning)
        {
            Number = number;
            Name = name;
            Symbol = symbol;
            Meaning = meaning;
        }
    }
}
