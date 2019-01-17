using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    class Square : Button
    {        
        //makes the default text blank
        public override string Text { get => ""; }
             
        //makes the button red when clicked
        protected override void OnClick(EventArgs e)
        {
            this.BackColor = Color.Red;
        }
    }
}