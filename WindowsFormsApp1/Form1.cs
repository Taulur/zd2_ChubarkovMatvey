using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {

        PhoneBook phoneBook = new PhoneBook();
        string filepath = @"D:\Projects\zd2_ChubarkovMatvey-main\WindowsFormsApp1\bin\Debug\contacts.csv";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact(textBox1.Text, textBox2.Text);

            int index = dataGridView1.CurrentCell.RowIndex;

            phoneBook.GetList()[index] = contact;

            PhoneBookLoader.Save(phoneBook, filepath);
            PhoneBookLoader.Load(phoneBook, filepath, dataGridView1);

            panel1.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PhoneBookLoader.Load(phoneBook, filepath, dataGridView1);
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string phone = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                panel1.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Length > 0 && textBox3.Text.Length > 0)
            {
              
                    phoneBook.AddContact(new Contact(textBox4.Text, textBox3.Text));

                    PhoneBookLoader.Save(phoneBook, filepath);
                    PhoneBookLoader.Load(phoneBook, filepath, dataGridView1);

                   
              

                panel2.Visible = false;


            }

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                phoneBook.GetList().RemoveAt(index);

                PhoneBookLoader.Save(phoneBook, filepath);
                PhoneBookLoader.Load(phoneBook, filepath, dataGridView1);
            }
        }

        private void dataGridView2_MouseLeave(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            foreach (Contact contact in phoneBook.GetList())
            {
                if (contact.Name.Contains(textBox6.Text))
                {
                    dataGridView2.Rows.Add(contact.Name, contact.Phone);
                }
            }

            dataGridView2.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
