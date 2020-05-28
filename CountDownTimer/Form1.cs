using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountDownTimer
{
    public partial class Form1 : Form
    {
        long countMin;
        int second1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblTimeNow.Text = DateTime.Now.ToLongTimeString().ToString();
            lblMinute.Text = textBox1.Text.Trim()+ " วินาที";
            lblDown.Text = textBox1.Text.Trim();
            ////Timer จะถูกกระตุ้น (Trigger) การทำงานทุกๆ 1 วินาที (1000 millisecond)
            //timer1.Interval = 1000;
            //timer1.Enabled = true;
            ////ตั้งนับถอยหลัง 1 นาที (60 x 1000 ได้หน่วยนับมิลลิวินาที)
            ////countMin = 60000;
            //countMin = Int32.Parse(textBox1.Text.Trim()) * 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimeNow.Text = DateTime.Now.ToLongTimeString().ToString();
            countMin = countMin - 1000;
            //============================ แสดงผลเวลาการนับถอยหลัง =========================
            //lblDown.Text = (Int32.Parse(lblDown.Text) - 1).ToString();
            //if (countMin == 0)
            //{
            //    lblDown.Text = "หมดเวลา/Logout Time";
            //    //ปิดการทำงานของ Timer
            //    //timer1.Enabled = false;
            //}

            if(countMin > 0)
            {
                lblDown.Text = (Int32.Parse(lblDown.Text) - 1).ToString();
            }
            else
            {
                lblDown.Text = "หมดเวลา/Logout Time";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(textBox1.Text.Trim()))
                {
                    MessageBox.Show("กรุณากำหนดจำนวน วินาที !","error");
                    return;
                }
                else
                {
                    lblMinute.Text = textBox1.Text.Trim() + " วินาที";
                    lblDown.Text = textBox1.Text.Trim();
                    countMin = Int32.Parse(textBox1.Text.Trim()) * 1000;
                    //Timer จะถูกกระตุ้น (Trigger) การทำงานทุกๆ 1 วินาที (1000 millisecond)
                    timer1.Interval = 1000;
                    timer1.Enabled = true;
                    //ตั้งนับถอยหลัง 1 นาที (60 x 1000 ได้หน่วยนับมิลลิวินาที)
                    second1 = string.IsNullOrEmpty(textBox1.Text.Trim()) ? 0 : Int32.Parse(textBox1.Text.Trim());
                    countMin = second1 * 1000;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
