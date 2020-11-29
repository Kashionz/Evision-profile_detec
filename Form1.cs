using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Euresys.Open_eVision_2_12;

namespace Evision_profile_detec
{
    public partial class Form1 : Form
    {
        EImageC24 EC24Image1 = new EImageC24(); //eVision的彩色圖像物件
        EImageBW8 EBW8Image1 = new EImageBW8(); //eVision的灰階圖像物件

        EBW8Vector In = new EBW8Vector(); // EBW8Vector instance
        EBW8Vector Out = new EBW8Vector(); // EBW8Vector instance
        EColorLookup EColorLookup1 = new EColorLookup();

        string[] files;
        float ScalingRatio = 0; //Picturebox與原始影像大小的縮放比例

        double last_In = 0, last_Out = 0;
        double valuein = 7.8;
        double valueout = 7.8;
        int previous = 0, current = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void openFile_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Application.StartupPath;
            listBox1.Items.Clear();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                files = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.jpg").OrderBy(x => x.Length).ThenBy(x => x).ToArray();
                foreach (string f in files)
                {
                    listBox1.Items.Add(f);
                }
            }
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            double t1 = 0, t2 = 0, timeDiff = 0, fov = 5.0, speed = 0;
            bool hascar = false;
            valuein = double.Parse(Value_In.Text);
            valueout = double.Parse(Value_Out.Text);
            last_In = 0;
            last_Out = 0;

            EC24Image1.Load(files[0]);

            /*============================計算scaling ratio============================*/
            float PictureBoxSizeRatio = (float)pbimg.Width / pbimg.Height;
            float ImageSizeRatio = (float)EC24Image1.Width / EC24Image1.Height;
            if (ImageSizeRatio > PictureBoxSizeRatio)
                ScalingRatio = (float)pbimg.Width / EC24Image1.Width;
            else
                ScalingRatio = (float)pbimg.Height / EC24Image1.Height;
            /*=========================================================================*/

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox1.SelectedIndex = i;
                listBox1.Refresh();
                EC24Image1.Load(files[i]);
                EC24Image1.Draw(pbimg.CreateGraphics(),ScalingRatio);

                EBW8Image1.SetSize(EC24Image1);
                EasyImage.Oper(EArithmeticLogicOperation.Copy, new EBW8(0), EBW8Image1);
                EasyImage.Convert(EC24Image1, EBW8Image1); //轉灰階

                EasyImage.ImageToLineSegment(EBW8Image1, In, 1000, 1079, 1750, 1079); //設定偵測線在最底部，判斷車子是否準備進來
                EasyImage.ImageToLineSegment(EBW8Image1, Out, 1000, 0, 1750, 0); //設定偵測線在最頂部，判斷車子是否準備出去

                if (CarIn(In) && !hascar) //假如沒有車子，且CarIn有偵測到車子情況下，視同進入
                {
                    previous = i; //記錄車子進來的圖片張數
                    //t1 = DateTime.Now.TimeOfDay.Seconds + DateTime.Now.TimeOfDay.Milliseconds / 1000.0; //記錄進來的時間
                    speed = 0;
                    hascar = true;
                }
                else if (CarOut(Out) && hascar && speed == 0) //假如有車子，且CarOut有偵測到車子並尚未計算速度的情況下，視同出去
                {
                    current = i; //記錄車子出去的圖片張數
                    if (current - previous <= 10 || current - previous >= 100) //防呆機制，假如10張內或超過100張視同有問題
                    {
                        //last_Out = 0;
                        hascar = false;
                    }
                    else
                    {
                        Console.WriteLine("車子進來的第一張圖片:" + files[previous]);
                        Console.WriteLine("車子出去的最後一張圖片:" + files[current]);
                        t1 = Double.Parse(Path.GetFileNameWithoutExtension(files[previous])); //擷取進來的圖檔名當作進來的時間
                        t2 = Double.Parse(Path.GetFileNameWithoutExtension(files[current])); //擷取出去的圖檔名當作出去的時間
                        //t2 = DateTime.Now.TimeOfDay.Seconds + DateTime.Now.TimeOfDay.Milliseconds / 1000.0; //記錄出去的時間
                        Console.WriteLine("T1=" + t1.ToString());
                        Console.WriteLine("T2=" + t2.ToString());
                        //秒數做溢位處理
                        /*
                        if (t1 > t2)
                            timeDiff = (t2 + 60) - t1;
                        else
                        */
                        timeDiff = t2 - t1; //出去的時間減去進來的時間
                        Console.WriteLine("timeDiff = " + timeDiff);
                        speed = fov / (timeDiff / 4) * 3.6; //計算車子的速度，因為採用4倍慢速錄影所以時間要除以4，速度單位為km/hr
                        speed = Math.Round(speed, 2, MidpointRounding.AwayFromZero); //將速度四捨五入
                        labelSpeed.Text = "Speed: " + speed.ToString();
                        Console.WriteLine("Speed: " + speed);
                        labelSpeed.Update();
                        last_In = 0;
                        hascar = false;
                    }
                }
            }
        }

        private bool CarIn(EBW8Vector State)
        {
            double sum = 0, max, min;
            for (int i = 0; i < State.NumElements; i++)
            {
                sum += Math.Pow(State.GetElement(i).Value, 2);
            }
            if (last_In == 0)
            {
                last_In = sum;
                return false;
            }

            max = last_In + valuein;
            min = last_In - valuein;

            if (min < sum && sum < max)
            {
                last_In = sum;
                return false;
            }
            else
            {
                last_In = sum;
                return true;
            }
        }

        private bool CarOut(EBW8Vector State)
        {
            double sum = 0, max, min;
            for (int i = 0; i < State.NumElements; i++)
            {
                sum += Math.Pow(State.GetElement(i).Value, 2);
            }
            if (last_Out == 0)
            {
                last_Out = sum;
                return false;
            }

            max = last_Out + valueout;
            min = last_Out - valueout;

            if (min < sum && sum < max)
            {
                last_Out = sum;
                return false;
            }
            else
            {
                last_Out = sum;
                return true;
            }
        }
    }
}
