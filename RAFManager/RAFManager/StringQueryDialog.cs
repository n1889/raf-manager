﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RAFManager
{
    public partial class StringQueryDialog : Form
    {
        public StringQueryDialog(string title)
        {
            InitializeComponent();
            this.Text = title;
            this.Load += new EventHandler(StringQueryDialog_Load);
            this.stringTb.KeyDown += new KeyEventHandler(stringTb_KeyDown);
            this.TopMost = true;
            ManageLayout();
        }

        void stringTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.stringTb.Text = "";
                Close();
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                Close();
            }
        }

        void StringQueryDialog_Load(object sender, EventArgs e)
        {
            this.Location = new Point(
                Cursor.Position.X - this.Width / 2,
                Cursor.Position.Y - this.Height / 2 - 10
            );
            this.stringTb.Focus();
        }
        private void ManageLayout()
        {
            this.stringTb.Top = 0;
            this.stringTb.Left = 0;
            this.stringTb.Width = this.ClientSize.Width - this.okBtn.Width;
            this.stringTb.Height = this.ClientSize.Height;

            this.okBtn.Top = 0;
            this.okBtn.Left = this.ClientSize.Width - this.okBtn.Width;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        public string Value
        {
            get
            {
                return this.stringTb.Text;
            }
        }
    }
}
