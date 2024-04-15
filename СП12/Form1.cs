using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace СП12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputLanguageCollection installedLangs = InputLanguage.InstalledInputLanguages;
            foreach (InputLanguage lang in installedLangs)
            {
                dataGridView1.Rows.Add(lang.Culture.Name, lang.LayoutName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                int n = dataGridView1.CurrentCell.RowIndex;
                string languageName = dataGridView1.Rows[n].Cells[0].Value.ToString();
                InputLanguage lang = InputLanguage.FromCulture(new CultureInfo(languageName));
                InputLanguage.CurrentInputLanguage = lang;
                MessageBox.Show($"Установлен язык: {languageName}", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Выберите язык для установки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}