﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering2D
{
    public class Path : IPath
    {
        public virtual Vector2 Evaluate(float t)
        {
            return new Vector2((float)t, (float)t);
        }
    }
}
