﻿using FamilyTreeTools.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyTreeTools
{
    public partial class ValidationFailedDialog : Form
    {
        public ValidationFailedDialog(string message)
        {
            InitializeComponent();
            Icon = Resources.favicon;
            MessageBox.Text = message;
        }
    }
}