using Assets.Scripts.InGame.System;

namespace Assets.Scripts.InGame.UI.ContextMenu
{
    public class UnequipCompositeContextMenu : CompositeContextNenu
    {
        public UnequipCompositeContextMenu(IItemSlot itemSlot)
        {
            Add(new UnequipContextMenu(itemSlot));
        }
    }

    public class UnequipContextMenu : IContextMenu
    {
        private string _label;
        private IItemSlot _selectedItemSlot;

        public UnequipContextMenu(IItemSlot itemSlot) 
        {
            SetLabel("해제");
            _selectedItemSlot = itemSlot;
        }

        public void OnSelect()
        {
            InventoryManager.Instance.UnequipItem(_selectedItemSlot);
        }
        
        public string GetLabel()
        {
            return _label;
        }

        public void SetLabel(string label)
        {
            _label = label;
        }
    }
}
