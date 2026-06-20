/*
 * 文王卦占卜系統 - 使用示例
 * 
 * 本文件展示如何在 Windows Forms 設計器中整合占卜功能
 */

using System;
using System.Windows.Forms;
using Fortune_telling.Models;
using Fortune_telling.Services;

namespace Fortune_telling.Examples
{
    /// <summary>
    /// 示例代碼：在設計器中添加按鈕並綁定占卜事件
    /// </summary>
    public class FrmFortuneDesignerExample
    {
        /*
         * 在 frmFortune.Designer.cs 中添加以下代碼：
         * 
         * private System.Windows.Forms.Button btnGenerateYao;
         * private System.Windows.Forms.Label lblYaoCount;
         * private System.Windows.Forms.Label lblCurrentYao;
         * private System.Windows.Forms.TextBox txtResult;
         * 
         * 然後在 InitializeComponent() 中添加：
         * 
         * this.btnGenerateYao = new System.Windows.Forms.Button();
         * this.btnGenerateYao.Location = new System.Drawing.Point(50, 50);
         * this.btnGenerateYao.Size = new System.Drawing.Size(120, 40);
         * this.btnGenerateYao.Text = "抽爻";
         * this.btnGenerateYao.Click += new System.EventHandler(this.btnGenerateYao_Click);
         * this.Controls.Add(this.btnGenerateYao);
         * 
         * this.lblYaoCount = new System.Windows.Forms.Label();
         * this.lblYaoCount.Location = new System.Drawing.Point(50, 100);
         * this.lblYaoCount.Text = "已抽：0/6 爻";
         * this.Controls.Add(this.lblYaoCount);
         * 
         * this.lblCurrentYao = new System.Windows.Forms.Label();
         * this.lblCurrentYao.Location = new System.Drawing.Point(50, 130);
         * this.lblCurrentYao.AutoSize = true;
         * this.Controls.Add(this.lblCurrentYao);
         * 
         * this.txtResult = new System.Windows.Forms.TextBox();
         * this.txtResult.Location = new System.Drawing.Point(50, 160);
         * this.txtResult.Size = new System.Drawing.Size(400, 200);
         * this.txtResult.Multiline = true;
         * this.txtResult.ReadOnly = true;
         * this.Controls.Add(this.txtResult);
         */
    }

    /// <summary>
    /// 實現示例代碼
    /// </summary>
    public class FrmFortuneImplementationExample
    {
        /*
         * 在 frmFortune.cs 中添加以下方法：
         */

        private System.Windows.Forms.Button btnGenerateYao;
        private System.Windows.Forms.Label lblYaoCount;
        private System.Windows.Forms.Label lblCurrentYao;
        private System.Windows.Forms.TextBox txtResult;

        // 假設已有的字段
        // private YijingService yijingService;
        // private List<YaoType> currentYaos;
        // private GuaXiang primaryGua;
        // private GuaXiang changedGua;

        /*
         * 事件處理方法：
         */
        private void btnGenerateYao_Click(object sender, EventArgs e)
        {
            // 調用占卜邏輯
            // GenerateYao();

            // 更新 UI
            // UpdateUI();
        }

        /*
         * 更新 UI 的示例方法：
         */
        private void UpdateUI()
        {
            /*
            lblYaoCount.Text = $"已抽：{currentYaos.Count}/6 爻";

            if (currentYaos.Count > 0)
            {
                var lastYao = currentYaos[currentYaos.Count - 1];
                lblCurrentYao.Text = $"最後一爻：{GetYaoDisplay(lastYao)}";
            }

            if (currentYaos.Count == 6)
            {
                // 顯示完整結果
                var resultText = GenerateResultText();
                txtResult.Text = resultText;
                btnGenerateYao.Enabled = false;
            }
            */
        }

        private string GetYaoDisplay(YaoType yaoType)
        {
            switch (yaoType)
            {
                case YaoType.LaoYang:
                    return "●●● (老陽)";
                case YaoType.ShaoYang:
                    return "○○● (少陽)";
                case YaoType.ShaoYin:
                    return "●○○ (少陰)";
                case YaoType.LaoYin:
                    return "○○○ (老陰)";
                default:
                    return "未知";
            }
        }

        private string GenerateResultText()
        {
            /*
            int oldYangYinCount = currentYaos.Count(y => y == YaoType.LaoYang || y == YaoType.LaoYin);
            GuaXiang displayGua = oldYangYinCount <= 3 ? primaryGua : changedGua;

            string result = $"【{displayGua.GuaName} 卦】\n" +
                           $"卦序：第{displayGua.GuaNumber}卦\n" +
                           $"含義：{displayGua.Meaning}\n\n" +
                           $"爻象：\n";

            foreach (var yao in displayGua.Yaos)
            {
                result += $"{yao.Position}. {GetYaoDisplay(yao.Type)}\n";
            }

            result += $"\n老陽老陰總數：{oldYangYinCount}";

            return result;
            */
            return "";
        }
    }

    /// <summary>
    /// 完整工作流程示例
    /// </summary>
    public class CompleteWorkflowExample
    {
        /*
         * 完整的占卜流程：
         * 
         * 1. 用戶登錄成功
         * 2. 打開 frmFortune 窗體
         * 3. 初始化 YijingService
         * 4. 顯示「抽爻」按鈕
         * 5. 用戶點擊「抽爻」按鈕 6 次
         *    - 第1次：生成第1爻，顯示「老陽」或「少陽」等
         *    - 第2次：生成第2爻，累積顯示
         *    - ...
         *    - 第6次：生成第6爻
         * 6. 系統自動：
         *    - 計算老陽老陰數量
         *    - 生成本卦和變卦
         *    - 選擇要顯示的卦象
         *    - 顯示完整的占卜結果
         *    - 保存到數據庫
         * 7. 用戶可以點擊「重新占卜」重新開始
         * 8. 用戶可以點擊「查看歷史」查看過去的占卜記錄
         */
    }
}
