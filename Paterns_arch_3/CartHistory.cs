using System;
using System.Collections.Generic;

namespace Paterns_arch_3
{
    public class CartHistory
    {
        private Stack<Memento> _history = new Stack<Memento>();

        public void SaveState(ShoppingCart cart)
        {
            _history.Push(cart.CreateMemento());
        }

        public Memento Undo()
        {
            return _history.Count > 0 ? _history.Pop() : null;
        }
    }
}

