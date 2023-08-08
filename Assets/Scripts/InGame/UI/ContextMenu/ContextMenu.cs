using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts.InGame.System;

namespace Assets.Scripts.InGame.UI.ContextMenu
{
    // Composite Pattern

    public class CompositeContextNenu : IContextMenu
    {
        private List<IContextMenu> _childList;

        public CompositeContextNenu()
        {
            _childList = new List<IContextMenu>();
        }

        public void Add(IContextMenu contextMenu) 
        {
            if (_childList.Contains(contextMenu)) return;

            _childList.Add(contextMenu);
        }

        public void Remove(IContextMenu contextMenu) 
        { 
            if (!_childList.Contains(contextMenu)) return;

            _childList.Remove(contextMenu);
        }

        public List<IContextMenu> GetChildList()
        {
            return _childList;
        }
    }
}
