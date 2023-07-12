using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InGame.System
{
    public interface IInventoryObserver
    {
        /// <summary>
        /// Subject�� ��ϵ� ��� Observer�� ���¸� ������Ʈ�� ��
        /// ȣ��Ǵ� �Լ�. <br/>
        /// </summary>
        /// <param name="item">Observer�� ��Ÿ������ ������</param>
        public abstract void UpdateObserver();
    }

    public interface IInventorySubject
    {
        public abstract void AddObserver(IInventoryObserver inventoryObserver);
        public abstract void RemoveObserver(IInventoryObserver inventoryObserver);
        public abstract void Notify();
        public abstract ItemSO GetItem(IInventoryObserver inventoryObserver);

        // �κ��丮�� _itemList�� �����ϴ� �޼ҵ�� ���⿡ �����ϰ�
        // ������ Inventory���� �Ѵ�.

        public void AddItem(ItemSO item) { }
        public void RemoveItem(ItemSO item) { }
        public void SwapItem(IInventoryObserver inventoryObserverA, IInventoryObserver inventoryObserverB) { }
    }
}
