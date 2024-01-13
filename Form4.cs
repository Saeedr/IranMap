using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace IranMap
{
    public partial class Form4 : Form
    {
        private MapInfo mapInfo;
        private int CurrentIndex = -1;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            mapInfo = new MapInfo(Application.StartupPath + "\\IranMap.set");

            pibIran.Image = mapInfo.Main;
            pibIran.Size = mapInfo.Main.Size;
            this.Size = new Size(pibIran.Size.Width + 40, pibIran.Size.Height + 70 + lblInfo.Size.Height);
        }

        private void pibIran_MouseMove(object sender, MouseEventArgs e)
        {
            int Cur = mapInfo.InArea(e.X,e.Y);
            if (Cur != CurrentIndex)
            {
                CurrentIndex = Cur;
                if (CurrentIndex != -1)
                {
                    pibIran.Image = mapInfo.Hit(CurrentIndex);
                    lblInfo.Text = mapInfo.GetDescription(CurrentIndex);
                }
                else
                {
                    pibIran.Image = mapInfo.Main;
                    lblInfo.Text = "Iran Map";
                }
            }
        }

        private void pibIran_MouseLeave(object sender, EventArgs e)
        {
            pibIran.Image = mapInfo.Main;
            CurrentIndex = -1;
            lblInfo.Text = "";
        }
    }

    internal class MapInfo
    {
        private Bitmap bmpMain = null;
        private Bitmap bmpSecond = null;
        private ItemMapInfo[] item;
        private Color ColorMain;

        public Bitmap Main { get{return bmpMain;}}
        public Color Color { get { return ColorMain; } }

        public MapInfo(string fileName)
        {
            string s;
            int count,i;

            using (TextReader file = new StreamReader(fileName))
            {
                s = file.ReadLine();
                string[] ss = s.Split(new char[] { '\"' });
                if (ss.Length < 2 && ss[0] != "MainPicture=")
                    throw new Exception(string.Format("Format of file \'{0}\' is error!", fileName));
                else
                {
                    bmpMain = new Bitmap(Image.FromFile(Path.GetDirectoryName(fileName) + "\\" + ss[1]));
                    s = file.ReadLine();
                    ss = s.Split(new char[] { '\"' });
                    if (ss.Length < 2 && ss[0] != "SecondPicture=")
                        throw new Exception(string.Format("Format of file \'{0}\' is error!", fileName));
                    else
                    {
                        bmpSecond = new Bitmap(Image.FromFile(Path.GetDirectoryName(fileName) + "\\" + ss[1]));

                        s = file.ReadLine();
                        ss = s.Split(new char[] { ' ' });
                        if (ss.Length < 4 && ss[0] != "Color=")
                            throw new Exception(string.Format("Format of file \'{0}\' is error!", fileName));
                        else
                        {
                            ColorMain = Color.FromArgb(Byte.Parse(ss[1]),Byte.Parse(ss[2]),Byte.Parse(ss[3]));
                            s = file.ReadLine();
                            ss = s.Split(new char[] { ' ' });
                            if (ss.Length < 2 && ss[0] != "Count=")
                                throw new Exception(string.Format("Format of file \'{0}\' is error!", fileName));
                            else
                            {
                                count = Int32.Parse(ss[1], System.Globalization.NumberStyles.Integer);

                                item = new ItemMapInfo[count];

                                for (i = 0; i < count; i++)
                                {
                                    s = file.ReadLine();
                                    ss = s.Split(new char[] { ' ' });
                                    if (ss.Length < 7)
                                        throw new Exception(string.Format("Format of file \'{0}\' is error!", fileName));
                                    else
                                    {
                                        item[i].DrawX = Int32.Parse(ss[0]);
                                        item[i].DrawY = Int32.Parse(ss[1]);
                                        item[i].BeginX = Int32.Parse(ss[2]);
                                        item[i].BeginY = Int32.Parse(ss[3]);
                                        item[i].Width = Int32.Parse(ss[4]);
                                        item[i].Height = Int32.Parse(ss[5]);
                                        item[i].Text = ss[6];
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public int InArea(int x, int y)
        {
            int i,j,k;
            Color c;
            k = 0;
            foreach (ItemMapInfo imi in item)
            {
                i = x - imi.DrawX;
                j = y - imi.DrawY;
                if (i >= 0 && i <= imi.Width && j >= 0 && j <= imi.Height)
                {
                    i += imi.BeginX;
                    j += imi.BeginY;
                    if (i < bmpSecond.Width && j < bmpSecond.Height)
                    {
                        c = bmpSecond.GetPixel(i, j);
                        if (c.A != 0)
                        {
                            return k;
                        }
                    }
                }
                k++;
            }
            return -1;
        }

        public Image Hit(int Index)
        {
            Bitmap bmpHelper = new Bitmap(Main);
            ItemMapInfo imi = item[Index];

            using (Graphics g = Graphics.FromImage(bmpHelper))
            {
                g.DrawImage(bmpSecond, new Rectangle(imi.DrawX, imi.DrawY, imi.Width, imi.Height),
                               imi.BeginX, imi.BeginY, imi.Width, imi.Height, GraphicsUnit.Pixel);
            }
            return bmpHelper;
        }

        internal string GetDescription(int Index)
        {
            return item[Index].Text;
        }
    }

    internal struct ItemMapInfo
    {
        public int DrawX, DrawY;
        public int Width, Height;
        public int BeginX, BeginY;
        public string Text;
    }
}
