using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
	public partial class Form1 : Form
	{

		Boolean wideFrag = false;
		Boolean verchFrag = false;


		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult dr = folderBrowserDialog1.ShowDialog();
			if (dr == DialogResult.OK)
			{
				//textにパス代入
				string wide_path = folderBrowserDialog1.SelectedPath;
				textBox1.Text = wide_path;


				//filesにフォルダ内のファイル名(パス)をすべて読み込み
				string[] wide_files = System.IO.Directory.GetFiles(wide_path, "*", System.IO.SearchOption.AllDirectories);
				Array.Sort(wide_files);
				for (int i = 0; i < wide_files.Length; i++)
					Console.WriteLine("{0}:{1}", i, wide_files[i]);

				//filesからファイル名だけを抽出してfile_namesに読み込み
				string[] wide_filenames = new string[wide_files.Length];
				for (int i = 0; i < wide_filenames.Length; i++)
					wide_filenames[i] = Path.GetFileName(wide_files[i]);
				for (int i = 0; i < wide_filenames.Length; i++)
					Console.WriteLine("{0}:{1}", i, wide_filenames[i]);

				//一度copyフォルダを作りバックアップ
				Directory.CreateDirectory(wide_path + "/../wide_copy");

				for (int i = 0; i < wide_files.Length; i++)
					File.Copy(wide_files[i], wide_path + "/../wide_copy/" + wide_filenames[i]);

				wideFrag = true;

			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult dr = folderBrowserDialog2.ShowDialog();
			if (dr == DialogResult.OK)
			{
				//textにパス代入
				string verch_path = folderBrowserDialog1.SelectedPath;
				textBox2.Text = verch_path;


				//filesにフォルダ内のファイル名(パス)をすべて読み込み
				string[] verch_files = System.IO.Directory.GetFiles(verch_path, "*", System.IO.SearchOption.AllDirectories);
				Array.Sort(verch_files);
				for (int i = 0; i < verch_files.Length; i++)
					Console.WriteLine("{0}:{1}", i, verch_files[i]);

				//filesからファイル名だけを抽出してfile_namesに読み込み
				string[] verch_filenames = new string[verch_files.Length];
				for (int i = 0; i < verch_filenames.Length; i++)
					verch_filenames[i] = Path.GetFileName(verch_files[i]);
				for (int i = 0; i < verch_filenames.Length; i++)
					Console.WriteLine("{0}:{1}", i, verch_filenames[i]);

				//一度copyフォルダを作りバックアップ
				Directory.CreateDirectory(verch_path + "/../verch_copy");

				for (int i = 0; i < verch_files.Length; i++)
					File.Copy(verch_files[i], verch_path + "/../verch_copy/" + verch_filenames[i]);

				verchFrag = true;
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			init();

			//if(wideFrag && verchFrag)
			//	button3.Visible = true;
		}

		private void init()
		{
			//filesの初期化はどうする？
			//button3.Visible = false;
			textBox1.Text = "";
			textBox2.Text = "";
		}

		private void button3_Click(object sender, EventArgs e)
		{
			wideFrag = false;
			verchFrag = false;
			init();
		}
		
	}
}
