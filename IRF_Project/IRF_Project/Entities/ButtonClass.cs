using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_Project.Entities
{
    class ButtonClass : Button
    {
        public ButtonClass()
        {
            this.Text = "Hozzáadás";
            this.Width = 100;
            this.Height = 50;
            this.BackColor = System.Drawing.Color.LightGreen;
        }
    }
}
