using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ticket1
{
    public partial class chairs : Form
    {
        public chairs()
        {
            InitializeComponent();
        }
        public String filmname;
        sqlbaglanti baglan = new sqlbaglanti();
        private void chairs_Load(object sender, EventArgs e)
        {
            label1.Text = filmname;
            int baslaX = 1;
            int baslaY = 60;
            int butonsayisi = 20;
            int boyutsquare = Convert.ToInt32(Math.Ceiling(Math.Sqrt(butonsayisi)));//buton sayısına göre ekrana panele sığdırıyor
            ArrayList chairs = new ArrayList();
            SqlCommand komut2 = new SqlCommand("select chair_name from tickets where ticket_film_name=@f1", baglan.baglanti());
            komut2.Parameters.AddWithValue("@f1", label1.Text);
            SqlDataReader dread = komut2.ExecuteReader();
            while (dread.Read())
            {
                chairs.Add(dread["chair_name"]).ToString();
            }

            for(int i = 1; i <= butonsayisi; i++)
            {
                Button btn=new Button();
                btn.Name = "buton" + i.ToString();
                btn.Text = "Koltuk" + i.ToString();
                btn.Size = new Size(panel1.Width / boyutsquare, panel1.Height / (boyutsquare * 2));
                btn.Location = new Point(baslaX, baslaY);
                panel1.Controls.Add(btn);
                baslaX += btn.Width + 10;
                if (baslaX + panel1.Width / boyutsquare > panel1.Width)
                {
                    baslaX = 1;
                    baslaY = panel1.Height / (boyutsquare * 2) + 5;
                }
                btn.Click += Btn_Click;//tıklayınca ticketinformation formuna gidecek
                if (chairs.Contains(btn.Text))//contains şartımızın arraylistteolup olmadığını sorgulayacak varsa yeşil yoksa kırmızı
                {
                    btn.BackColor = Color.Green;
                }
                else
                {
                    btn.BackColor = Color.Red;
                }


            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button dinamicbut = (sender as Button);//tıklanan buton
            ticketinformation ticketdetay = new ticketinformation();
            ticketdetay.filmname = label1.Text;
            ticketdetay.chairno = dinamicbut.Text;//tıkladığımız o an tıklanan butondaki text gidecek
            ticketdetay.Show();
            
        }
    }
}
