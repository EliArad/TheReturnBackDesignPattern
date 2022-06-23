using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My.Controls
{
    public interface IQColorButton
    {
        void NotifyColorSelected(QColorButton control, int buttonIndex, Color c);
        void NotifyColorChanged(QColorButton control, int buttonIndex, Color c);
    }
    public class QColorButton : Button
    {
        int m_buttonIndex = -1;
        IQColorButton pIQColorButton;
        Size m_size;
        public QColorButton()
        {
           
        }

        public void Setup(IQColorButton p, int index)
        {
            m_buttonIndex = index;
            pIQColorButton = p;
            m_size = this.Size;
            this.Click += QColorButton_Click;
            
        }
        Color m_color;
        public void SetColor(Color c)
        {
            this.BackColor = c;
            m_color = c;
        }
        void ShowColorDialog()
        {
            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = true;
            colorDlg.FullOpen = true;
            colorDlg.AnyColor = true;
            colorDlg.SolidColorOnly = false;
     
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = colorDlg.Color;
                pIQColorButton.NotifyColorChanged(this, m_buttonIndex, colorDlg.Color);
            }
        }
        private void QColorButton_Click(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Control))
            {
                ShowColorDialog();
                return;
            }

            this.Size = new Size(m_size.Width + 3, m_size.Height + 3);
            pIQColorButton.NotifyColorSelected(this, m_buttonIndex, m_color);
        }
        public void NotPress()
        {
            this.Size = new Size(m_size.Width, m_size.Height);
        }
    }
}
