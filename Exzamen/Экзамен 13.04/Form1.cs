﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Экзамен_13._04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con;

        private void button1_Click(object sender, EventArgs e)
        {

                con = new SqlConnection(@"Data source = DESKTOP-RHPNAVO\SQLEXPRESS01; initial catalog = SalonKrasoti; integrated security = SSPI");
                con.Open();
                SqlCommand com = new SqlCommand("Select * from [Employee] Where Login = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", con);
                DataTable table = new DataTable();
                SqlDataReader r = com.ExecuteReader();
                table.Load(r);
                dataGridView1.DataSource = table;
                con.Close();
                if (dataGridView1.Rows[0].Cells[2].Value != null)
                {
                    Заказы заказы = new Заказы();
                    заказы.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }

        }
    }
