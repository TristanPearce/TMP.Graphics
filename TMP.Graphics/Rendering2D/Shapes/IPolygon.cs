using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering2D
{
    public interface IPolygon : IShape
    {
        public Vector2 Offset { get; set; }

        public float Rotation { get; set; }

        /// <summary>
        /// Accesses the vertices of the polygon.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Vector2 this[int index] { get; set; }

        public int NumberOfVertices { get; }

        public void SetVertices(params Vector2[] vertices);
    }
}
