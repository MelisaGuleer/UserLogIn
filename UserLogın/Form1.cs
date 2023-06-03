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

namespace UserLogın
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Kullanıcı Adı Giriniz");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Şifre Giriniz");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-HE4IG4BJ\\SQLEXPRESS;Initial Catalog=userlogin;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("select * from tbluser where Username = @Username and Password = @Password", con);
                    cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    ad.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Giriş Başarılı!");
                    }
                    else
                    {
                        MessageBox.Show("Bir kullanıcı adı ya da şifre giriniz!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("");
                }
            }
        }
    }
}
