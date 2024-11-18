using Microsoft.Data.SqlClient;
using System.Data;

namespace DBMS.SQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //ประเภทหน้าเชื่อมต่อ
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;

        //method สำหรับเชื่อมต่อ และปิดการเชื่อมต่อฐานข้อมูล SQL SERVER
        private void connect()
        {
            string server = @".";
            string db = "Minimart";
            string strCon = string.Format(@"Data Source={0}; Initial Catalog={1};"
                      + "Integrated Security=True;Encrypt=False", server, db);
            conn = new SqlConnection(strCon);
            conn.Open();
        }

        private void disconnect()
        {
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect();
            showData("select * from Products");
        }

        private void showData(string sql)
        {
            //string sql = "select * from Products";
            da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showData("select EmployeeID,Title+FirstName+' '+Lastname EmpName, Position from Employees");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showData("select * from Categories");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showData("select * from Products");
        }
    }
}
