using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DipKuznecov
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Крестик закрытие
            Application.Exit();
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            //Цвет при наведении на крестик
            label2.ForeColor = Color.Gray;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            //Цвет при наведении на крестик
            label2.ForeColor = Color.White;
        }
        //Перемещение панели--------------------------------------------
        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        //Перемещение панели-------------------------------------------------


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //Ввод данных для авторизации и проверка существующего пользователя======
            String loginUser = login_field.Text;
            String passUser = pass_field.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            //MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `pass` = @uP", db.GetConnection());
            //command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            //command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

            //adapter.SelectCommand = command;
            //adapter.Fill(table);

            //if (table.Rows.Count > 0)
            //{

                //проверка выбранной роли(Админ или менеджер)
                if (role_pick.SelectedIndex > -1)
                {

                    if (role_pick.SelectedItem.ToString() == "Админ")
                    {
                        MySqlCommand command_admin_role_find = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `pass` = @uP AND `role`= 'Admin'", db.GetConnection());
                        command_admin_role_find.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                        command_admin_role_find.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;
                    adapter.SelectCommand = command_admin_role_find;
                    adapter.Fill(table);


                    if (table.Rows.Count > 0)
                        {
                            //если найдена запись в таблице с таким логином и паролем + полем админ
                            this.Hide();
                            AdminPanel adm_pan = new AdminPanel();
                            adm_pan.Show();
                        }else
                    MessageBox.Show("Данный пользователь не является администратором");

                }
                    if (role_pick.SelectedItem.ToString() == "Менеджер")
                    {

                        MySqlCommand command_user_role_find = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `pass` = @uP AND `role`= 'User'", db.GetConnection());
                        command_user_role_find.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                        command_user_role_find.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;
                    adapter.SelectCommand = command_user_role_find;
                    adapter.Fill(table);


                    if (table.Rows.Count > 0)
                        {
                            //если найдена запись в таблице с таким логином и паролем + полем юзер
                            this.Hide();
                            MainForm mf = new MainForm();
                            mf.Show();
                        }
                    else
                        MessageBox.Show("Данный пользователь не является менеджером");
                }













                }
            //}
            else
                MessageBox.Show("Данные некорректны или пользователь не найден");
            //Ввод данных для авторизации и проверка существующего пользователя=====
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //очистить поля логи и пароль
            login_field.Text = "";
            pass_field.Text = "";
        }
    }
}
