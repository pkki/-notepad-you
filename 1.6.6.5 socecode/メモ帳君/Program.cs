using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace メモ帳君
{
    static class Program
    {
        static string file110;
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            if (args.Length == 0)
            {
                Console.WriteLine(".txt");
            }
            else
            {
                for (int i = 0; i < args.Length; i++)
                    file110 = (args[i]);


            }
            Console.ReadLine();

        }


    }
}
