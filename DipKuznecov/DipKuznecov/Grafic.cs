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
using LiveCharts;
using LiveCharts.Wpf;
using MySql.Data.MySqlClient;

namespace DipKuznecov
{
    public partial class Grafic : Form
    {
        public Grafic()
        {
            InitializeComponent();
            LoadDataToTable();
        }
        


        public void LoadDataToTable()
        { //показ таблицы
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            db.openConnection();
            //выбор всех данных таблицы пользователи
            string query = "SELECT id_z, name, cash FROM zayavki ORDER BY id_z";
            MySqlCommand command = new MySqlCommand(query, db.GetConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[3]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();

            }
            reader.Close();


            db.closeConnection();


            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);



        }

        private void Grafic_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {//отрисовка графика
            DB db = new DB();
            MySqlCommand cmdDataBase = new MySqlCommand(" SELECT name, cash FROM zayavki ORDER BY id_z ;", db.GetConnection());
            MySqlDataReader myReader;
            try
            {
                db.openConnection();
                myReader = cmdDataBase.ExecuteReader();

                while (myReader.Read())
                {
                    chart1.Series["Название"].Points.AddXY(myReader.GetString("name"), myReader.GetInt32("cash"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            db.closeConnection();



        }




    } }

