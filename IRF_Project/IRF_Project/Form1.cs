using IRF_Project.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_Project
{
    public partial class Form1 : Form
    {
        private BindingList<Rendeles> adat = new BindingList<Rendeles>();

        public Form1()
        {
            InitializeComponent();
        }

        private BindingList<Rendeles> Beolvas(string csvpath)
        {
            BindingList<Rendeles> rendelesek = new BindingList<Rendeles>();
            try
            {
                using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] sor = sr.ReadLine().Split(';');

                        Rendeles r = new Rendeles()
                        {
                            TortaNev = sor[0],
                            Allergen = Convert.ToInt32(sor[1]),

                        };
                        rendelesek.Add(r);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return rendelesek;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adat = Beolvas("CSV file/rendelesek.csv");
            dataGridView1.DataSource = adat;
        }
    }
}
