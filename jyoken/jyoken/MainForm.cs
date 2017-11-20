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
using System.Text.RegularExpressions;

namespace jyoken
{
    public partial class MainForm : Form
    {
        string _txtFile = null;
        string txtFile{
            get { return _txtFile; }
            set{
                _txtFile = value;
                if (string.IsNullOrEmpty(_txtFile))
                    this.btnProcess.Enabled = false;
            }
        }
        string text = null;
        string result = null;
        string _saveRoute = null;
        string saveRoute{
            get { return _saveRoute; }
            set {
                _saveRoute = value;
                if (string.IsNullOrEmpty(_saveRoute))
                    this.btnSave.Enabled = false;
            }
        }
        string mecabLocation = @".\mecab\mecab.exe";
        public string receiveData
        {
            get { return mecabLocation; }
            set { mecabLocation = value; }
        }
        string introText =
@"利用説明

設定：mecabの位置（本ツール同梱）

一、ファイルを選択する
二、セーブ用のフォルダーを選択する
三、処理したいキーワードを選択する
四、処理をクッリクする
五、保存";

        string[] keyWords = { "ば", "たら","なら","と","とき","時","場合" };
        Dictionary<string, string> keywordRegex = new Dictionary<string, string>();

        #region btnSave monitor
        //public delegate void deleCanSave();
        //public event deleCanSave onBothIsOk;

        bool _isResultOK;
        public bool isResultOK{
            get { return _isResultOK; }
            set{
                _isResultOK = value;
                if (_isResultOK && isSaveRouteOK)
                    SaveBtnEnable();
            }
        }
        bool _isSaveRouteOK;
        public bool isSaveRouteOK{
            get { return _isSaveRouteOK; }
            set{
                _isSaveRouteOK = value;
                if (isResultOK && _isSaveRouteOK)
                    SaveBtnEnable();
            }
        }
        #endregion

        public MainForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.onBothIsOk += new deleCanSave(Evn_onBothIsOk);
            InitializeComponent();
            this.lblIntro.Text = introText;
            this.btnSavedFileOpen.Visible = false;
            this.picBoxSucceed.Image = new Bitmap(Resource.hakui, 120, 120);
            this.picBoxSucceed.Visible = false;
            //string[] keyWords = { "ば", "たら","なら","と","とき","時","場合" };
            keywordRegex.Add(keyWords[0], @"\bば.*副詞可能");
            keywordRegex.Add(keyWords[1], @"\bたら.*副詞可能");
            keywordRegex.Add(keyWords[2], @"\bなら.*助動詞");
            keywordRegex.Add(keyWords[3], @"(\bと\s+).*副詞可能");
            keywordRegex.Add(keyWords[4], @"\bとき.*副詞可能");
            keywordRegex.Add(keyWords[5], @"\b時.*副詞可能");
            keywordRegex.Add(keyWords[6], @"場合");
            keyWordListGen(); 
        }

        private void Evn_onBothIsOk()
        {
            SaveBtnEnable();
        }

        private void fileSelect_Click(object sender, EventArgs e)
        {
            //select one file
            try
            {
                var f = selectFile(false);
                txtFile = !string.IsNullOrEmpty(f) ? f : txtFile;
                txtboxFileSelect.Text = txtFile;
                btnProcess.Enabled = !string.IsNullOrEmpty(txtFile) ? true : false;
                
            }
            catch(Exception){}
        }

        private void btnRouteSelect_Click(object sender, EventArgs e)
        {
            saveRoute = selectRoute();
            txtboxSaveRoute.Text = saveRoute;
            this.isSaveRouteOK = true;
        }

        /* 1 把需求拆分成句 reqSentence
         * 2 将每一句扔進mecab中，判斷結果 mecabResult
         * 3 將符合條件的句子保存進 result += reqSentence
        */
        private void btnProcess_Click(object sender, EventArgs e)
        {
            cheLstBoxKeyWords.Enabled = cheboxAllSelect.Enabled = btnProcess.Enabled = false;
            //run mecab
            string mecabResult = null;
            //以空行為界，將每一個不是空行的文本塊提取成一個字符串
            List<string> reqSentences = readReqSentences(File.ReadAllLines(txtFile));
            
            try
            {
                var selectedKeywords = getSelectedKeywords();
                foreach (string Sentence in reqSentences)
                {
                    File.WriteAllText(Environment.CurrentDirectory + @"\haha.txt", Sentence, Encoding.UTF8);
                    //File.SetAttributes(Environment.CurrentDirectory + @"\haha.txt", FileAttributes.Hidden);
                    mecabResult = mecabProcess(Sentence);
                    //正則判斷
                    if (isIfRequirement(mecabResult, selectedKeywords))
                    {
                        result += Sentence + "\r\n\r\n";
                        //MessageBox.Show(result);
                    }
                }
                promptLabel.Text = "処理完成";
                //File.Delete(Environment.CurrentDirectory + @"\haha.txt");
                cheLstBoxKeyWords.Enabled = cheboxAllSelect.Enabled = btnProcess.Enabled = true;
            }
            catch (Exception) { }
            File.Delete(Environment.CurrentDirectory + @"\haha.txt");
            //MessageBox.Show((!string.IsNullOrEmpty(result)).ToString() + (!string.IsNullOrEmpty(saveRoute)).ToString());
            if (!string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(saveRoute))
                this.isResultOK = true;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileName = new FileInfo(txtFile);
                File.WriteAllText((saveRoute + @"\mecab_" + fileName.Name), result);
                MessageBox.Show("セーブしました", "セーブ完了");
                promptLabel.Text = "[mecab_" + fileName.Name + "] has been saved into " + saveRoute + "!";
                lblIntro.Visible = false;
                succedShow();
                this.btnSavedFileOpen.Visible = true;
            } catch(Exception)
            {
                MessageBox.Show("何かエラーが起きてしまいました","セーブ失敗");
            }
        }

        //after mecabResult processed and save route be setted,enable the save btn
        private void SaveBtnEnable()
        {
            btnSave.Enabled = true;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm(this,System.Environment.CurrentDirectory + mecabLocation);
            settingForm.StartPosition = FormStartPosition.CenterParent;
            settingForm.ShowDialog();
        }

        private void cheboxAllSelect_Click(object sender, EventArgs e)
        {
            if (cheboxAllSelect.Checked == true)
            {
                for (int i = 0; i < cheLstBoxKeyWords.Items.Count; i++)
                    cheLstBoxKeyWords.SetItemChecked(i, true);
            }
            else
            {
                for (int i = 0; i < cheLstBoxKeyWords.Items.Count; i++)
                    cheLstBoxKeyWords.SetItemChecked(i, false);
            }
        }

        private void cheLstBoxKeyWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            //若發現沒有全部選擇，及時勾白全選checkbox
            for (int i = 0; i < cheLstBoxKeyWords.Items.Count; i++)
            {
                if (cheLstBoxKeyWords.GetItemChecked(i) == false)
                {
                    cheboxAllSelect.Checked = false;
                    break;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnSavedFileOpen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", "\"" + saveRoute + @"\" + "mecab_" + (new FileInfo(txtFile)).Name + "\"");
        }

        #region debug
#if DEBUG

        private void button1_Click(object sender, EventArgs e)
        {
            string a =
@"
時	名詞,接尾,副詞可能,*,*,*,時,ジ,ジ
";
            Regex r = new Regex(@"\b時.*副詞可能");
            MessageBox.Show((r.IsMatch(a)).ToString());
        }

        private void test(List<string> reqSentences)
        {
            string str = mecabLocation;// + " " + "\"" + txtFile + /*" >show.txt" +*/ "\"";
            //MessageBox.Show(str);
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            //p.StartInfo.FileName = "\"" + mecabLocation + "\"";
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
            
            p.Start();//启动程序
            //MessageBox.Show(p.StartInfo.StandardOutputEncoding.ToString());
            //向cmd窗口发送输入信息
            //p.StandardInput.WriteLine("chcp 65001");
            File.WriteAllText("haha.txt", reqSentences[0], Encoding.UTF8);
            p.StandardInput.WriteLine(str + " " + "haha.txt" + " &exit");
            //p.StandardInput.WriteLine(reqSentences[0]);

            p.StandardInput.AutoFlush = true;
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令

            //System.Threading.Thread.Sleep(2000);

            //p.Kill();
            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();
            //File.WriteAllText(Environment.CurrentDirectory + @"\show.txt", output);
            //StreamReader reader = p.StandardOutput;
            //string line=reader.ReadLine();
            //while (!reader.EndOfStream)
            //{
            //    str += line + "  ";
            //    line = reader.ReadLine();
            //}
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();

            MessageBox.Show(output);
        }

        private void test2()
        {
            List<string> reqSentences = readReqSentences(File.ReadAllLines(txtFile));
            foreach (var sen in reqSentences)
            {
                MessageBox.Show(sen);
            }
        }
#endif
        #endregion
    }

}
