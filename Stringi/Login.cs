using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Stringi
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        string[] loginy = {
            "Login1",
            "Login2",
            "Janusze"
        };
        string[] hasla = {
            "Haslohaslo",
            "123",
            "3d"
        };




        private static void PrintColumns(DataTableReader reader)
        {
            // Loop through all the rows in the DataTableReader
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + " ");
                }
                Console.WriteLine();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string connString =
    "Provider=Microsoft.JET.OLEDB.4.0;data source=\"C:\\Users\\kurs\\Documents\\Visual Studio 2015\\Projects\\Stringi_22.11.2016\\C-Sharp-AMT-2016\\BDLoginy.mdb\"";

            DataTable results = new DataTable();

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Logowanie", conn);

                conn.Open();

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            }
            
            string strCmdText = "/C java -Xms512m -Xmx1g -Djava.library.path=natives/ -cp \"minecraft.jar; lwjgl.jar; lwjgl_util.jar\" net.minecraft.client.Minecraft Chomiciak grjjgwjgewpjpj";
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);


            if (txtLogin.Text.Length == 0)
            {
                MessageBox.Show("Wypełnij Login!");
                return;
            }

            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Wypełnij Hasło!");
                return;
            }

            for(int i = 0; i < loginy.Length; i++)
            {
                if(loginy[i] == txtLogin.Text 
                    && hasla[i] == txtPassword.Text)
                {
                    new Form1().Show();
                    this.Hide();
                    return;
                }
            }
            MessageBox.Show("Niepoprawne dane logowania!");
        }
    }
}
