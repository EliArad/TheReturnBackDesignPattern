using My.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheReturnBackDesignPattern
{
    public partial class Form1 : Form, IQColorPicker
    {

        public Form1()
        {
            InitializeComponent();
            lblColor.Text = string.Empty;

            List<Color> listColors = new List<Color>
            {
                Color.Red,
                Color.Green,
                Color.Yellow,
                Color.Aqua,
                Color.Blue,
                Color.Coral,
                Color.Orange
            };
            qColorPicker1.LoadControl(listColors, 50,50, 20, this);
        }

        public void NotifyColorChanged(int buttonIndex, Color c)
        {
                
        }

        public void NotifySelected(int buttonIndex, Color c)
        {
            lblColor.Text = $"Selected Color: {c.ToString()}  Button: {buttonIndex + 1}";
        }
    }
}
