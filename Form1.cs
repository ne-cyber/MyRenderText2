using MyDirectX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyRenderText2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadFont();
            text = "Олександр Буханенко";
            location = new Point(100, 33);
        }

        String text;
        int index = 0;

        Font font;
        private void LoadFont()
        {
            font = new Font("Calibri", 12f);
        }

        Point location;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.AntiqueWhite);
            RenderRect();
            RenderText();
        }

        private void RenderText()
        {
            Graphics g = this.CreateGraphics();

            TextRenderer.DrawText(g, text, font, location, Color.Red, TextFormatFlags.NoPadding);

            g.Dispose();
        }

        private void RenderRect()
        {
            SizeF textSize = new SizeF(0, 0);
            textSize = CalculateTextSize(text, 0, text.Length);

            Graphics g = this.CreateGraphics();
            g.DrawRectangle(Pens.Blue, new Rectangle(location.X, location.Y, (int)textSize.Width, (int)textSize.Height));
            g.Dispose();
        }



        private SizeF CalculateTextSize(String _text, int begin, int end)
        {
            String text = _text.Substring(begin, end - begin);
            SizeF textSize = new SizeF(0, 0);

            Graphics g = this.CreateGraphics();
            textSize = TextRenderer.MeasureText(g, text, font, new Size(0, 0), TextFormatFlags.NoPadding);
            g.Dispose();

            return textSize;
        }



        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            Size size = new Size(0, 0);
            size = GetCaretSize();
            Point pos = new Point(0, 0);
            pos = GetCaretPos();

            Win32.CreateCaret(this.Handle, IntPtr.Zero, 1, size.Height);
            Win32.SetCaretPos(pos.X, pos.Y);
            Win32.ShowCaret(this.Handle);

        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            Win32.DestroyCaret();
        }



        private Size GetCaretSize()
        {
            Size caretSize = new Size(0, 0);

            String s = "1";
            SizeF sSize = new SizeF(0, 0);

            sSize = this.CalculateTextSize(s, 0, 1);

            caretSize.Width = 1;
            caretSize.Height = (int)sSize.Height;

            return caretSize;
        }

        private Point GetCaretPos()
        {
            Point pos = new Point(0, 0);

            String text1 = text.Substring(0, index);
            String text2 = text.Substring(index);
            String[] lines = text1.Split('\r');
            String lastLineText1 = lines[lines.Length - 1];

            //calculate x
            SizeF lastLineText1Size = new SizeF(0, 0);
            lastLineText1Size = CalculateTextSize(lastLineText1, 0, lastLineText1.Length);
            pos.X = location.X + (int)lastLineText1Size.Width;

            //calculate y
            pos.Y = location.Y;
            SizeF text1Size = new SizeF(0, 0);
            text1Size = CalculateTextSize(text1, 0, text1.Length);
            pos.Y += (int)text1Size.Height;

            String s = "1";
            SizeF sSize = new SizeF(0, 0);
            sSize = CalculateTextSize(s, 0, 1);
            pos.Y -= (text.Substring(0, index).Length != 0 ? 1 : 0) * (int)sSize.Height;

            return pos;
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Point pos = new Point(0, 0);
            String s1 = "", s2 = "";


            switch (e.KeyCode)
            {
                case Keys.Left:
                    index--;
                    index = Math.Max(index, 0);

                    //this.Invalidate();

                    pos = GetCaretPos();
                    Win32.HideCaret(this.Handle);
                    Win32.SetCaretPos(pos.X, pos.Y);
                    Win32.ShowCaret(this.Handle);
                    break;

                case Keys.Right:
                    index++;
                    index = Math.Min(index, text.Length);

                    //this.Invalidate();

                    pos = GetCaretPos();
                    Win32.HideCaret(this.Handle);
                    Win32.SetCaretPos(pos.X, pos.Y);
                    Win32.ShowCaret(this.Handle);
                    break;

                case Keys.Back:
                    s1 = text.Substring(0, Math.Max(index - 1, 0));
                    s2 = text.Substring(index);

                    text = s1 + s2;
                    index--;
                    index = Math.Max(0, index);

                    pos = GetCaretPos();
                    Win32.SetCaretPos(pos.X, pos.Y);

                    this.Invalidate();
                    break;

                case Keys.Delete:
                    s1 = text.Substring(0, index);
                    s2 = text.Substring(Math.Min(index + 1, text.Length));

                    text = s1 + s2;

                    this.Invalidate();
                    break;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Back)
                return;

            String s1 = "", s2 = "";
            s1 = text.Substring(0, index);
            s2 = text.Substring(index);

            text = s1 + e.KeyChar + s2;
            index++;

            Point pos = new Point(0, 0);
            pos = GetCaretPos();
            Win32.SetCaretPos(pos.X, pos.Y);

            this.Invalidate();
        }



        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            

        }
    }
}
