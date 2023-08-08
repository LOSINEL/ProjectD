using System.Collections.Generic;

namespace Assets.Scripts.InGame.UI.ContextMenu
{
    public interface IContextMenu
    {
        void Initialize() { }
        void Add(IContextMenu contextMenu) { }
        void Remove(IContextMenu contextMenu) { }
        List<IContextMenu> GetChildList()
        {
            return null;
        }
        void OnSelect() { }
        string GetLabel()
        {
            return "";
        }

        void SetLabel() { }
    }
}
