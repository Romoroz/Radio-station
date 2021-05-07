using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Radiostancija
{
    public partial class Form1 : Form
    {
        int i = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void timerForm2_Tick(object sender, EventArgs e)
        {
            Form2 StartScreen = new Form2();
            StartScreen.Show();
            timerForm2.Enabled = false; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 Options = new Form3();
            Options.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 Звуковые_эффекты = new Form4();
            Звуковые_эффекты.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Name = "% загруженности\n процессора";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int row = плейлистDataGridView.Rows.Add(); 
            плейлистDataGridView.Rows[row].Cells["Код песни"].Value = row;
            плейлистDataGridView.Rows[row].Cells["Песня"].Value = песняTextBox.Text;
            плейлистDataGridView.Rows[row].Cells["Информация о песне"].Value = информация_о_песнеTextBox.Text;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            расписаниеBindingSource.EndEdit();
            dataSet1.WriteXml($"{Application.StartupPath}/data.dat");
            MessageBox.Show("Твой данные успешно сохранены", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            i++;
            if (i % 2 == 0)
            {
                label1.Text = "Трансляция остановлена";
            }
            else if (i % 2 == 1)
            {
                label1.Text = "Трансляция восстановлена";
                if (i == 1)
                {
                    label1.Text = "Трансляция началась";
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // загрузка процессора
            progressBar1.Value = ((int)Процессор.NextValue());
            label7.Text = progressBar1.Value.ToString() + "%";
            chart1.Series[0].Points.AddY(progressBar1.Value);
            // количество достпуной оперативной памяти
            label8.Text = ((int)pcДоступнаяПамять.NextValue()).ToString() + " Кб";
            chart2.Series[0].Points.AddY((int)pcДоступнаяПамять.NextValue());   
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();      
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            плейлистBindingSource.EndEdit();
            dataSet1.WriteXml($"{Application.StartupPath}/data.dat");
            MessageBox.Show("Твой данные успешно сохранены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            размещение_рекламыBindingSource.EndEdit();
            dataSet1.WriteXml($"{Application.StartupPath}/data.dat");
            MessageBox.Show("Твой данные успешно сохранены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            аудиозаписиBindingSource.EndEdit();
            dataSet1.WriteXml($"{Application.StartupPath}/data.dat");
            MessageBox.Show("Твой данные успешно сохранены!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 Аудиозапись = new Form5();
            Аудиозапись.Show();
        }
    }
}
