using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaPlay
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 過濾條件設定為WAV檔案
            ofdWAVFile.Filter = "WAV Files(*.wav)|*.wav";
            // 打開檔案對話方塊
            if (ofdWAVFile.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofdWAVFile.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer player1 = new SoundPlayer();  // 建立播放器物件
            player1.SoundLocation = txtPath.Text;// 指定音效所在路徑檔名
            player1.Load();// 載入音效檔資料
            player1.Play();// 播放音效
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SoundPlayer player2 = new SoundPlayer(txtPath.Text);
            player2.PlayLooping();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fsWAV = new FileStream(txtPath.Text, FileMode.Open);
            // 使用檔案串流建立物件
            SoundPlayer player3 = new SoundPlayer(fsWAV);
            player3.Stop();
            fsWAV.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("確定要關閉應用程式嗎？", "關閉確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // 取消關閉
            }
        }
    }
}

