using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Rendering2D
{
    public class Polygon : IEnumerable<Vector2>
    {
        private Transform2D _transform;

        public Vector2 Offset
        {
            get => _transform.Translation;
            set => _transform.Translation = value;
        }

        public float Rotation
        {
            get => _transform.Rotation;
            set => _transform.Rotation = value;
        }

        private IList<Vector2> _vertices;
        /// <summary>
        /// Accesses the vertices of the polygon.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Vector2 this[int index]
        {
            get => _vertices[index];
            set => _vertices[index] = value;
        }

        public Polygon(IEnumerable<Vector2> vertices)
        {
            _vertices = new List<Vector2>(vertices);

            _transform = new Transform2D()
            {
                Translation = Vector2.Zero,
                Rotation = 0,
                Scale = Vector2.One
            };
        }

        public IEnumerator<Vector2> GetEnumerator()
        {
            return _vertices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
