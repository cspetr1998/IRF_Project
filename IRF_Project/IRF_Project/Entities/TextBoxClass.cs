using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_Project.Entities
{
    public class TextBoxClass : TextBox

    {
        public TextBoxClass()
        {
            this.Text = "Sütemény neve...";
            this.GotFocus += RemoveText;
            this.Width = 200;
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (this.Text == "Sütemény neve...")
            {
                this.Text = "";
            }
        }
        public void AddText(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(this.Text))
            {
                this.Text = "Sütemény neve...";
            }
        }
        public String getText()
        {
            return this.Text == "Sütemény neve..." ? "" : this.Text;
        }
    }

}
