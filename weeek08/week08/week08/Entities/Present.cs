﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using week08.Abstractions;

namespace week08.Entities
{
    public class Present : Toy
    {
        public SolidBrush PresentColor { get; private set; }
        public Present(Color color)
        {
            PresentColor = new SolidBrush(color);
        }
        protected override void DrawImage(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
