using Assets.Scripts.InGame.System;

namespace Assets.Scripts.InGame.UI.ContextMenu
{
    public class EquipCompositeContextMenu : CompositeContextNenu
    {
        public EquipCompositeContextMenu(IItemSlot itemSlot)
        {
            Add(new EquipContextMenu(itemSlot));
            Add(new RefundContextMenu(itemSlot));
        }
    }

    public class EquipContextMenu : IContextMenu
    {
        private string _label;
        private IItemSlot _selectedItemSlot;

        public EquipContextMenu(IItemSlot itemSlot) 
        {
            SetLabel(ContextMenuButtonLabel.Equip);
            _selectedItemSlot = itemSlot;
        }

        public void OnSelect()
        {
            InventoryManager.Instance.EquipItem(_selectedItemSlot);
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
