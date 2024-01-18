﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering2D
{
    public readonly struct Outline
    {
        public readonly Colour Colour { get; init; }
        public readonly float Thickness { get; init; }
    }
}