using IRF_Project.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            adat = Beolvas("CSVfile/rendelesek.csv");
            dataGridView1.DataSource = adat;
            showChart();
        }

        private void showChart()
        {
            chart1.Visible = Visible;
            int countSima = (from rendelesek in adat
                             where rendelesek.Allergen == 1
                             select rendelesek).Count();
            int countMentes = (from rendelesek in adat
                               where rendelesek.Allergen == 2
                               select rendelesek).Count();
            Debug.WriteLine(countSima);
            Debug.WriteLine(countMentes);
            
            chart1.Series["Adatok"].Points.AddXY("Sima", countSima);
            chart1.Series["Adatok"].Points.AddXY("Mentes", countMentes);
        }
    }
}
