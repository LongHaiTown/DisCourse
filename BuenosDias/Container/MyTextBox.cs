using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuenosDias.Container
{

    public class MyTextBox : TextBox
    {
        private string _placeholderText;

        public string PlaceholderText
        {
            get { return _placeholderText; }
            set
            {
                _placeholderText = value;
                SetPlaceholder();
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            RemovePlaceholder();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            SetPlaceholder();
        }

        private void SetPlaceholder()
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = _placeholderText;
                this.ForeColor = Color.Gray;
                this.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
            }
        }

        private void RemovePlaceholder()
        {
            if (this.Text == _placeholderText)
            {
                this.Text = "";
                this.ForeColor = Color.Black;
                this.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            }
        }
         public MyTextBox()
        {
            this.Multiline = true;        
        }
    }
}
