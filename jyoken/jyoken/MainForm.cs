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

namespace jyoken
{
    public partial class MainForm : Form
    {
        string _file = null;
        string file{
            get { return _file; }
            set{
                _file = value;
                if (_file == null || _file == string.Empty)
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
                if (_saveRoute == null || _saveRoute == string.Empty)
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
@"  利用説明

設定：mecabの位置を選択して

一、ファイルを選択
二、セーブ用のフォルダーを選択
三、処理したいキーワードを選択
四、処理をクッリクする
五、保存";

        List<string> keyWords = new List<string> { "ば", "たら","なら","と","とき","時","場合" };
        //Image imgHakui = Resource.hakui;
        
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
                file =  f != null ? f : file;
                txtboxFileSelect.Text = file;
                btnProcess.Enabled = file != null ? true : false;
                
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
            //run mecab
            string mecabResult = null;

            text = File.ReadAllText(file);

                try
                {
                    mecabResult = mecabProcess(text);
                    //for(int i = 0;i < cheLstBoxKeyWords.Items.Count;i++)
                    //{
                    //    if (cheLstBoxKeyWords.GetItemChecked(i))
                    //        result += "\n" + keyWordProcess(cheLstBoxKeyWords.GetItemText(i));
                    //}
                result = mecabResult;//這句最後要刪除
                promptLabel.Text = "処理完成";
            }
            catch (Exception) { }
            if (result != null && saveRoute != null)
                this.isResultOK = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileName = new FileInfo(file);
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
            System.Diagnostics.Process.Start("notepad.exe", "\"" + saveRoute + @"\" + "mecab_" + (new FileInfo(file)).Name + "\"");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            test();
        }

        private void test()
        {
            string str = Console.ReadLine();

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(str + "&exit");

            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令



            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();

            //StreamReader reader = p.StandardOutput;
            //string line=reader.ReadLine();
            //while (!reader.EndOfStream)
            //{
            //    str += line + "  ";
            //    line = reader.ReadLine();
            //}

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();


            Console.WriteLine(output);
        }
    }

}
