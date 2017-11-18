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
namespace jyoken
{
    public partial class MainForm
    {

        private string mecabProcess(string text)
        {
            Process p = new Process();
            p.StartInfo.FileName = mecabLocation;
            //test sentence
            p.StartInfo.Arguments =
@"9) ハードウェア及びソフトウェアの運用、保守、障害時の迅速な修復などについて、受 注者の支援体制が迅速かつ協力的であること。
1) 高速確実なバックアップ機能を備え、障害時には短時間で復旧できること。
14) 受入後に所蔵に反映する各種の値（資料種別、所在、受入区分、貸出区分、備消区分） を発注時に設定できること。
15) 複本の発注時に、ローカルの既存の書誌を流用できること。
5) 寄贈図書等の受入時に備消区分、資料種別、配架場所の任意の項目について、直前に 入力したレコードを参照して自動的に値を設定すること。
8) 継続物やセット物の受入時に、同じ発注ですでに受け入れた所蔵情報を見られること。
11) 利用者番号と予算区分の組み合わせごとに予算額を設定し、受入時に超過チェックが 可能なこと。
";
            //p.StartInfo.Arguments = "\"" + file + "\"";//@"""C:\Users\trans\Documents\Visual Studio 2015\Projects\jyoken\jyoken\bin\Debug\mecab\test.txt";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();
            p.WaitForExit();
            p.Close();
            return output;
        }

        private bool isIfRequirement(string sentence)
        {
            return false;
        }

       private string keyWordProcess(string keyword)
        {

            return null;
        }

        public string selectFile(bool isMultiSelect)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = isMultiSelect;
            dialog.Title = "Select file";
            dialog.Filter = "Txt files(*.*)|*.txt";
            return dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK ? dialog.FileName : null;
        }

        private string selectRoute()
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new FolderBrowserDialog();
            return fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK ? fbd.SelectedPath : null;
        }

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

        private void succedShow()
        {
            picBoxSucceed.Visible = true;
            //pictureBox1.BackColor = Color.Transparent;
            //pictureBox1.Parent = picBoxSucceed;
            //pictureBox1.Image = new Bitmap(Resource.seiko, 120, 120);
        }
        private void keyWordListGen()
        {
            foreach (var k in keyWords)
            {
                cheLstBoxKeyWords.Items.Add(k);
            }
        }
        
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
            file = null;
            text = null;
            result = null;
            saveRoute = null;
        }
    }
}
