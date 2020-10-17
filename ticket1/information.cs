using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ticket1
{
    public partial class cinema : Form
    {
        public cinema()
        {
            InitializeComponent();
        }

        sqlbaglanti baglan = new sqlbaglanti();
        

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void cinema_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'ticketDataSet.film' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.filmTableAdapter.Fill(this.ticketDataSet.film);

        }

        private void ekle1_Click(object sender, EventArgs e)
        {
            SqlCommand islem1 = new SqlCommand("insert into film(film_name) values(@p1)", baglan.baglanti());
            islem1.Parameters.AddWithValue("@p1", textfilm.Text);
            islem1.ExecuteNonQuery();
            baglan.baglanti().Close();
            MessageBox.Show("Film Kaydı Başarılı Sonuçlandı");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                chairs frmchairs = new chairs();
                frmchairs.filmname = dataGridView1.Rows[secilen].Cells[1].Value.ToString();//secilen satırdaki 1.sütundaki veriyi film adına atıp oradanda kullanacağımız form ile türettiğimiz nesne aracılığı ile chairs sayfasındaki labela atıyoruz. datagridview deki seçilen satır için bu açıklama
                frmchairs.Show();
            }
        }

        private void ekle2_Click(object sender, EventArgs e)
        {
            comboliste frmcombo = new comboliste();//bu formdan bir nesne türettim bu nesne ile o forma gidiyoruz
            frmcombo.Show();
        }

       
    }
}
