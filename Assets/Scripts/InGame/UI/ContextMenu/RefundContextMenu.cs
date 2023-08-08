using Assets.Scripts.InGame.System;

namespace Assets.Scripts.InGame.UI.ContextMenu
{
    public class RefundContextMenu : IContextMenu
    {
        private string _label;
        private IItemSlot _selectedItemSlot;

        public RefundContextMenu(IItemSlot itemSlot) 
        {
            SetLabel(ContextMenuButtonLabel.Refund);
            _selectedItemSlot = itemSlot;
        }

        public void OnSelect()
        {
            InventoryManager.Instance.RefundItem(_selectedItemSlot);
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
