using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradingSystem
{
    public partial class GradingSystem : Form
    {
        DataTable table = new DataTable("table");//32
        int index;
        public GradingSystem()
        {
            InitializeComponent();
        }

        private void GradingSystem_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Student Name", Type.GetType("System.String"));
            table.Columns.Add("Student Id", Type.GetType("System.Int32"));
            table.Columns.Add("Attendence", Type.GetType("System.Double"));
            table.Columns.Add("Quiz", Type.GetType("System.Double"));//32
            table.Columns.Add("Assignment", Type.GetType("System.Double"));
            table.Columns.Add("Viva", Type.GetType("System.Double"));//32
            table.Columns.Add("Assesment", Type.GetType("System.Double"));
            table.Columns.Add("Project", Type.GetType("System.Double"));
            table.Columns.Add("Presentation", Type.GetType("System.Double"));
            dataGridView1.DataSource = table;
        }
        SqlConnection sq = new SqlConnection("Data Source = DESKTOP-GK07BPP; Initial Catalog = GradingSystem; User ID = sa; Password=root");
        

        void showMe() 
        {
            SqlCommand sC = new SqlCommand("select * from Table_1", sq);
            SqlDataAdapter sA = new SqlDataAdapter(sC);
            DataTable dT = new DataTable();
            sA.Fill(dT);
            dataGridView1.DataSource = dT;
        }
        private void button1_Click(object sender, EventArgs e)//compute button
        {


            double ATTENDENCE, QUIZ, ASSIGNMENT, VIVA, ASSESMENT, PROJECT, PRESENTATION, TOTAL;



            ATTENDENCE = double.Parse(textBox3.Text);
            QUIZ = double.Parse(textBox4.Text);
            ASSIGNMENT = double.Parse(textBox5.Text);
            VIVA = double.Parse(textBox6.Text);
            ASSESMENT = double.Parse(textBox7.Text);
            PROJECT = double.Parse(textBox8.Text);
            PRESENTATION = double.Parse(textBox9.Text);



            TOTAL = ATTENDENCE + QUIZ + ASSIGNMENT + VIVA + ASSESMENT + PROJECT + PRESENTATION;
            label15.Text = TOTAL.ToString();
            label15.Visible = true;
            if (TOTAL >= 90)
            {
                label16.Text = "A+";
                label13.Text = "PASSED";
            }
            else if (TOTAL >= 85)
            {
                label16.Text = "A";
                label13.Text = "PASSED";
            }
            else if (TOTAL >= 80)
            {
                label16.Text = "B+";
                label13.Text = "PASSED";
            }
            else if (TOTAL >= 75)
            {
                label16.Text = "B";
                label13.Text = "PASSED";
            }
            else if (TOTAL >= 70)
            {
                label16.Text = "C+";
                label13.Text = "PASSED";
            }
            else if (TOTAL >= 65)
            {
                label16.Text = "C";
                label13.Text = "PASSED";
            }
            else if (TOTAL >= 60)
            {
                label16.Text = "D+";
                label13.Text = "PASSED";
            }
            else if (TOTAL >= 50)
            {
                label16.Text = "D";
                label13.Text = "PASSED";
            }
            else if (TOTAL < 50)
            {
                label16.Text = "F";
                label13.Text = "FAILED";
            }
            label16.Visible = true;
            label13.Visible = true;





        }

        private void button5_Click(object sender, EventArgs e)//delete button
        {
            index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(index);
        }

        private void button2_Click(object sender, EventArgs e)//insert button
        {
            table.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text);
        }

        private void button3_Click(object sender, EventArgs e)//new button
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;
            textBox9.Text = String.Empty;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            textBox6.Text = row.Cells[5].Value.ToString();
            textBox7.Text = row.Cells[6].Value.ToString();
            textBox8.Text = row.Cells[7].Value.ToString();
            textBox9.Text = row.Cells[8].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)//update button
        {
            DataGridViewRow newdata = dataGridView1.Rows[index];
            newdata.Cells[0].Value = textBox1.Text;
            newdata.Cells[1].Value = textBox2.Text;
            newdata.Cells[2].Value = textBox3.Text;
            newdata.Cells[3].Value = textBox4.Text;
            newdata.Cells[4].Value = textBox5.Text;
            newdata.Cells[5].Value = textBox6.Text;
            newdata.Cells[6].Value = textBox7.Text;
            newdata.Cells[7].Value = textBox8.Text;
            newdata.Cells[8].Value = textBox9.Text;
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
