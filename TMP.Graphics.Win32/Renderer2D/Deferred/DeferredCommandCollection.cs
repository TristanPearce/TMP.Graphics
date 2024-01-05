using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP.Graphics.Win32.Renderer2D.Deferred
{
    internal class DeferredCommandCollection : ICollection<DeferredCommand>
    {
        private IList<DeferredCommand> _deferredCommands;

        public DeferredCommandCollection()
        {
            _deferredCommands = new List<DeferredCommand>();
        }

        public int Count => _deferredCommands.Count;
        public bool IsReadOnly => _deferredCommands.IsReadOnly;

        public void Add(DeferredCommand item)
        {
            _deferredCommands.Add(item);
        }

        public bool Remove(DeferredCommand item)
        {
            return _deferredCommands.Remove(item);
        }

        public void Clear()
        {
            _deferredCommands.Clear();
        }

        public bool Contains(DeferredCommand item)
        {
            return _deferredCommands.Contains(item);
        }

        public void CopyTo(DeferredCommand[] array, int arrayIndex)
        {
            _deferredCommands.CopyTo(array, arrayIndex);
        }

        public IEnumerator<DeferredCommand> GetEnumerator()
        {
            return _deferredCommands.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
