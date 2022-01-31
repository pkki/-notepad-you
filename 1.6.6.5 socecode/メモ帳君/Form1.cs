using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Hnx8.ReadJEnc;
using System.Diagnostics;
using System.Reflection;
using System.Drawing.Printing;
using Microsoft.VisualBasic;


namespace メモ帳君
{

    public partial class Form1 : Form
    {

        [System.Runtime.InteropServices.DllImport("USER32.dll")]
        private static extern IntPtr SendMessage(System.IntPtr hWnd, Int32 Msg, Int32 wParam, ref Point lParam);
        private RichTextBox textBox;
        private Point pos;
        static string style;
        private string printingText;
        private int printingPosition;
        private Font printFont;
        static int mozi1;
        static int mozi2;
        static string code = "utf-8";
        static string text;
        static string hozon = "nothing";
        static string file;
        static string file2;
        static string fontcolor = "black";
        static string type;
        static string link = "false";
        static string hozon1 = "1";
        static string backfile;
        static string backfile1;
        static string backfile2;
        static string backfile3;
        static string backfile4;
        static string open;
        static string autosave = "false";
        static string after;
        static string saiki = "0";


        public Form1()
        {
            InitializeComponent();
        }

        private void 上書き保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            text = richTextBox1.Text;
            if (hozon == "nothing")
            {
                MessageBox.Show("名前を付けて保存をしてください",
                                         "エラー",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
            }
            else
            {
                if (code == "utf-8")
                {
                    label1.Text = "保存中";
                    //OKボタンがクリックされたとき、選択されたファイル名を表示する


                    System.IO.StreamWriter sw = new System.IO.StreamWriter(
        hozon,
        false,
        System.Text.Encoding.GetEncoding("utf-8"));
                    //TextBox1.Textの内容を書き込む
                    sw.Write(text);
                    //閉じる
                    sw.Close();
                    label1.Text = "保存完了";
                    label3.Text = "文字コード:" + code;
                    hozon1 = "1";
                    backfile = hozon;
                    label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(hozon);
                }
                else
                {
                    if (code == "shift-jis")
                    {
                        label1.Text = "保存中";
                        hozon1 = "1";
                        //OKボタンがクリックされたとき、選択されたファイル名を表示する


                        System.IO.StreamWriter sw = new System.IO.StreamWriter(
            hozon,
            false,
            System.Text.Encoding.GetEncoding("shift_jis"));
                        //TextBox1.Textの内容を書き込む
                        sw.Write(text);
                        //閉じる
                        sw.Close();
                        label1.Text = "保存完了";
                        label3.Text = "文字コード:" + code;
                        hozon1 = "1";
                        backfile = hozon;
                        label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(hozon);
                    }
                    else
                    {
                        if (code == "ascii")
                        {
                            label1.Text = "保存中";
                            //OKボタンがクリックされたとき、選択されたファイル名を表示する


                            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                hozon,
                false,
                System.Text.Encoding.GetEncoding("ascii"));
                            //TextBox1.Textの内容を書き込む
                            sw.Write(text);
                            //閉じる
                            sw.Close();
                            label1.Text = "保存完了";
                            label3.Text = "文字コード:" + code;
                            hozon1 = "1";
                            backfile = hozon;
                            label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(hozon);
                        }
                        else
                        {
                            if (code == "1")
                            {
                                label1.Text = "保存中";
                                //OKボタンがクリックされたとき、選択されたファイル名を表示する


                                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    hozon,
                    false,
                    System.Text.Encoding.GetEncoding(type));
                                //TextBox1.Textの内容を書き込む
                                sw.Write(text);
                                //閉じる
                                sw.Close();
                                label1.Text = "保存完了";
                                label3.Text = "文字コード:" + type;
                                hozon1 = "1";
                                backfile = hozon;
                                label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(hozon);
                            }
                        }
                    }
                }



            }

        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 名前を付けて保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (code == "utf-8")
            {
                text = richTextBox1.Text;
                label1.Text = "保存中";
                SaveFileDialog sfd = new SaveFileDialog();

                //はじめのファイル名を指定する
                //はじめに「ファイル名」で表示される文字列を指定する
                sfd.FileName = "text.txt";
                //はじめに表示されるフォルダを指定する
                sfd.InitialDirectory = @"C:\";
                //[ファイルの種類]に表示される選択肢を指定する
                //指定しない（空の文字列）の時は、現在のディレクトリが表示される
                sfd.Filter = "すべてのファイル(*.*)|*.txt|テキストファイル(*.txt)|*.txt";
                //[ファイルの種類]ではじめに選択されるものを指定する
                //2番目の「すべてのファイル」が選択されているようにする
                sfd.FilterIndex = 2;
                //タイトルを設定する
                sfd.Title = "保存先のファイルを選択してください";
                //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
                sfd.RestoreDirectory = true;
                //既に存在するファイル名を指定したとき警告する
                //デフォルトでTrueなので指定する必要はない
                sfd.OverwritePrompt = true;
                //存在しないパスが指定されたとき警告を表示する
                //デフォルトでTrueなので指定する必要はない
                sfd.CheckPathExists = true;

                //ダイアログを表示する
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //OKボタンがクリックされたとき、選択されたファイル名を表示する
                    Console.WriteLine(sfd.FileName);
                    hozon = sfd.FileName;
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(
        hozon,
        false,
        System.Text.Encoding.GetEncoding("utf-8"));
                    //TextBox1.Textの内容を書き込む
                    sw.Write(text);
                    //閉じる
                    sw.Close();
                    label1.Text = "保存完了";
                    backfile = hozon;
                    hozon1 = "1";
                    label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(hozon);

                }
            }
            else
            {
                if (code == "shift-jis")
                {
                    text = richTextBox1.Text;
                    label1.Text = "保存中";
                    SaveFileDialog sfd = new SaveFileDialog();

                    //はじめのファイル名を指定する
                    //はじめに「ファイル名」で表示される文字列を指定する
                    sfd.FileName = "text.txt";
                    //はじめに表示されるフォルダを指定する
                    sfd.InitialDirectory = @"C:\";
                    //[ファイルの種類]に表示される選択肢を指定する
                    //指定しない（空の文字列）の時は、現在のディレクトリが表示される
                    sfd.Filter = "すべてのファイル(*.*)|*.txt|テキストファイル(*.txt)|*.txt";
                    //[ファイルの種類]ではじめに選択されるものを指定する
                    //2番目の「すべてのファイル」が選択されているようにする
                    sfd.FilterIndex = 2;
                    //タイトルを設定する
                    sfd.Title = "保存先のファイルを選択してください";
                    //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
                    sfd.RestoreDirectory = true;
                    //既に存在するファイル名を指定したとき警告する
                    //デフォルトでTrueなので指定する必要はない
                    sfd.OverwritePrompt = true;
                    //存在しないパスが指定されたとき警告を表示する
                    //デフォルトでTrueなので指定する必要はない
                    sfd.CheckPathExists = true;

                    //ダイアログを表示する
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        //OKボタンがクリックされたとき、選択されたファイル名を表示する
                        Console.WriteLine(sfd.FileName);
                        hozon = sfd.FileName;
                        System.IO.StreamWriter sw = new System.IO.StreamWriter(
            hozon,
            false,
            System.Text.Encoding.GetEncoding("shift_jis"));
                        //TextBox1.Textの内容を書き込む
                        sw.Write(text);
                        //閉じる
                        sw.Close();
                        label1.Text = "保存完了";
                        hozon1 = "1";
                        backfile = hozon;
                        label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(hozon);

                    }
                }
                else
                {
                    if (code == "ascii")
                    {
                        text = richTextBox1.Text;
                        label1.Text = "保存中";
                        SaveFileDialog sfd = new SaveFileDialog();

                        //はじめのファイル名を指定する
                        //はじめに「ファイル名」で表示される文字列を指定する
                        sfd.FileName = "text.txt";
                        //はじめに表示されるフォルダを指定する
                        sfd.InitialDirectory = @"C:\";
                        //[ファイルの種類]に表示される選択肢を指定する
                        //指定しない（空の文字列）の時は、現在のディレクトリが表示される
                        sfd.Filter = "すべてのファイル(*.*)|*.txt|テキストファイル(*.txt)|*.txt";
                        //[ファイルの種類]ではじめに選択されるものを指定する
                        //2番目の「すべてのファイル」が選択されているようにする
                        sfd.FilterIndex = 2;
                        //タイトルを設定する
                        sfd.Title = "保存先のファイルを選択してください";
                        //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
                        sfd.RestoreDirectory = true;
                        //既に存在するファイル名を指定したとき警告する
                        //デフォルトでTrueなので指定する必要はない
                        sfd.OverwritePrompt = true;
                        //存在しないパスが指定されたとき警告を表示する
                        //デフォルトでTrueなので指定する必要はない
                        sfd.CheckPathExists = true;
                        hozon1 = "1";

                        //ダイアログを表示する
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            //OKボタンがクリックされたとき、選択されたファイル名を表示する
                            Console.WriteLine(sfd.FileName);
                            hozon = sfd.FileName;
                            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                hozon,
                false,
                System.Text.Encoding.GetEncoding("ascii"));
                            //TextBox1.Textの内容を書き込む
                            sw.Write(text);
                            //閉じる
                            sw.Close();
                            label1.Text = "保存完了";
                            hozon1 = "1";
                            backfile = hozon;
                            label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(hozon);

                        }

                    }
                    else
                    {
                        if (code == "1")
                        {
                            MessageBox.Show("上書き保存を押していないか、ファイルの文字コードを指定していない(指定方法:設定→保存設定→文字コード→utf-8(推奨)を選択します",
             "エラー",
             MessageBoxButtons.OK,
             MessageBoxIcon.Error);
                        }
                    }


                }
            }
        }

        private void 文字コードToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void uTF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            code = "utf-8";
            uTF8ToolStripMenuItem.ForeColor = Color.Blue;
            shiftJISToolStripMenuItem.ForeColor = Color.Black;
            aSCIIToolStripMenuItem.ForeColor = Color.Black;
            指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Black;
            label5.Text = "保存する文字コード:" + code;
        }

        private void shiftJISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            code = "shift-jis";
            uTF8ToolStripMenuItem.ForeColor = Color.Black;
            shiftJISToolStripMenuItem.ForeColor = Color.Blue;
            aSCIIToolStripMenuItem.ForeColor = Color.Black;
            指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Black;
            label5.Text = "保存する文字コード:" + code;
        }

        private void aSCIIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            code = "ascii";
            uTF8ToolStripMenuItem.ForeColor = Color.Black;
            shiftJISToolStripMenuItem.ForeColor = Color.Black;
            aSCIIToolStripMenuItem.ForeColor = Color.Blue;
            指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Black;
            label5.Text = "保存する文字コード:" + code;
        }

        private void 設定SToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 表示設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        public static void foo()
        {

        }

        private void ファイルを開くToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hozon1 == "1")
            {
                Console.WriteLine("「はい」が選択されました");
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.FileName = "File";
                    dialog.CheckFileExists = false;

                    if (DialogResult.OK == dialog.ShowDialog())
                    {
                        string[] filenames = dialog.FileNames;


                        file = dialog.FileName;
                        hozon = dialog.FileName;

                        byte[] bytes = null;
                        using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                        {
                            bytes = new byte[fs.Length];
                            fs.Read(bytes, 0, bytes.Length);
                        }
                        string str = null;
                        var encode = ReadJEnc.JP.GetEncoding(bytes, bytes.Length, out str);




                        if (encode != null)
                        {
                            string encodes = encode.ToString();
                            type = encodes;
                            if (encodes == "UTF-8N")
                            {
                                encodes = "UTF-8";
                                type = "utf-8";
                            }
                            if (encodes == "ShiftJIS")
                            {
                                encodes = "shift_jis";
                                type = "shift_jis";
                            }
                            StreamReader sr = new StreamReader(file, Encoding.GetEncoding(encodes));



                            sr.Close();
                            file2 = str;

                            richTextBox1.Text = file2;
                            label3.Text = "文字コード:" + type;
                            label5.Text = "保存する文字コード:同じ";
                            code = "1";
                            uTF8ToolStripMenuItem.ForeColor = Color.Black;
                            shiftJISToolStripMenuItem.ForeColor = Color.Black;
                            aSCIIToolStripMenuItem.ForeColor = Color.Black;
                            指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                            hozon1 = "1";
                            backfile = hozon;
                            label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";
                        }
                        else
                        {

                            DialogResult result = MessageBox.Show("文字コードを認識できませんでした。文字化けする可能性がありますが開きますか？",
                               "警告",
                               MessageBoxButtons.YesNoCancel,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button2);

                            //何が選択されたか調べる
                            if (result == DialogResult.Yes)
                            {



                                StreamReader sr = new StreamReader(file, Encoding.GetEncoding("Shift_jis"));

                                type = "utf-8";
                                string text = sr.ReadToEnd();
                                sr.Close();
                                file2 = text;

                                richTextBox1.Text = file2;
                                label3.Text = "文字コード:" + "不明";
                                label5.Text = "保存する文字コード:ANSI";
                                code = "1";
                                uTF8ToolStripMenuItem.ForeColor = Color.Black;
                                shiftJISToolStripMenuItem.ForeColor = Color.Black;
                                aSCIIToolStripMenuItem.ForeColor = Color.Black;
                                指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                                hozon1 = "1";
                                backfile = hozon;
                                label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";

                            }
                            else if (result == DialogResult.No)
                            {
                                //「いいえ」が選択された時
                                Console.WriteLine("「いいえ」が選択されました");

                            }
                            else if (result == DialogResult.Cancel)
                            {
                                //「キャンセル」が選択された時
                                Console.WriteLine("「キャンセル」が選択されました");

                            }
                        }







                    }
                    else
                    {
                        // キャンセルの場合。なにもしない。
                    }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("保存していませんがファイルを開きますか？",
    "警告",
    MessageBoxButtons.YesNoCancel,
    MessageBoxIcon.Exclamation,
    MessageBoxDefaultButton.Button2);

                //何が選択されたか調べる
                if (result == DialogResult.Yes)
                {
                    if (backfile == "")
                    {

                    }
                    else
                    {
                        //「はい」が選択された時
                        Console.WriteLine("「はい」が選択されました");
                        using (OpenFileDialog dialog = new OpenFileDialog())
                        {
                            dialog.FileName = "File";
                            dialog.CheckFileExists = false;

                            if (DialogResult.OK == dialog.ShowDialog())
                            {
                                string[] filenames = dialog.FileNames;


                                file = dialog.FileName;
                                hozon = dialog.FileName;

                                byte[] bytes = null;
                                using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                                {
                                    bytes = new byte[fs.Length];
                                    fs.Read(bytes, 0, bytes.Length);
                                }
                                string str = null;
                                var encode = ReadJEnc.JP.GetEncoding(bytes, bytes.Length, out str);




                                if (encode != null)
                                {
                                    string encodes = encode.ToString();
                                    type = encodes;
                                    if (encodes == "UTF-8N")
                                    {
                                        encodes = "UTF-8";
                                        type = "utf-8";
                                    }
                                    if (encodes == "ShiftJIS")
                                    {
                                        encodes = "shift_jis";
                                        type = "shift_jis";
                                    }
                                    StreamReader sr = new StreamReader(file, Encoding.GetEncoding(encodes));



                                    sr.Close();
                                    file2 = str;

                                    richTextBox1.Text = file2;
                                    label3.Text = "文字コード:" + type;
                                    label5.Text = "保存する文字コード:同じ";
                                    code = "1";
                                    uTF8ToolStripMenuItem.ForeColor = Color.Black;
                                    shiftJISToolStripMenuItem.ForeColor = Color.Black;
                                    aSCIIToolStripMenuItem.ForeColor = Color.Black;
                                    指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                                    hozon1 = "1";
                                    backfile = hozon;
                                    label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";
                                }
                                else
                                {

                                    DialogResult result1 = MessageBox.Show("文字コードを認識できませんでした。文字化けする可能性がありますが開きますか？",
                                       "警告",
                                       MessageBoxButtons.YesNoCancel,
                                       MessageBoxIcon.Exclamation,
                                       MessageBoxDefaultButton.Button2);

                                    //何が選択されたか調べる
                                    if (result1 == DialogResult.Yes)
                                    {



                                        StreamReader sr = new StreamReader(file, Encoding.GetEncoding("Shift_jis"));

                                        type = "utf-8";
                                        string text = sr.ReadToEnd();
                                        sr.Close();
                                        file2 = text;

                                        richTextBox1.Text = file2;
                                        label3.Text = "文字コード:" + "不明";
                                        label5.Text = "保存する文字コード:ANSI";
                                        code = "1";
                                        uTF8ToolStripMenuItem.ForeColor = Color.Black;
                                        shiftJISToolStripMenuItem.ForeColor = Color.Black;
                                        aSCIIToolStripMenuItem.ForeColor = Color.Black;
                                        指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                                        hozon1 = "1";
                                        backfile = hozon;
                                        label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";
                                        this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";

                                    }
                                    else if (result == DialogResult.No)
                                    {
                                        //「いいえ」が選択された時
                                        Console.WriteLine("「いいえ」が選択されました");

                                    }
                                    else if (result == DialogResult.Cancel)
                                    {
                                        //「キャンセル」が選択された時
                                        Console.WriteLine("「キャンセル」が選択されました");

                                    }
                                }







                            }
                            else
                            {
                                // キャンセルの場合。なにもしない。
                            }
                        }
                    }


                }
                else if (result == DialogResult.No)
                {
                    //「いいえ」が選択された時
                    Console.WriteLine("「いいえ」が選択されました");

                }
                else if (result == DialogResult.Cancel)
                {
                    //「キャンセル」が選択された時
                    Console.WriteLine("「キャンセル」が選択されました");

                }
            }


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
            label1.Text = "書いている途中";
            int mozi = richTextBox1.SelectionStart;
            string a = mozi.ToString();
            string input = richTextBox1.Text.Remove(0, mozi);
            int intLineCnt = input.ToList().Where(c => c.Equals('\n')).Count() + 1;
            string b = intLineCnt.ToString();
            label2.Text = "位置: 行数" + b + "　文字数" + a + "　";
            hozon1 = "0";
            if (autosave == "true")
            {
                text = richTextBox1.Text;
                if (hozon == "nothing")
                {
                    MessageBox.Show("名前を付けて保存をしてください",
                                             "エラー",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Error);
                }
                else
                {
                    if (code == "utf-8")
                    {
                        label1.Text = "保存中";
                        //OKボタンがクリックされたとき、選択されたファイル名を表示する


                        System.IO.StreamWriter sw = new System.IO.StreamWriter(
            hozon,
            false,
            System.Text.Encoding.GetEncoding("utf-8"));
                        //TextBox1.Textの内容を書き込む
                        sw.Write(text);
                        //閉じる
                        sw.Close();
                        label1.Text = "保存完了";
                        label3.Text = "文字コード:" + code;
                        hozon1 = "1";
                        backfile = hozon;
                        label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(hozon);
                    }
                    else
                    {
                        if (code == "shift-jis")
                        {
                            label1.Text = "保存中";
                            hozon1 = "1";
                            //OKボタンがクリックされたとき、選択されたファイル名を表示する


                            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                hozon,
                false,
                System.Text.Encoding.GetEncoding("shift_jis"));
                            //TextBox1.Textの内容を書き込む
                            sw.Write(text);
                            //閉じる
                            sw.Close();
                            label1.Text = "保存完了";
                            label3.Text = "文字コード:" + code;
                            hozon1 = "1";
                            backfile = hozon;
                            label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(hozon);
                        }
                        else
                        {
                            if (code == "ascii")
                            {
                                label1.Text = "保存中";
                                //OKボタンがクリックされたとき、選択されたファイル名を表示する


                                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    hozon,
                    false,
                    System.Text.Encoding.GetEncoding("ascii"));
                                //TextBox1.Textの内容を書き込む
                                sw.Write(text);
                                //閉じる
                                sw.Close();
                                label1.Text = "保存完了";
                                label3.Text = "文字コード:" + code;
                                hozon1 = "1";
                                backfile = hozon;
                                label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(hozon);
                            }
                            else
                            {
                                if (code == "1")
                                {
                                    label1.Text = "保存中";
                                    //OKボタンがクリックされたとき、選択されたファイル名を表示する


                                    System.IO.StreamWriter sw = new System.IO.StreamWriter(
                        hozon,
                        false,
                        System.Text.Encoding.GetEncoding(type));
                                    //TextBox1.Textの内容を書き込む
                                    sw.Write(text);
                                    //閉じる
                                    sw.Close();
                                    label1.Text = "保存完了";
                                    label3.Text = "文字コード:" + type;
                                    hozon1 = "1";
                                    backfile = hozon;
                                    label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(hozon);
                                }
                            }
                        }
                    }



                }
            }
            mozi1 = mozi1 + 1;
            if (autosave == "truea")
            {
                if (mozi1 == 5)
                {
                    mozi1 = 0;
                    text = richTextBox1.Text;
                    if (hozon == "nothing")
                    {
                        MessageBox.Show("名前を付けて保存をしてください",
                                                 "エラー",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (code == "utf-8")
                        {
                            label1.Text = "保存中";
                            //OKボタンがクリックされたとき、選択されたファイル名を表示する


                            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                hozon,
                false,
                System.Text.Encoding.GetEncoding("utf-8"));
                            //TextBox1.Textの内容を書き込む
                            sw.Write(text);
                            //閉じる
                            sw.Close();
                            label1.Text = "保存完了";
                            label3.Text = "文字コード:" + code;
                            hozon1 = "1";
                            backfile = hozon;
                            label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(hozon);
                        }
                        else
                        {
                            if (code == "shift-jis")
                            {
                                label1.Text = "保存中";
                                hozon1 = "1";
                                //OKボタンがクリックされたとき、選択されたファイル名を表示する


                                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    hozon,
                    false,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                                //TextBox1.Textの内容を書き込む
                                sw.Write(text);
                                //閉じる
                                sw.Close();
                                label1.Text = "保存完了";
                                label3.Text = "文字コード:" + code;
                                hozon1 = "1";
                                backfile = hozon;
                                label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(hozon);
                            }
                            else
                            {
                                if (code == "ascii")
                                {
                                    label1.Text = "保存中";
                                    //OKボタンがクリックされたとき、選択されたファイル名を表示する


                                    System.IO.StreamWriter sw = new System.IO.StreamWriter(
                        hozon,
                        false,
                        System.Text.Encoding.GetEncoding("ascii"));
                                    //TextBox1.Textの内容を書き込む
                                    sw.Write(text);
                                    //閉じる
                                    sw.Close();
                                    label1.Text = "保存完了";
                                    label3.Text = "文字コード:" + code;
                                    hozon1 = "1";
                                    backfile = hozon;
                                    label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(hozon);
                                }
                                else
                                {
                                    if (code == "1")
                                    {
                                        label1.Text = "保存中";
                                        //OKボタンがクリックされたとき、選択されたファイル名を表示する


                                        System.IO.StreamWriter sw = new System.IO.StreamWriter(
                            hozon,
                            false,
                            System.Text.Encoding.GetEncoding(type));
                                        //TextBox1.Textの内容を書き込む
                                        sw.Write(text);
                                        //閉じる
                                        sw.Close();
                                        label1.Text = "保存完了";
                                        label3.Text = "文字コード:" + type;
                                        hozon1 = "1";
                                        backfile = hozon;
                                        label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(hozon);
                                    }
                                }
                            }
                        }



                    }
                }
            }







        }


        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 大きさToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 黒ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            黒ToolStripMenuItem.Checked = true;
            赤ToolStripMenuItem.Checked = false;
            青ToolStripMenuItem.Checked = false;
            黄色ToolStripMenuItem.Checked = false;
            オレンジToolStripMenuItem.Checked = false;
            richTextBox1.ForeColor = Color.Black;
            fontcolor = "black";
            int mozi = richTextBox1.SelectionStart;
            string reload = richTextBox1.Text;
            richTextBox1.Text = reload;
            richTextBox1.SelectionStart = mozi;

        }

        private void 赤ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            黒ToolStripMenuItem.Checked = false;
            赤ToolStripMenuItem.Checked = true;
            青ToolStripMenuItem.Checked = false;
            黄色ToolStripMenuItem.Checked = false;
            オレンジToolStripMenuItem.Checked = false;
            緑ToolStripMenuItem.Checked = false;
            richTextBox1.ForeColor = Color.Red;
            fontcolor = "red";
            int mozi = richTextBox1.SelectionStart;
            string reload = richTextBox1.Text;
            richTextBox1.Text = reload;
            richTextBox1.SelectionStart = mozi;
        }

        private void 青ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            黒ToolStripMenuItem.Checked = false;
            赤ToolStripMenuItem.Checked = false;
            青ToolStripMenuItem.Checked = true;
            黄色ToolStripMenuItem.Checked = false;
            オレンジToolStripMenuItem.Checked = false;
            緑ToolStripMenuItem.Checked = false;
            richTextBox1.ForeColor = Color.Blue;
            fontcolor = "blue";
            int mozi = richTextBox1.SelectionStart;
            string reload = richTextBox1.Text;
            richTextBox1.Text = reload;
            richTextBox1.SelectionStart = mozi;
        }

        private void 黄色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            黒ToolStripMenuItem.Checked = false;
            赤ToolStripMenuItem.Checked = false;
            青ToolStripMenuItem.Checked = false;
            黄色ToolStripMenuItem.Checked = true;
            オレンジToolStripMenuItem.Checked = false;
            緑ToolStripMenuItem.Checked = false;
            fontcolor = "yellow";
            richTextBox1.ForeColor = Color.Yellow;
            int mozi = richTextBox1.SelectionStart;
            string reload = richTextBox1.Text;
            richTextBox1.Text = reload;
            richTextBox1.SelectionStart = mozi;
        }

        private void オレンジToolStripMenuItem_Click(object sender, EventArgs e)
        {
            黒ToolStripMenuItem.Checked = false;
            赤ToolStripMenuItem.Checked = false;
            青ToolStripMenuItem.Checked = false;
            黄色ToolStripMenuItem.Checked = false;
            オレンジToolStripMenuItem.Checked = true;
            緑ToolStripMenuItem.Checked = false;
            fontcolor = "orange";
            richTextBox1.ForeColor = Color.Orange;
            int mozi = richTextBox1.SelectionStart;
            string reload = richTextBox1.Text;
            richTextBox1.Text = reload;
            richTextBox1.SelectionStart = mozi;
        }

        private void 緑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            黒ToolStripMenuItem.Checked = false;
            赤ToolStripMenuItem.Checked = false;
            青ToolStripMenuItem.Checked = false;
            黄色ToolStripMenuItem.Checked = false;
            オレンジToolStripMenuItem.Checked = false;
            緑ToolStripMenuItem.Checked = true;
            fontcolor = "green";
            richTextBox1.ForeColor = Color.Green;
            int mozi = richTextBox1.SelectionStart;
            string reload = richTextBox1.Text;
            richTextBox1.Text = reload;
            richTextBox1.SelectionStart = mozi;
        }

        private void 全ての設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FontDialogクラスのインスタンスを作成
            FontDialog fd = new FontDialog();

            //初期のフォントを設定
            fd.Font = richTextBox1.Font;
            //初期の色を設定
            fd.Color = richTextBox1.ForeColor;
            //ユーザーが選択できるポイントサイズの最大値を設定する
            fd.MaxSize = 500;
            fd.MinSize = 10;
            //存在しないフォントやスタイルをユーザーが選択すると
            //エラーメッセージを表示する
            fd.FontMustExist = true;
            //横書きフォントだけを表示する
            fd.AllowVerticalFonts = false;
            //色を選択できるようにする
            fd.ShowColor = true;
            //取り消し線、下線、テキストの色などのオプションを指定可能にする
            //デフォルトがTrueのため必要はない
            fd.ShowEffects = true;
            //固定ピッチフォント以外も表示する
            //デフォルトがFalseのため必要はない
            fd.FixedPitchOnly = false;
            //ベクタ フォントを選択できるようにする
            //デフォルトがTrueのため必要はない
            fd.AllowVectorFonts = true;

            //ダイアログを表示する
            if (fd.ShowDialog() != DialogResult.Cancel)
            {
                //TextBox1のフォントと色を変える
                richTextBox1.Font = fd.Font;
                richTextBox1.ForeColor = fd.Color;
                int mozi = richTextBox1.SelectionStart;
                string reload = richTextBox1.Text;
                richTextBox1.Text = reload;
                richTextBox1.SelectionStart = mozi;
                richTextBox1.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
            }
        }

        private void 指定なし前のファイルのままToolStripMenuItem_Click(object sender, EventArgs e)
        {
            code = "1";
            uTF8ToolStripMenuItem.ForeColor = Color.Black;
            shiftJISToolStripMenuItem.ForeColor = Color.Black;
            aSCIIToolStripMenuItem.ForeColor = Color.Black;
            指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
            label5.Text = "保存する文字コード:" + "前のファイルのまま";
        }

        private void undoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo == true)
            {
                // ★★★ Undoを実行する ★★★
                richTextBox1.Undo();
            }

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo == true)
            {
                // ★★★ Undoを実行する ★★★
                richTextBox1.Redo();
            }
        }

        private void richTextBox1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int mozi = richTextBox1.SelectionStart;
            if (mozi == richTextBox1.Text.Length)
            {

            }
            else
            {

                string a = mozi.ToString();
                string input = richTextBox1.Text.Remove(mozi);
                int intLineCnt = input.ToList().Where(c => c.Equals('\n')).Count() + 1;
                string b = intLineCnt.ToString();
                label2.Text = "位置: 行数" + b + "　文字数" + a + "　";
            }
        }
        private bool _bScreenMode;
        // フルスクリーン表示前のウィンドウの状態を保存する
        private FormWindowState prevFormState;
        // 通常表示時のフォームの境界線スタイルを保存する
        private FormBorderStyle prevFormStyle;
        // 通常表示時のウィンドウのサイズを保存する
        private Size prevFormSize;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "メモ帳君old.exe"))
            {
                File.Delete(System.AppDomain.CurrentDomain.BaseDirectory + "メモ帳君old.exe");

            }
            if (System.IO.File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "Hnx8.ReadJEnc.dll"))
            {


            }
            else
            {
                var url1 = "https://pkki.github.io/-notepad-you/Hnx8.ReadJEnc.dll";

                // WebClientでファイルを保存します。
                var baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
                var client = new WebClient();
                client.DownloadFile(url1, baseDir + "Hnx8.ReadJEnc.dll");
            }
            hozon1 = "1";
            richTextBox1.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
            this.Text = "無題-メモ帳君";
            style = Properties.Settings.Default.style;
            if (style == "black")
            {
                ブラックToolStripMenuItem.Checked = true;
                ホワイトToolStripMenuItem.Checked = false;
                richTextBox1.BackColor = Color.FromArgb(40, 44, 52);
                richTextBox1.ForeColor = Color.FromArgb(214, 214, 214);
                this.BackColor = Color.FromArgb(21, 25, 31);
                label1.ForeColor = Color.FromArgb(216, 216, 216);
                label2.ForeColor = Color.FromArgb(216, 216, 216);
                label3.ForeColor = Color.FromArgb(216, 216, 216);
                label4.ForeColor = Color.FromArgb(216, 216, 216);
                label5.ForeColor = Color.FromArgb(216, 216, 216);
            }
            else
            {
                ブラックToolStripMenuItem.Checked = false;
                ホワイトToolStripMenuItem.Checked = true;
                richTextBox1.BackColor = Color.FromArgb(240, 240, 240);
                richTextBox1.ForeColor = Color.Black;
                this.BackColor = Color.White;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
            }
            prevFormState = FormWindowState.Normal;
            // 通常表示時のフォームの境界線スタイルを保存する
            prevFormStyle = FormBorderStyle.Sizable;
            // 通常表示時のウィンドウのサイズを保存する
            prevFormSize = new Size(496, 219);
            ステータスバーToolStripMenuItem.Checked = true;

            label7.Visible = false;
            backfile = Properties.Settings.Default.backfile;
            backfile1 = Properties.Settings.Default.backfile1;
            backfile2 = Properties.Settings.Default.backfile2;
            backfile3 = Properties.Settings.Default.backfile3;
            backfile4 = Properties.Settings.Default.backfile4;
            richTextBox1.Multiline = true;
            //垂直、水平両方のスクロールバーを表示

            //ワードラップを無効にする
            richTextBox1.WordWrap = false;
            有効ToolStripMenuItem.Checked = false;
            無効ToolStripMenuItem.Checked = true;
            link = "false";
            richTextBox1.DetectUrls = false;
            ありませんToolStripMenuItem.Text = backfile;
            ありませんToolStripMenuItem1.Text = backfile1;
            ありませんToolStripMenuItem2.Text = backfile2;
            ありませんToolStripMenuItem3.Text = backfile3;
            ありませんToolStripMenuItem4.Text = backfile4;

            string path = Application.ExecutablePath;




            string[] Commands = System.Environment.GetCommandLineArgs();
            for (int i = 0; i < Commands.Length; i++)
            {
                label7.Text += string.Format(Commands[i]);
            }
            string command = label7.Text;
            after = command.Replace(path, "");
            if (after == "")
            {

            }
            else
            {
                file = after;
                hozon = after;

                byte[] bytes = null;
                using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                }
                string str = null;
                var encode = ReadJEnc.JP.GetEncoding(bytes, bytes.Length, out str);




                if (encode != null)
                {
                    string encodes = encode.ToString();
                    type = encodes;
                    if (encodes == "UTF-8N")
                    {
                        encodes = "UTF-8";
                        type = "utf-8";
                    }
                    if (encodes == "ShiftJIS")
                    {
                        encodes = "shift_jis";
                        type = "shift_jis";
                    }
                    StreamReader sr = new StreamReader(file, Encoding.GetEncoding(encodes));



                    sr.Close();
                    file2 = str;

                    richTextBox1.Text = file2;
                    label3.Text = "文字コード:" + type;
                    label5.Text = "保存する文字コード:同じ";
                    code = "1";
                    uTF8ToolStripMenuItem.ForeColor = Color.Black;
                    shiftJISToolStripMenuItem.ForeColor = Color.Black;
                    aSCIIToolStripMenuItem.ForeColor = Color.Black;
                    指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                    hozon1 = "1";
                    backfile = hozon;
                    label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";
                }
                else
                {

                    DialogResult result = MessageBox.Show("文字コードを認識できませんでした。文字化けする可能性がありますが開きますか？",
                       "警告",
                       MessageBoxButtons.YesNoCancel,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.Yes)
                    {



                        StreamReader sr = new StreamReader(file, Encoding.GetEncoding("Shift_jis"));

                        type = "utf-8";
                        string text = sr.ReadToEnd();
                        sr.Close();
                        file2 = text;

                        richTextBox1.Text = file2;
                        label3.Text = "文字コード:" + "不明";
                        label5.Text = "保存する文字コード:ANSI";
                        code = "1";
                        uTF8ToolStripMenuItem.ForeColor = Color.Black;
                        shiftJISToolStripMenuItem.ForeColor = Color.Black;
                        aSCIIToolStripMenuItem.ForeColor = Color.Black;
                        指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                        hozon1 = "1";
                        backfile = hozon;
                        label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君"; this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";


                    }
                    else if (result == DialogResult.No)
                    {
                        //「いいえ」が選択された時
                        Console.WriteLine("「いいえ」が選択されました");

                    }
                    else if (result == DialogResult.Cancel)
                    {
                        //「キャンセル」が選択された時
                        Console.WriteLine("「キャンセル」が選択されました");

                    }
                }
            }
            if (Properties.Settings.Default.link == "on")
            {
                有効ToolStripMenuItem.Checked = true;
                無効ToolStripMenuItem.Checked = false;
                link = "true";
                richTextBox1.DetectUrls = true;
            }
            else
            {
                有効ToolStripMenuItem.Checked = false;
                無効ToolStripMenuItem.Checked = true;
                link = "false";
                richTextBox1.DetectUrls = false;
            }
            richTextBox1.SelectionFont = Properties.Settings.Default.fontsetting;
            richTextBox1.ForeColor = Properties.Settings.Default.color;
            一文字ずつセーブToolStripMenuItem.Checked = false;
            時間セーブToolStripMenuItem.Checked = false;
            無しToolStripMenuItem.Checked = true;
            hozon1 = "1";


        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            richTextBox1.Font = Properties.Settings.Default.fontsetting;
            richTextBox1.ForeColor = Properties.Settings.Default.color;
            richTextBox1.LanguageOption = RichTextBoxLanguageOptions.UIFonts;
            int mozi = richTextBox1.SelectionStart;
            string reload = richTextBox1.Text;
            richTextBox1.Text = reload;
            richTextBox1.SelectionStart = mozi;
            hozon1 = "1";

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void 日付日時ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 有効ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            有効ToolStripMenuItem.Checked = true;
            無効ToolStripMenuItem.Checked = false;
            link = "true";
            richTextBox1.DetectUrls = true;

        }

        private void 無効ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            有効ToolStripMenuItem.Checked = false;
            無効ToolStripMenuItem.Checked = true;
            richTextBox1.DetectUrls = false;
            link = "false";
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (link == "true")
            {
                System.Diagnostics.Process.Start(e.LinkText);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saiki == "0")
            {
                if (hozon1 == "1")
                {
                    Console.WriteLine("「はい」が選択されました");
                    if (backfile == ありませんToolStripMenuItem.Text)
                    {

                    }
                    else
                    {
                        Properties.Settings.Default.backfile4 = ありませんToolStripMenuItem3.Text;
                        Properties.Settings.Default.backfile3 = ありませんToolStripMenuItem2.Text;
                        Properties.Settings.Default.backfile2 = ありませんToolStripMenuItem1.Text;
                        Properties.Settings.Default.backfile1 = ありませんToolStripMenuItem.Text;
                        Properties.Settings.Default.backfile = backfile;
                        Properties.Settings.Default.Save();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("保存していませんが終了しますか？",
        "警告",
        MessageBoxButtons.YesNoCancel,
        MessageBoxIcon.Exclamation,
        MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.Yes)
                    {
                        if (backfile == "")
                        {

                        }
                        else
                        {
                            //「はい」が選択された時
                            Console.WriteLine("「はい」が選択されました");
                            if (backfile == ありませんToolStripMenuItem.Text)
                            {

                            }
                            else
                            {
                                Properties.Settings.Default.backfile4 = ありませんToolStripMenuItem3.Text;
                                Properties.Settings.Default.backfile3 = ありませんToolStripMenuItem2.Text;
                                Properties.Settings.Default.backfile2 = ありませんToolStripMenuItem1.Text;
                                Properties.Settings.Default.backfile1 = ありませんToolStripMenuItem.Text;
                                Properties.Settings.Default.backfile = backfile;
                                Properties.Settings.Default.Save();
                            }
                        }


                    }
                    else if (result == DialogResult.No)
                    {
                        //「いいえ」が選択された時
                        Console.WriteLine("「いいえ」が選択されました");
                        e.Cancel = true;
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        //「キャンセル」が選択された時
                        Console.WriteLine("「キャンセル」が選択されました");
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                if (saiki == "2")
                {

                }
                else
                {
                    var proc = new System.Diagnostics.Process();
                    string a = System.AppDomain.CurrentDomain.BaseDirectory;
                    proc.StartInfo.FileName = a + "メモ帳君.exe";
                    proc.Start();
                }
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ありませんToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (backfile == "nothing")
            {

            }
            else
            {
                file = ありませんToolStripMenuItem.Text;
                hozon = ありませんToolStripMenuItem.Text;

                byte[] bytes = null;
                using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                }
                string str = null;
                var encode = ReadJEnc.JP.GetEncoding(bytes, bytes.Length, out str);




                if (encode != null)
                {
                    string encodes = encode.ToString();
                    type = encodes;
                    if (encodes == "UTF-8N")
                    {
                        encodes = "UTF-8";
                        type = "utf-8";
                    }
                    if (encodes == "ShiftJIS")
                    {
                        encodes = "shift_jis";
                        type = "shift_jis";
                    }
                    StreamReader sr = new StreamReader(file, Encoding.GetEncoding(encodes));



                    sr.Close();
                    file2 = str;

                    richTextBox1.Text = file2;
                    label3.Text = "文字コード:" + type;
                    label5.Text = "保存する文字コード:同じ";
                    code = "1";
                    uTF8ToolStripMenuItem.ForeColor = Color.Black;
                    shiftJISToolStripMenuItem.ForeColor = Color.Black;
                    aSCIIToolStripMenuItem.ForeColor = Color.Black;
                    指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                    hozon1 = "1";
                    backfile = hozon;
                    label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";
                }
                else
                {

                    DialogResult result = MessageBox.Show("文字コードを認識できませんでした。文字化けする可能性がありますが開きますか？",
                       "警告",
                       MessageBoxButtons.YesNoCancel,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.Yes)
                    {



                        StreamReader sr = new StreamReader(file, Encoding.GetEncoding("Shift_jis"));

                        type = "utf-8";
                        string text = sr.ReadToEnd();
                        sr.Close();
                        file2 = text;

                        richTextBox1.Text = file2;
                        label3.Text = "文字コード:" + "不明";
                        label5.Text = "保存する文字コード:ANSI";
                        code = "1";
                        uTF8ToolStripMenuItem.ForeColor = Color.Black;
                        shiftJISToolStripMenuItem.ForeColor = Color.Black;
                        aSCIIToolStripMenuItem.ForeColor = Color.Black;
                        指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                        hozon1 = "1";
                        backfile = hozon;
                        label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";

                    }
                    else if (result == DialogResult.No)
                    {
                        //「いいえ」が選択された時
                        Console.WriteLine("「いいえ」が選択されました");

                    }
                    else if (result == DialogResult.Cancel)
                    {
                        //「キャンセル」が選択された時
                        Console.WriteLine("「キャンセル」が選択されました");

                    }
                }
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            for (int i = 0; i < files.Length; i++)
            {

                file = files[i]; ;
                hozon = files[i]; ;

                byte[] bytes = null;
                using (var fs = new FileStream(file, FileMode.Open))
                {
                    bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                }
                string str = null;
                var encode = ReadJEnc.JP.GetEncoding(bytes, bytes.Length, out str);
                string encodes = encode.ToString();
                type = encodes;


                if (encodes == null)
                {


                    MessageBox.Show("このファイルの文字コードを識別できなかったためこのファイルは変換不可能です",
              "エラー",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error);
                }
                else
                {
                    if (encodes == "UTF-8N")
                    {
                        encodes = "UTF-8";
                        type = "utf-8";
                    }
                }
                StreamReader sr = new StreamReader(file, Encoding.GetEncoding(encodes));



                sr.Close();
                file2 = str;
                richTextBox1.Text = file2;
                label3.Text = "文字コード:" + type;
                code = "1";
                uTF8ToolStripMenuItem.ForeColor = Color.Black;
                shiftJISToolStripMenuItem.ForeColor = Color.Black;
                aSCIIToolStripMenuItem.ForeColor = Color.Black;
                指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                hozon1 = "1";
                backfile = hozon;
                label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void 戻すundoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void 切り取りTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void コピーCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = richTextBox1.Text;

            //文字列を置換する（「にわ」を「庭」に置換する）
            string r1 = s.Replace(textBox1.Text, textBox2.Text);
            //庭には庭庭とりがいる。
            richTextBox1.Text = r1;
        }

        private void 印刷をするToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //印刷する文字列と位置を設定する
            printingText = richTextBox1.Text;
            printingPosition = 0;
            //印刷に使うフォントを指定する
            printFont = richTextBox1.SelectionFont;
            //PrintDocumentオブジェクトの作成
            System.Drawing.Printing.PrintDocument pd =
                new System.Drawing.Printing.PrintDocument();
            //PrintPageイベントハンドラの追加
            pd.PrintPage +=
                new System.Drawing.Printing.PrintPageEventHandler(pd_PrintPage);
            //印刷を開始する
            pd.Print();
        }
        private void pd_PrintPage(object sender,
    System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (printingPosition == 0)
            {
                //改行記号を'\n'に統一する
                printingText = printingText.Replace("\r\n", "\n");
                printingText = printingText.Replace("\r", "\n");
            }

            //印刷する初期位置を決定
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;

            //1ページに収まらなくなるか、印刷する文字がなくなるかまでループ
            while (e.MarginBounds.Bottom > y + printFont.Height &&
                printingPosition < printingText.Length)
            {
                string line = "";
                for (; ; )
                {
                    //印刷する文字がなくなるか、
                    //改行の時はループから抜けて印刷する
                    if (printingPosition >= printingText.Length ||
                        printingText[printingPosition] == '\n')
                    {
                        printingPosition++;
                        break;
                    }
                    //一文字追加し、印刷幅を超えるか調べる
                    line += printingText[printingPosition];
                    if (e.Graphics.MeasureString(line, printFont).Width
                        > e.MarginBounds.Width)
                    {
                        //印刷幅を超えたため、折り返す
                        line = line.Substring(0, line.Length - 1);
                        break;
                    }
                    //印刷文字位置を次へ
                    printingPosition++;
                }
                //一行書き出す
                e.Graphics.DrawString(line, printFont, Brushes.Black, x, y);
                //次の行の印刷位置を計算
                y += (int)printFont.GetHeight(e.Graphics);
            }

            //次のページがあるか調べる
            if (printingPosition >= printingText.Length)
            {
                e.HasMorePages = false;
                //初期化する
                printingPosition = 0;
            }
            else
                e.HasMorePages = true;
        }

        private void コピーToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void ペーストToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void 切り取りToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void すべて選択ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void すべて選択ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void 設定を保存suruToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.fontsetting = richTextBox1.SelectionFont;
            Properties.Settings.Default.color = richTextBox1.ForeColor;
            if (ブラックToolStripMenuItem.Checked == true)
            {
                Properties.Settings.Default.style = "black";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.style = "white";
                Properties.Settings.Default.Save();
            }
            Properties.Settings.Default.Save();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void 設定をリセットするToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font("UD デジタル 教科書体 NK-R", 15, GraphicsUnit.Pixel);
            richTextBox1.ForeColor = Color.White;
        }

        private void この設定を保存するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (link == "true")
            {

                Properties.Settings.Default.link = "on";


                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.link = "off";
                Properties.Settings.Default.Save();
            }
        }

        private void ステータスバーToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ステータスバーToolStripMenuItem.Checked == System.Convert.ToBoolean("true"))
            {
                ステータスバーToolStripMenuItem.Checked = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                richTextBox1.Height = richTextBox1.Height + 15;


            }
            else
            {
                ステータスバーToolStripMenuItem.Checked = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                richTextBox1.Height = richTextBox1.Height - 15;
            }
        }

        private void ズームToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.ZoomFactor > 56.5)
            {

            }
            else
            {
                richTextBox1.ZoomFactor = 1.5f + richTextBox1.ZoomFactor;
                倍率1倍ToolStripMenuItem.Text = "倍率(" + richTextBox1.ZoomFactor + "倍)";
            }
        }

        private void ズームToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.ZoomFactor < 1.5)
            {

            }
            else
            {
                richTextBox1.ZoomFactor = richTextBox1.ZoomFactor - 1.5f;
                倍率1倍ToolStripMenuItem.Text = "倍率(" + richTextBox1.ZoomFactor + "倍)";
            }
        }

        private void 初期値ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor = 1.0f;
        }

        private void 改行したときに日付を追加するToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (改行したときに日付を追加するToolStripMenuItem.Checked == System.Convert.ToBoolean("true"))
            {
                改行したときに日付を追加するToolStripMenuItem.Checked = false;



            }
            else
            {
                改行したときに日付を追加するToolStripMenuItem.Checked = true;

            }
        }

        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (改行したときに日付を追加するToolStripMenuItem.Checked == true)
            {

                if (e.KeyCode == Keys.Enter)
                {
                    int mozi = richTextBox1.SelectionStart;
                    if (mozi == richTextBox1.Text.Length)
                    {
                        SendMessage(this.richTextBox1.Handle, 0x04DD, 0, ref pos);
                        string itiziteki = richTextBox1.Text;
                        string a = itiziteki;
                        int kekka = richTextBox1.Text.Length - mozi;
                        string e01 = itiziteki.Remove(0, richTextBox1.Text.Length - kekka);

                        richTextBox1.Text = a + DateTime.Now + e01;
                        string time = DateTime.Now.ToString();
                        int mozisuu = time.Length;
                        richTextBox1.SelectionStart = mozi + mozisuu;
                        SendMessage(this.richTextBox1.Handle, 0x04DE, 0, ref pos);
                    }
                    else
                    {
                        SendMessage(this.richTextBox1.Handle, 0x04DD, 0, ref pos);
                        string itiziteki = richTextBox1.Text;
                        string a = itiziteki.Remove(mozi);
                        int kekka = richTextBox1.Text.Length - mozi;
                        string e01 = itiziteki.Remove(0, richTextBox1.Text.Length - kekka);

                        richTextBox1.Text = a + DateTime.Now + e01;
                        string time = DateTime.Now.ToString();
                        int mozisuu = time.Length;
                        richTextBox1.SelectionStart = mozi + mozisuu;
                        SendMessage(this.richTextBox1.Handle, 0x04DE, 0, ref pos);
                    }
                }

            }
        }

        private void 日付日時ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int mozi = richTextBox1.SelectionStart;
            if (mozi == richTextBox1.Text.Length)
            {
                SendMessage(this.richTextBox1.Handle, 0x04DD, 0, ref pos);
                string itiziteki = richTextBox1.Text;
                richTextBox1.Text = itiziteki + DateTime.Now;
                string time = DateTime.Now.ToString();
                int mozisuu = time.Length;
                richTextBox1.SelectionStart = mozi + mozisuu;
                SendMessage(this.richTextBox1.Handle, 0x04DE, 0, ref pos);
            }
            else
            {
                SendMessage(this.richTextBox1.Handle, 0x04DD, 0, ref pos);
                richTextBox1.Focus();
                string itiziteki = richTextBox1.Text;
                richTextBox1.Text = itiziteki.Insert(mozi, DateTime.Now.ToString());
                string time = DateTime.Now.ToString();
                int mozisuu = time.Length;
                richTextBox1.SelectionStart = mozi + mozisuu;
                SendMessage(this.richTextBox1.Handle, 0x04DE, 0, ref pos);

            }
        }

        private void オートセーブToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ファイルToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 一文字ずつセーブToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label4.Text == "ファイルの名前:")
            {
                MessageBox.Show("ファイルを先に保存してください(名前を付けて保存してください)",
             "エラー",
             MessageBoxButtons.OK,
             MessageBoxIcon.Error);
            }
            else
            {
                if (一文字ずつセーブToolStripMenuItem.Checked == System.Convert.ToBoolean("true"))
                {
                    一文字ずつセーブToolStripMenuItem.Checked = false;
                    時間セーブToolStripMenuItem.Checked = false;
                    無しToolStripMenuItem.Checked = false;
                    autosave = "false";


                }
                else
                {
                    一文字ずつセーブToolStripMenuItem.Checked = true;
                    時間セーブToolStripMenuItem.Checked = false;
                    無しToolStripMenuItem.Checked = false;
                    autosave = "true";

                }
            }
        }

        private void 時間セーブToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label4.Text == "ファイルの名前:")
            {
                MessageBox.Show("ファイルを先に保存してください(名前を付けて保存してください)",
             "エラー",
             MessageBoxButtons.OK,
             MessageBoxIcon.Error);
            }
            else
            {
                if (時間セーブToolStripMenuItem.Checked == System.Convert.ToBoolean("true"))
                {
                    一文字ずつセーブToolStripMenuItem.Checked = false;
                    時間セーブToolStripMenuItem.Checked = false;
                    無しToolStripMenuItem.Checked = false;
                    autosave = "false";


                }
                else
                {
                    一文字ずつセーブToolStripMenuItem.Checked = false;
                    時間セーブToolStripMenuItem.Checked = true;
                    無しToolStripMenuItem.Checked = false;
                    autosave = "truea";

                }
            }
        }

        private void 無しToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (無しToolStripMenuItem.Checked == System.Convert.ToBoolean("true"))
            {
                一文字ずつセーブToolStripMenuItem.Checked = false;
                時間セーブToolStripMenuItem.Checked = false;
                無しToolStripMenuItem.Checked = false;


            }
            else
            {
                一文字ずつセーブToolStripMenuItem.Checked = false;
                時間セーブToolStripMenuItem.Checked = false;
                無しToolStripMenuItem.Checked = true;


            }
        }

        private void ありませんToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (backfile1 == "nothing")
            {

            }
            else
            {
                file = ありませんToolStripMenuItem1.Text;
                hozon = ありませんToolStripMenuItem1.Text;

                byte[] bytes = null;
                using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                }
                string str = null;
                var encode = ReadJEnc.JP.GetEncoding(bytes, bytes.Length, out str);




                if (encode != null)
                {
                    string encodes = encode.ToString();
                    type = encodes;
                    if (encodes == "UTF-8N")
                    {
                        encodes = "UTF-8";
                        type = "utf-8";
                    }
                    if (encodes == "ShiftJIS")
                    {
                        encodes = "shift_jis";
                        type = "shift_jis";
                    }
                    StreamReader sr = new StreamReader(file, Encoding.GetEncoding(encodes));



                    sr.Close();
                    file2 = str;

                    richTextBox1.Text = file2;
                    label3.Text = "文字コード:" + type;
                    label5.Text = "保存する文字コード:同じ";
                    code = "1";
                    uTF8ToolStripMenuItem.ForeColor = Color.Black;
                    shiftJISToolStripMenuItem.ForeColor = Color.Black;
                    aSCIIToolStripMenuItem.ForeColor = Color.Black;
                    指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                    hozon1 = "1";
                    backfile = hozon;
                    label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";
                }
                else
                {

                    DialogResult result = MessageBox.Show("文字コードを認識できませんでした。文字化けする可能性がありますが開きますか？",
                       "警告",
                       MessageBoxButtons.YesNoCancel,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.Yes)
                    {



                        StreamReader sr = new StreamReader(file, Encoding.GetEncoding("Shift_jis"));

                        type = "utf-8";
                        string text = sr.ReadToEnd();
                        sr.Close();
                        file2 = text;

                        richTextBox1.Text = file2;
                        label3.Text = "文字コード:" + "不明";
                        label5.Text = "保存する文字コード:ANSI";
                        code = "1";
                        uTF8ToolStripMenuItem.ForeColor = Color.Black;
                        shiftJISToolStripMenuItem.ForeColor = Color.Black;
                        aSCIIToolStripMenuItem.ForeColor = Color.Black;
                        指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                        hozon1 = "1";
                        backfile = hozon;
                        label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";

                    }
                    else if (result == DialogResult.No)
                    {
                        //「いいえ」が選択された時
                        Console.WriteLine("「いいえ」が選択されました");

                    }
                    else if (result == DialogResult.Cancel)
                    {
                        //「キャンセル」が選択された時
                        Console.WriteLine("「キャンセル」が選択されました");

                    }
                }
            }
        }

        private void ありませんToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (backfile2 == "nothing")
            {

            }
            else
            {
                file = ありませんToolStripMenuItem2.Text;
                hozon = ありませんToolStripMenuItem2.Text;

                byte[] bytes = null;
                using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                }
                string str = null;
                var encode = ReadJEnc.JP.GetEncoding(bytes, bytes.Length, out str);




                if (encode != null)
                {
                    string encodes = encode.ToString();
                    type = encodes;
                    if (encodes == "UTF-8N")
                    {
                        encodes = "UTF-8";
                        type = "utf-8";
                    }
                    if (encodes == "ShiftJIS")
                    {
                        encodes = "shift_jis";
                        type = "shift_jis";
                    }
                    StreamReader sr = new StreamReader(file, Encoding.GetEncoding(encodes));



                    sr.Close();
                    file2 = str;

                    richTextBox1.Text = file2;
                    label3.Text = "文字コード:" + type;
                    label5.Text = "保存する文字コード:同じ";
                    code = "1";
                    uTF8ToolStripMenuItem.ForeColor = Color.Black;
                    shiftJISToolStripMenuItem.ForeColor = Color.Black;
                    aSCIIToolStripMenuItem.ForeColor = Color.Black;
                    指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                    hozon1 = "1";
                    backfile = hozon;
                    label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";
                }
                else
                {

                    DialogResult result = MessageBox.Show("文字コードを認識できませんでした。文字化けする可能性がありますが開きますか？",
                       "警告",
                       MessageBoxButtons.YesNoCancel,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.Yes)
                    {



                        StreamReader sr = new StreamReader(file, Encoding.GetEncoding("Shift_jis"));

                        type = "utf-8";
                        string text = sr.ReadToEnd();
                        sr.Close();
                        file2 = text;

                        richTextBox1.Text = file2;
                        label3.Text = "文字コード:" + "不明";
                        label5.Text = "保存する文字コード:ANSI";
                        code = "1";
                        uTF8ToolStripMenuItem.ForeColor = Color.Black;
                        shiftJISToolStripMenuItem.ForeColor = Color.Black;
                        aSCIIToolStripMenuItem.ForeColor = Color.Black;
                        指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                        hozon1 = "1";
                        backfile = hozon;
                        label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";

                    }
                    else if (result == DialogResult.No)
                    {
                        //「いいえ」が選択された時
                        Console.WriteLine("「いいえ」が選択されました");

                    }
                    else if (result == DialogResult.Cancel)
                    {
                        //「キャンセル」が選択された時
                        Console.WriteLine("「キャンセル」が選択されました");

                    }
                }
            }
        }

        private void ありませんToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (backfile3 == "nothing")
            {

            }
            else
            {
                file = ありませんToolStripMenuItem3.Text;
                hozon = ありませんToolStripMenuItem3.Text;

                byte[] bytes = null;
                using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                }
                string str = null;
                var encode = ReadJEnc.JP.GetEncoding(bytes, bytes.Length, out str);




                if (encode != null)
                {
                    string encodes = encode.ToString();
                    type = encodes;
                    if (encodes == "UTF-8N")
                    {
                        encodes = "UTF-8";
                        type = "utf-8";
                    }
                    if (encodes == "ShiftJIS")
                    {
                        encodes = "shift_jis";
                        type = "shift_jis";
                    }
                    StreamReader sr = new StreamReader(file, Encoding.GetEncoding(encodes));



                    sr.Close();
                    file2 = str;

                    richTextBox1.Text = file2;
                    label3.Text = "文字コード:" + type;
                    label5.Text = "保存する文字コード:同じ";
                    code = "1";
                    uTF8ToolStripMenuItem.ForeColor = Color.Black;
                    shiftJISToolStripMenuItem.ForeColor = Color.Black;
                    aSCIIToolStripMenuItem.ForeColor = Color.Black;
                    指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                    hozon1 = "1";
                    backfile = hozon;
                    label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";
                }
                else
                {

                    DialogResult result = MessageBox.Show("文字コードを認識できませんでした。文字化けする可能性がありますが開きますか？",
                       "警告",
                       MessageBoxButtons.YesNoCancel,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.Yes)
                    {



                        StreamReader sr = new StreamReader(file, Encoding.GetEncoding("Shift_jis"));

                        type = "utf-8";
                        string text = sr.ReadToEnd();
                        sr.Close();
                        file2 = text;

                        richTextBox1.Text = file2;
                        label3.Text = "文字コード:" + "不明";
                        label5.Text = "保存する文字コード:ANSI";
                        code = "1";
                        uTF8ToolStripMenuItem.ForeColor = Color.Black;
                        shiftJISToolStripMenuItem.ForeColor = Color.Black;
                        aSCIIToolStripMenuItem.ForeColor = Color.Black;
                        指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                        hozon1 = "1";
                        backfile = hozon;
                        label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";

                    }
                    else if (result == DialogResult.No)
                    {
                        //「いいえ」が選択された時
                        Console.WriteLine("「いいえ」が選択されました");

                    }
                    else if (result == DialogResult.Cancel)
                    {
                        //「キャンセル」が選択された時
                        Console.WriteLine("「キャンセル」が選択されました");

                    }
                }
            }
        }

        private void ありませんToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (backfile4 == "nothing")
            {

            }
            else
            {
                file = ありませんToolStripMenuItem4.Text;
                hozon = ありませんToolStripMenuItem4.Text;

                byte[] bytes = null;
                using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                }
                string str = null;
                var encode = ReadJEnc.JP.GetEncoding(bytes, bytes.Length, out str);




                if (encode != null)
                {
                    string encodes = encode.ToString();
                    type = encodes;
                    if (encodes == "UTF-8N")
                    {
                        encodes = "UTF-8";
                        type = "utf-8";
                    }
                    if (encodes == "ShiftJIS")
                    {
                        encodes = "shift_jis";
                        type = "shift_jis";
                    }
                    StreamReader sr = new StreamReader(file, Encoding.GetEncoding(encodes));



                    sr.Close();
                    file2 = str;

                    richTextBox1.Text = file2;
                    label3.Text = "文字コード:" + type;
                    label5.Text = "保存する文字コード:同じ";
                    code = "1";
                    uTF8ToolStripMenuItem.ForeColor = Color.Black;
                    shiftJISToolStripMenuItem.ForeColor = Color.Black;
                    aSCIIToolStripMenuItem.ForeColor = Color.Black;
                    指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                    hozon1 = "1";
                    backfile = hozon;
                    label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";
                }
                else
                {

                    DialogResult result = MessageBox.Show("文字コードを認識できませんでした。文字化けする可能性がありますが開きますか？",
                       "警告",
                       MessageBoxButtons.YesNoCancel,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.Yes)
                    {



                        StreamReader sr = new StreamReader(file, Encoding.GetEncoding("Shift_jis"));

                        type = "utf-8";
                        string text = sr.ReadToEnd();
                        sr.Close();
                        file2 = text;

                        richTextBox1.Text = file2;
                        label3.Text = "文字コード:" + "不明";
                        label5.Text = "保存する文字コード:ANSI";
                        code = "1";
                        uTF8ToolStripMenuItem.ForeColor = Color.Black;
                        shiftJISToolStripMenuItem.ForeColor = Color.Black;
                        aSCIIToolStripMenuItem.ForeColor = Color.Black;
                        指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Blue;
                        hozon1 = "1";
                        backfile = hozon;
                        label4.Text = "ファイル名前:" + System.IO.Path.GetFileName(file); this.Text = System.IO.Path.GetFileName(file) + "-メモ帳君";

                    }
                    else if (result == DialogResult.No)
                    {
                        //「いいえ」が選択された時
                        Console.WriteLine("「いいえ」が選択されました");

                    }
                    else if (result == DialogResult.Cancel)
                    {
                        //「キャンセル」が選択された時
                        Console.WriteLine("「キャンセル」が選択されました");

                    }
                }
            }
        }

        private void 新しいファイルを生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hozon1 == "1")
            {
                this.Text = "無題-メモ帳君";
                Console.WriteLine("「はい」が選択されました");
                label4.Text = "ファイルの名前:";
                richTextBox1.Text = "";
                code = "utf-8";
                uTF8ToolStripMenuItem.ForeColor = Color.Blue;
                shiftJISToolStripMenuItem.ForeColor = Color.Black;
                aSCIIToolStripMenuItem.ForeColor = Color.Black;
                指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Black;
                label5.Text = "保存する文字コード:" + code;
                hozon = "1";
            }
            else
            {
                DialogResult result = MessageBox.Show("保存していませんが終了しますか？",
    "警告",
    MessageBoxButtons.YesNoCancel,
    MessageBoxIcon.Exclamation,
    MessageBoxDefaultButton.Button2);

                //何が選択されたか調べる
                if (result == DialogResult.Yes)
                {
                    if (backfile == "")
                    {

                    }
                    else
                    {
                        this.Text = "無題-メモ帳君";
                        //「はい」が選択された時
                        Console.WriteLine("「はい」が選択されました");
                        Console.WriteLine("「はい」が選択されました");
                        label4.Text = "ファイル名前:";
                        richTextBox1.Text = "";
                        code = "utf-8";
                        uTF8ToolStripMenuItem.ForeColor = Color.Blue;
                        shiftJISToolStripMenuItem.ForeColor = Color.Black;
                        aSCIIToolStripMenuItem.ForeColor = Color.Black;
                        指定なし前のファイルのままToolStripMenuItem.ForeColor = Color.Black;
                        label5.Text = "保存する文字コード:" + code;
                    }


                }
                else if (result == DialogResult.No)
                {
                    //「いいえ」が選択された時
                    Console.WriteLine("「いいえ」が選択されました");

                }
                else if (result == DialogResult.Cancel)
                {
                    //「キャンセル」が選択された時
                    Console.WriteLine("「キャンセル」が選択されました");

                }
            }
        }

        private void フルスクリーンToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (フルスクリーンToolStripMenuItem.Checked == System.Convert.ToBoolean("true"))
            {
                フルスクリーンToolStripMenuItem.Checked = false;

                // フォームのウィンドウのサイズを元に戻す
                this.ClientSize = prevFormSize;

                // 0. 最大化表示に戻す場合にはいったん通常表示を行う
                // （フルスクリーン表示の処理とのバランスと取るため）
                if (prevFormState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }

                // 1. フォームの境界線スタイルを元に戻す
                this.FormBorderStyle = prevFormStyle;

                // 2. フォームのウィンドウ状態を元に戻す
                this.WindowState = prevFormState;

                // ボタンの表示を変更する


                // フルスクリーン表示をOFFにする
                _bScreenMode = false;


            }
            else
            {
                フルスクリーンToolStripMenuItem.Checked = true;
                prevFormState = this.WindowState;
                // 境界線スタイルを保存する
                prevFormStyle = this.FormBorderStyle;
                prevFormSize = this.ClientSize;

                // 1. フォームの境界線スタイルを「None」にする
                this.FormBorderStyle = FormBorderStyle.None;
                // 2. フォームのウィンドウ状態を「最大化」する
                this.WindowState = FormWindowState.Maximized;
                _bScreenMode = true;

            }

        }

        private void ブラックToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ブラックToolStripMenuItem.Checked = true;
            ホワイトToolStripMenuItem.Checked = false;
            richTextBox1.BackColor = Color.FromArgb(40, 44, 52);
            richTextBox1.ForeColor = Color.FromArgb(214, 214, 214);
            this.BackColor = Color.FromArgb(21, 25, 31);
            label1.ForeColor = Color.FromArgb(216, 216, 216);
            label2.ForeColor = Color.FromArgb(216, 216, 216);
            label3.ForeColor = Color.FromArgb(216, 216, 216);
            label4.ForeColor = Color.FromArgb(216, 216, 216);
            label5.ForeColor = Color.FromArgb(216, 216, 216);
        }

        private void ホワイトToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ブラックToolStripMenuItem.Checked = false;
            ホワイトToolStripMenuItem.Checked = true;
            richTextBox1.BackColor = Color.FromArgb(240, 240, 240);
            richTextBox1.ForeColor = Color.Black;
            this.BackColor = Color.White;
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
        }

        private void バージョン確認ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ok = "0";
                var assemblyName = Assembly.GetExecutingAssembly().GetName();
                string ver = Microsoft.VisualBasic.Strings.StrConv(
        assemblyName.Version.ToString(), Microsoft.VisualBasic.VbStrConv.Narrow, 0x411);
                string ver1 = ver.Replace("?", "");
                var url = "https://pkki.github.io/-notepad-you/ver.txt";
                var baseDir = System.AppDomain.CurrentDomain.BaseDirectory;

                // WebClientでファイルを保存します。
                var client = new WebClient();
            try
            {
                client.DownloadFile(url, baseDir + "1.txt");
            }
            catch (DirectoryNotFoundException e1)
            {
                // 2. そのほかの例外が発生した場合の処理
                Console.WriteLine(e1);
            }
            catch 
            {
                // 例外が発生した場合の処理
                
                // 例外が発生した場合の処理
                DialogResult result = MessageBox.Show("エラーが発生しました、ネットに接続されていないか、\r\nインストールしている場合、管理者で実行していない可能性があります。\r\n管理者で実行しますか？\r\n管理者権限で実行したら同じ作業をしてください",
           "エラー管理者権限でやり直すか質問",
           MessageBoxButtons.YesNoCancel,
           MessageBoxIcon.Exclamation,
           MessageBoxDefaultButton.Button2);

                //何が選択されたか調べる
                if (result == DialogResult.Yes)
                {
                    //「はい」が選択された時
                    Console.WriteLine("「はい」が選択されました");
                            var proc = new System.Diagnostics.Process();

                            proc.StartInfo.FileName = Assembly.GetExecutingAssembly().Location;
                             proc.StartInfo.Verb = "RunAs";
                            proc.StartInfo.UseShellExecute = true;
                            proc.Start();
                        saiki = "2";
                        this.Close();
                        
                    

                }
                else if (result == DialogResult.No)
                {
                    //「いいえ」が選択された時
                    Console.WriteLine("「いいえ」が選択されました");
                    ok = "1";
                }
                else if (result == DialogResult.Cancel)
                {
                    //「キャンセル」が選択された時
                    Console.WriteLine("「キャンセル」が選択されました");
                    ok = "1";
                }
            }
            if (ok == "1")
            {

            }
            else
            {
                file = "1.txt";
                hozon = "1.txt";

                byte[] bytes = null;
                using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, bytes.Length);
                }
                string str = null;
                var encode = ReadJEnc.JP.GetEncoding(bytes, bytes.Length, out str);




                if (encode != null)
                {
                    string encodes = encode.ToString();
                    type = encodes;
                    if (encodes == "UTF-8N")
                    {
                        encodes = "UTF-8";
                        type = "utf-8";
                    }
                    if (encodes == "ShiftJIS")
                    {
                        encodes = "shift_jis";
                        type = "shift_jis";
                    }
                    StreamReader sr = new StreamReader(file, Encoding.GetEncoding(encodes));



                    sr.Close();
                    file2 = Microsoft.VisualBasic.Strings.StrConv(
          str.ToString(), Microsoft.VisualBasic.VbStrConv.Narrow, 0x411);
                    string file3 = file2.Replace("?", "");
                    byte[] bytefile = Encoding.GetEncoding("utf-8").GetBytes(file3);
                    byte[] bytefile1 = Encoding.GetEncoding("utf-8").GetBytes(ver1);

                    // byte → string変
                    string file4 = Encoding.GetEncoding("utf-8").GetString(bytefile);
                    if (ver1 == file4.Replace("\r", "").Replace("\n", ""))
                    {
                        MessageBox.Show("最新です",
        "バージョン確認",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information);
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("最新バージョンにしますか？((はい)を押すともう保存できません)",
           "質問",
           MessageBoxButtons.YesNoCancel,
           MessageBoxIcon.Exclamation,
           MessageBoxDefaultButton.Button2);

                        //何が選択されたか調べる
                        if (result == DialogResult.Yes)
                        {
                            //「はい」が選択された時
                            Console.WriteLine("「はい」が選択されました");
                            if (IntPtr.Size == 4)
                            {
                                Console.WriteLine("32ビットで動作しています");
                                string oldName = System.AppDomain.CurrentDomain.BaseDirectory + "メモ帳君.exe";
                                string newName = System.AppDomain.CurrentDomain.BaseDirectory + "メモ帳君old.exe";
                                System.IO.File.Move(oldName, newName);
                                var url1 = "https://pkki.github.io/-notepad-you/" + file4.Replace("\r", "").Replace("\n", "") + "/x86/メモ帳君.exe";

                                // WebClientでファイルを保存します。
                                var client1 = new WebClient();
                                client.DownloadFile(url1, baseDir + "メモ帳君.exe");
                                MessageBox.Show("再起動します",
                                "アップデート適用",
                                    MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                                saiki = "1";
                                this.Close();
                            }
                            else if (IntPtr.Size == 8)
                            {
                                Console.WriteLine("64ビットで動作しています");
                                Console.WriteLine("32ビットで動作しています");
                                string oldName = System.AppDomain.CurrentDomain.BaseDirectory + "メモ帳君.exe";
                                string newName = System.AppDomain.CurrentDomain.BaseDirectory + "メモ帳君old.exe";
                                System.IO.File.Move(oldName, newName);
                                var url1 = "https://pkki.github.io/-notepad-you/" + file4.Replace("\r", "").Replace("\n", "") + "/x64/メモ帳君.exe";

                                // WebClientでファイルを保存します。
                                var client1 = new WebClient();
                                client.DownloadFile(url1, baseDir + "メモ帳君.exe");
                                saiki = "1";
                                MessageBox.Show("再起動します",
                                "アップデート適用",
                                    MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                                this.Close();
                            }

                        }
                        else if (result == DialogResult.No)
                        {
                            //「いいえ」が選択された時
                            Console.WriteLine("「いいえ」が選択されました");
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            //「キャンセル」が選択された時
                            Console.WriteLine("「キャンセル」が選択されました");

                        }
                    }

                }
            }
               
            
        }

        private void 右端で折り返すToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (右端で折り返すToolStripMenuItem.Checked == System.Convert.ToBoolean("true"))
            {
                右端で折り返すToolStripMenuItem.Checked = false;
                richTextBox1.WordWrap = false;



            }
            else
            {
                右端で折り返すToolStripMenuItem.Checked = true;
                richTextBox1.WordWrap = true;
            }
        }

        private void ダウンロードサイトToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://pkki.online/M/メモ帳/");
        }

        private void githubページToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/pkki/-notepad-you");
        }

        private void 表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }

}
