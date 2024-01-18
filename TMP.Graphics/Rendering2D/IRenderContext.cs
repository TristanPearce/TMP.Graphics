﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering2D
{
    public interface IRenderContext
    {
        public event Action<IRenderer2D> Rendering;
    }
}