using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InGame.System
{
    public interface IInventoryObserver
    {
        /// <summary>
        /// Subject가 등록된 모든 Observer의 상태를 업데이트할 때
        /// 호출되는 함수. <br/>
        /// </summary>
        /// <param name="item">Observer가 나타내야할 아이템</param>
        public abstract void UpdateObserver();
    }

    public interface IInventorySubject
    {
        public abstract void AddObserver(IInventoryObserver inventoryObserver);
        public abstract void RemoveObserver(IInventoryObserver inventoryObserver);
        public abstract void Notify();
        public abstract ItemSO GetItem(IInventoryObserver inventoryObserver);

        // 인벤토리의 _itemList를 수정하는 메소드는 여기에 정의하고
        // 구현은 Inventory에서 한다.

        public void AddItem(ItemSO item) { }
        public void RemoveItem(ItemSO item) { }
        public void SwapItem(IInventoryObserver inventoryObserverA, IInventoryObserver inventoryObserverB) { }
    }
}
