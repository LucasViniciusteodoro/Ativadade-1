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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int Id { get; set; }
        public string nome { get; set; }
        public string cidade { get; set; }
        public string endereco { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string data { get; set; }


        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aluno\source\repos\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True");

        private List<Form1> btnListar_Click(object sender, EventArgs e)
        {
            List<Form1> li = new List<Form1>();
            string sql = "SELECT * FROM Form1";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Form1 p = new Form1();
                p.Id = (int)dr["Id"];
                p.nome = dr["nome"].ToString();
                p.cidade = dr["cidade"].ToString();
                p.endereco = dr["endereco"].ToString();
                p.celular = dr["celular"].ToString();
                p.email = dr["email"].ToString();
                p.data = dr["data"].ToString();
                li.Add(p);

            }
            dr.Close();
            con.Close();
            return li;
        }
        private void btnInserir_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO Pessoa(nome,cidade,endereco,celular,email,data) VALUES ('" + nome + "','" + cidade + "','" + endereco + "','" + celular + "','" + email + "','" + data + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE Pessoa SET nome='" + nome + "',cidade='" + cidade + "', endereco='"+endereco+"',celular='"+celular+"',email='"+email+"',data='"+data+"', WHERE Id='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Pessoa WHERE Id='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void btnLocalizar_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Pessoa WHERE Id='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                cidade = dr["cidade"].ToString();
                endereco = dr["cidade"].ToString();
                celular = dr["celular"].ToString();
                email = dr["email"].ToString();
                data = dr["data"].ToString();
            }
            dr.Close();
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    

