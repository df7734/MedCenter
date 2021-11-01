using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Xsl;

namespace WinFormsMedCenter
{
    public partial class DoctorVector : Form
    {
       
           // bool changed;
            int id_cat;
            string name_cat;

            public DoctorVector()
            {
                InitializeComponent();
                dataGridView1.ForeColor = Color.Black;
                dataGridView1.DefaultCellStyle.Font = new Font("Microsoft San Serif", 8);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft San Serif", 8);

            // changed = false;
        }

           
            public DoctorVector(int cat_id, string cat_name)
            {
                InitializeComponent();
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Microsoft San Serif", 8);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft San Serif", 8);
            Text = String.Concat(Text, " ", cat_name);

                id_cat = cat_id;
                name_cat = cat_name;
                find_Doctors();
               // changed = false;
            }

        private void find_Doctors()
        {
            string findName = "%" + textBox1.Text + "%";
            if (textBox2.Text != "")
            {
                string findEdu = "%" + textBox2.Text + "%";

                dataTable1TableAdapter1.FillByNE(dsMedCenter1.DataTable1, id_cat, findName, findEdu);

            }
            else
            {
                dataTable1TableAdapter1.FillByName(dsMedCenter1.DataTable1, id_cat, findName);
            }

           

               // diR_VECTORTableAdapter1.Fill(dsMedCenter1.DIR_VECTOR);


        }

       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void DoctorVector_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            find_Doctors();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.CurrentRow.Cells["dOIDDataGridViewTextBoxColumn"].Value;



            global::System.Nullable<int> mc_count = queriesTableAdapter1.SQCountDO_IDInDM(id);

            if(mc_count==0)
            {
                dataTable1BindingSource.RemoveCurrent();
            }
            else
            {
                MessageBox.Show("Видаляти не можна! До лікаря прив'язан мед. центр", "Помилка видалення");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
      
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet(); // создаем пока что пустой кэш данных
                DataTable dt = new DataTable(); // создаем пока что пустую таблицу данных
                dt.TableName = "Doctor"; // название таблицы
                dt.Columns.Add("Name"); // название колонок               
                dt.Columns.Add("Education");
                dt.Columns.Add("Vector");
                ds.Tables.Add(dt); //в ds создается таблица, с названием и колонками, созданными выше

                foreach (DataGridViewRow r in dataGridView1.Rows) // пока в dataGridView1 есть строки
                {
                    DataRow row = ds.Tables["Doctor"].NewRow(); // создаем новую строку в таблице, занесенной в ds
                    row["Name"] = r.Cells[0].Value;  //в столбец этой строки заносим данные из первого столбца dataGridView1
                    row["Education"] = r.Cells[1].Value; // то же самое со вторыми столбцами
                    row["Vector"] = r.Cells[2].Value; //то же самое с третьими столбцами
                    ds.Tables["Doctor"].Rows.Add(row); //добавление всей этой строки в таблицу ds.
                }
                ds.WriteXml("C:\\Users\\Asus\\source\\repos\\MedCenter2\\Data.xml");

                
                MessageBox.Show("XML файл успешно сохранен.", "Выполнено.");

            }
            catch
            {
                MessageBox.Show("Невозможно сохранить XML файл.", "Ошибка.");
            }
        }
    }

   

}
