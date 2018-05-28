﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WnodowsFormByVishal1
{
    public partial class Form1 : Form
    {
        public MySqlConnection conn = new MySqlConnection(@"server=127.0.0.1;port=3306;database=vishal;userid=root;password=D2z1D04**;");
        //MySqlConnection conn1;
        //string cs = @"server=127.0.0.1;port=3306;database=vishal;user id=root;password=D2z1D04**;";

        MySqlCommand cmd;
        MySqlDataAdapter adapt;
        public string gen1 = "";
        

        //id variable for using updating and deletion record
        public int ID = 0;
        public Form1()
        {
            InitializeComponent();
            DisplayData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID != 0)
                {
                    cmd = new MySqlCommand("delete from person where ID=@id", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record Deleted SuccessFully");
                    DisplayData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("You can only deleted record by decending id order formate");
                }

            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            { 
                gen1 = radioButton1.Text;
            }
            else
            {
                gen1 = radioButton2.Text;
            }
            try
            {

                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" /*&& (radioButton1.Checked == true || radioButton2.Checked == ture)&& (radioButton1.Checked= true || radioButton2.Checked=true)*/)
                {
                    cmd = new MySqlCommand("insert into person(firstname,middlename,lastname,gender) values (@firstname,@middlename,@lastname,@gender)",conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
                    cmd.Parameters.AddWithValue("@middlename", textBox2.Text);
                    cmd.Parameters.AddWithValue("@lastname", textBox3.Text);
                    cmd.Parameters.AddWithValue("@gender", gen1);
                    // conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Record Inserted Successfully");

                    // gen1 = "";
                    DisplayData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Provide Data SuccessFully");
                }

            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            ID = 0;
            
        }
        private void DisplayData()
        {
            conn.Open();
            DataTable dt = new DataTable();
            adapt = new MySqlDataAdapter("select * from person", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string gen4 = "";
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            gen4 = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (gen4 == "Male" || gen4 == "male")
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
           // radioButton1.Checked = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString("Male");
            //radioButton2.Checked = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString("Female");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string gen2 = "";
            if (radioButton1.Checked == true)
            {
                 gen2 = radioButton1.Text;
                
            }
            else
            {
                 gen2 = radioButton2.Text;
            }
            try
            {

                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && gen2 != "")
                {
                    cmd = new MySqlCommand("update person set firstname=@firstname,middlename=@middlename,lastname=@lastname,gender=@gender where ID=@id", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
                    cmd.Parameters.AddWithValue("@middlename", textBox2.Text);
                    cmd.Parameters.AddWithValue("@lastname", textBox3.Text);
                    cmd.Parameters.AddWithValue("@gender", gen2);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Update Successfully");
                    conn.Close();
                    DisplayData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("PRovide Data");
                }
            }
            catch(MySqlException e1)
            {
                MessageBox.Show(e1.Message);
            }
            
            
               
            
        }
    }
}
