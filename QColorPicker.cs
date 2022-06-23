using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My.Controls
{
    public interface IQColorPicker
    {
        void NotifyColorChanged(int buttonIndex, Color c);
        void NotifySelected(int buttonIndex, Color c);
    }
    public partial class QColorPicker : UserControl, IQColorButton
    {
        List<QColorButton> m_qlist = new List<QColorButton>();
        public QColorPicker()
        {
            InitializeComponent();
           
        }
        IQColorPicker pIQColorPicker = null;
        public void LoadControl(List<Color> listColors,
                                int width,int height,
                                int leftStart, IQColorPicker p)
        {
            pIQColorPicker = p;

            for (int i = 0; i < listColors.Count; i++)
            {
                QColorButton q = new QColorButton();
                q.Size = new Size(width, height);
                q.Setup(this,i);
                q.SetColor(listColors[i]);                
                q.Left += leftStart + i * q.Width + i * 10;
                this.Controls.Add(q);
                m_qlist.Add(q);
            }
            this.Height = height + 20;

        }
        Color m_selectedColor = Color.Transparent;
        public Color SelectedColor
        {
            get
            {
                return m_selectedColor;
            }
        }

        public void NotifyColorSelected(QColorButton control, int buttonIndex, Color color)
        {
            m_selectedColor = color;
            pIQColorPicker.NotifySelected(buttonIndex, color);
            foreach (var c in m_qlist)
            {               
                if (c == control)
                    continue;
                c.NotPress();
            }
        }

        public void NotifyColorChanged(QColorButton control, int buttonIndex, Color c)
        {
            pIQColorPicker.NotifyColorChanged(buttonIndex, c);
        }
    }
}
