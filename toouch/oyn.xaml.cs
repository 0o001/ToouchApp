using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Xna.Framework.GamerServices;
using System.IO.IsolatedStorage;
using System.Windows.Threading;
using System.Windows.Media;

namespace toouch
{
    public partial class oyn : PhoneApplicationPage
    {
        DispatcherTimer zmn = new DispatcherTimer();
        public static int skor = 0;
        public oyn()
        {
            InitializeComponent();
            LayoutRoot.Background = GetColorFromHexa(Renk());       
            zmn.Interval = TimeSpan.FromSeconds(1);
            zmn.Tick += zmn_Tick;
            zmn.Start();
            if (IsolatedStorageSettings.ApplicationSettings.Contains("anahtar"))
            {
                 skor = (int)IsolatedStorageSettings.ApplicationSettings["anahtar"];
                tb_skor.Text = "Score: " + skor.ToString();
            }  
          
        }
        void arttir(int sayi)
        {
            sayi += 1;
            txt_sayi.Text = sayi.ToString();
        }
        int zaman = 9;

        void zmn_Tick(object sender, EventArgs e)
        {
            if (zaman == 0)
            {
                tb_arka.Tap -= tb_arka_Tap;
                txt_sayi.Tap -= tb_arka_Tap;
                zmn.Stop();
            }
            tb_zaman.Text = zaman--.ToString();           
        }

        void txt_sayi_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
        }
        private void tb_arka_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            arttir(int.Parse(txt_sayi.Text));
            LayoutRoot.Background = GetColorFromHexa(Renk());
            if (int.Parse(txt_sayi.Text) > skor)
            {
                tb_skor.Text = "Score: " + txt_sayi.Text;
                IsolatedStorageSettings.ApplicationSettings["anahtar"] = int.Parse(txt_sayi.Text);
                IsolatedStorageSettings.ApplicationSettings.Save();
            }
        }
        public SolidColorBrush GetColorFromHexa(string hex)
        {
            return new SolidColorBrush(Color.FromArgb(
                Convert.ToByte(hex.Substring(1, 2), 16),
                Convert.ToByte(hex.Substring(3, 2), 16),
                Convert.ToByte(hex.Substring(5, 2), 16),
                Convert.ToByte(hex.Substring(7, 2), 16)));
        }
        string Renk()
        {
            string[] renkler = { "#FFFFBABA", "#FFDA3737", "#FFBFB826", "#FFFFF534", "#FF5DFF00", "#FF9DEC70", "#FF69FFD6", "#FF0BCAE8", "#FF0B7AE8", "#FF060087", "#FF69139B", "#FF9B137C", "#FF461821", "#FF462718", "#FFFF661E", "#FFD3D3D3" };
            Random r = new Random();
            int sayi = r.Next(renkler.Length);
            return renkler[sayi];
        }

    }
}