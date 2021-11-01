using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormsMedCenter
{
    public partial class MedCenter : Form
    {
        public MedCenter()
        {
            InitializeComponent();
            medcentreTableAdapter1.Fill(dsMedCenter1.MEDCENTRE);
            diR_VECTORTableAdapter1.Fill(dsMedCenter1.DIR_VECTOR);
            doctorTableAdapter1.Fill(dsMedCenter1.DOCTOR);
            patientTableAdapter1.Fill(dsMedCenter1.PATIENT);
            illnessTableAdapter1.Fill(dsMedCenter1.ILLNESS);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            medcentreTableAdapter1.Update(dsMedCenter1.MEDCENTRE);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            diR_VECTORTableAdapter1.Update(dsMedCenter1.DIR_VECTOR);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            doctorTableAdapter1.Update(dsMedCenter1.DOCTOR);
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            patientTableAdapter1.Update(dsMedCenter1.PATIENT);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            illnessTableAdapter1.Update(dsMedCenter1.ILLNESS);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                int id = (int)dataGridView1.CurrentRow.Cells["mCIDDataGridViewTextBoxColumn"].Value;

                global::System.Nullable<int> mc_count = queriesTableAdapter1.SQCountMC_IDInDoctor_Medcentre(id);

                if(mc_count==0)
                {
                    mEDCENTREBindingSource.RemoveCurrent();
                }
                else
                {
                    MessageBox.Show("Видаляти не можна. До мед. центра прив'язні лікарі", "Помилка видалення мед. центра");
                }
            }
            catch
            {
                MessageBox.Show("Помилка видалення інформації про мед. центр", "Видалення інформації про мед. центр");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dataGridView2.CurrentRow.Cells["dVIDDataGridViewTextBoxColumn"].Value;

                global::System.Nullable<int> mc_count = queriesTableAdapter1.SQCountDV_IDInDoctor(id);

                if (mc_count == 0)
                {
                    dIRVECTORBindingSource.RemoveCurrent();
                }
                else
                {
                    MessageBox.Show("Видаляти не можна. До напряму прив'язні лікарі", "Помилка видалення напряму");
                }
            }
            catch
            {
                MessageBox.Show("Помилка видалення інформації про напрям", "Видалення інформації про напрям");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dataGridView3.CurrentRow.Cells["dOIDDataGridViewTextBoxColumn"].Value;

                global::System.Nullable<int> mc_count = queriesTableAdapter1.SQCountPA_IDInPI(id);

                if (mc_count == 0)
                {
                    dOCTORBindingSource.RemoveCurrent();
                }
                else
                {
                    MessageBox.Show("Видаляти не можна. До лікаря прив'язні пацієнти", "Помилка видалення лікаря");
                }
            }
            catch
            {
                MessageBox.Show("Помилка видалення інформації про лікаря", "Видалення інформації про лікаря");
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pATIENTBindingSource.RemoveCurrent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dataGridView5.CurrentRow.Cells["iLIDDataGridViewTextBoxColumn"].Value;

                global::System.Nullable<int> mc_count = queriesTableAdapter1.SQCountPA_IDInPI2(id);

                if (mc_count == 0)
                {
                    iLLNESSBindingSource.RemoveCurrent();
                }
                else
                {
                    MessageBox.Show("Видаляти не можна. До хвороби прив'язні пацієнти", "Помилка видалення хвороби");
                }
            }
            catch
            {
                MessageBox.Show("Помилка видалення інформації про хворобу", "Видалення інформації про хворобу");
            }

            
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
                try
                {
                    int id = (int)dataGridView2.CurrentRow.Cells["dVIDDataGridViewTextBoxColumn"].Value;
                    string name = (string)dataGridView2.CurrentRow.Cells["dVNAMEDataGridViewTextBoxColumn"].Value;


                    DoctorVector doctorsDialog = new DoctorVector(id, name);


                    doctorsDialog.ShowDialog(this);
                    doctorsDialog.Dispose();
                }


                catch
                {
                    MessageBox.Show("Помилка переходу до списку лікарів", "Перехід до списку лікарів");
                }
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }
    }
}
