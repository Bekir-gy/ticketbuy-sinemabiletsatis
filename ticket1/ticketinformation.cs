using System;
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
    public partial class ticketinformation : Form
    {
        public ticketinformation()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public string chairno;
        public string filmname;
        sqlbaglanti baglan = new sqlbaglanti();
        private void ticketinformation_Load(object sender, EventArgs e)
        {
            film.Text = filmname;
            koltuk.Text = chairno;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komutbilet = new SqlCommand("insert into tickets(ticket_name,chair_name,ticket_film_name) values(@b1,@b2,@b3)", baglan.baglanti());
            komutbilet.Parameters.AddWithValue("@b1", textBox1.Text);
            komutbilet.Parameters.AddWithValue("@b2", koltuk.Text);
            komutbilet.Parameters.AddWithValue("@b3", film.Text);
            komutbilet.ExecuteNonQuery();//komutu çalıştırır bu komut
            baglan.baglanti().Close();
            MessageBox.Show("Bilet Belirtilen Kişiye Satıldı", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
