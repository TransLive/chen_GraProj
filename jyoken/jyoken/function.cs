using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
namespace jyoken
{
    public partial class MainForm
    {

        private string mecabProcess(string reqSentences)
        {
            string str = mecabLocation;
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;

            p.Start();
            //p.StandardInput.WriteLine("chcp 932");
            p.StandardInput.WriteLine(str + " " + "haha.txt" + " &exit");
            p.StandardInput.AutoFlush = true;
            string output = p.StandardOutput.ReadToEnd();

            p.WaitForExit();
            p.Close();
            //MessageBox.Show(output);
            return output;
        }


        private bool isIfRequirement(string reqSentence, List<string> keywords)
        {
            //從字典中取出正則式進行匹配
            foreach(string keyword in keywords)
            {
                Regex rgx = new Regex(keywordRegex[keyword]);
                if (rgx.IsMatch(reqSentence))
                    return true;
            }
            return false;
        }

       //讀取被選中的關鍵詞
       private List<string> getSelectedKeywords()
        {
            List<string> keywords = new List<string>();
            for (int i = 0; i < cheLstBoxKeyWords.Items.Count; i++)
            {
                if (cheLstBoxKeyWords.GetItemChecked(i))
                {
                    keywords.Add(cheLstBoxKeyWords.GetItemText(cheLstBoxKeyWords.Items[i]));
                }
            }
            return keywords;
        }

        //選擇待處理文件
        public string selectFile(bool isMultiSelect)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = isMultiSelect;
            dialog.Title = "Select file";
            dialog.Filter = "Txt files(*.*)|*.txt";
            return dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK ? dialog.FileName : null;
        }

        //選擇保存路徑
        private string selectRoute()
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new FolderBrowserDialog();
            return fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK ? fbd.SelectedPath : null;
        }

        //讀取圖片，已廢棄
        private Stream imageRead()
        {
            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream file = thisExe.GetManifestResourceStream("hakui.png");
            string[] resources = thisExe.GetManifestResourceNames();
            string list = "";
            foreach (string resource in resources)
                list += resource + " ";
            MessageBox.Show(list);
            return file;
        }

        //顯示成功信息
        private void succedShow()
        {
            picBoxSucceed.Visible = true;
        }

        //生成多選按鈕
        private void keyWordListGen()
        {
            foreach (var k in keyWords)
            {
                cheLstBoxKeyWords.Items.Add(k);
            }
        }
        
        //重置所有面板數據
        private void clearAll()
        {
            //UI clear
            txtboxFileSelect.Text = null;
            txtboxSaveRoute.Text = null;
            picBoxSucceed.Visible = false;
            lblIntro.Visible = true;
            btnSavedFileOpen.Enabled = false;
            btnSavedFileOpen.Visible = false;
            //parameter clear
            txtFile = null;
            text = null;
            result = null;
            saveRoute = null;
        }

        //從文本中逐空行提取需求
        private List<string> readReqSentences(string[] Text)
        {
            List<string> reqSentences = new List<string>();
            int i = 0;
            foreach (string sentence in Text)
            {
                if (!string.IsNullOrEmpty(sentence))
                {
                    try
                    {
                        reqSentences[i] += sentence;
                    }catch(ArgumentOutOfRangeException)
                    {
                        reqSentences.Add(sentence);
                        i++;
                    }
                }
                else
                {
                    i++;
                }
            }
            return reqSentences;
        }
    }
}
