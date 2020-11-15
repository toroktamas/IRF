﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week08.Abstractions;
using week08.Entities;

namespace week08
{
    public partial class Form1 : Form
    {
        private List<Toy> _toys = new List<Toy>();

        private Toy _nextToy;
        private IToyFactory _factory;
        public IToyFactory Factory
        {
            get { return _factory; }
            set { 
                _factory = value;
                DisplayNext();
            }
        }

        public Form1()
        {
            InitializeComponent();

        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var toy = Factory.CreateNew();
            _toys.Add(toy);
            toy.Left = -toy.Width;
            mainPanel.Controls.Add(toy);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var toy in _toys)
            {
                toy.MoveToy();
                if (toy.Left > maxPosition)
                    maxPosition = toy.Left;
            }

            if (maxPosition > 1000)
            {
                var oldestBall = _toys[0];
                mainPanel.Controls.Remove(oldestBall);
                _toys.Remove(oldestBall);
            }
        }

        private void btnSelectCar_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void btnSelectBall_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory();
        }

        private void DisplayNext()
        {
            if (_nextToy != null)
                Controls.Remove(_nextToy);
            _nextToy = Factory.CreateNew();
            _nextToy.Top = lblNext.Top + lblNext.Height + 20;
            _nextToy.Left = lblNext.Left;
            Controls.Add(_nextToy);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var colorPicker = new ColorDialog();

            colorPicker.Color = button.BackColor;
            if (colorPicker.ShowDialog() != DialogResult.OK)
                return;
            button.BackColor = colorPicker.Color;
        }
    }
}
