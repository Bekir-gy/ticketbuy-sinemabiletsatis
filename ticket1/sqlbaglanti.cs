using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace ticket1
{
    class sqlbaglanti
    {
        public SqlConnection baglanti ()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-3TQ9JMS;Initial Catalog=ticket;Integrated Security=True");
            baglan.Open();
            return baglan;

        }
    }
}
