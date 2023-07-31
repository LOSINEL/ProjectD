using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.InGame.UI.Shop
{
    public class ShopPurchaseConfirmPopupController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _shopPurchaseConfirmPopup;

        [SerializeField]
        private Text _shopPurchaseConfirmDialog;

        [SerializeField]
        private Text _shopPurshaceConfirmYesButtonText;
        private ItemSO _selectedItem;

        // TODO
        // this variable might be exist in ItemSO.
        // Check if those exist in ItemSO, remove them.
        private string _dialog;
        private int _cost;

        public bool IsShopPurchaseConfirmPopupUIOpen
        {
            get { return _shopPurchaseConfirmPopup.activeSelf; }
        }

        public void OpenShopPurchaseConfirmPopupUI(ItemSO item)
        {
            _shopPurchaseConfirmPopup.SetActive(true);
            _selectedItem = item;
            Initialize();
        }

        public void CloseShopPurchaseConfirmPopup()
        {
            _shopPurchaseConfirmPopup.SetActive(false);
        }

        public void Initialize()
        {
            if (_selectedItem is EquipmentSO)
            {
                EquipmentSO selectedEquipment = (EquipmentSO)_selectedItem;
                Dictionary<Enums.ITEM_GRADE, string> _gradeDictionary =
                    new()
                    {
                        { Enums.ITEM_GRADE.NORMAL, ShopPurchaseConfirmPopupStrings.NormalGrade },
                        { Enums.ITEM_GRADE.RARE, ShopPurchaseConfirmPopupStrings.RareGrade },
                        { Enums.ITEM_GRADE.EPIC, ShopPurchaseConfirmPopupStrings.EpicGrade }
                    };
                _dialog =
                    $"{_gradeDictionary[selectedEquipment.Grade]} {selectedEquipment.ItemName}\n진짜 구매하시겠습니까?";
            }
            else
            {
                _dialog = $"{_selectedItem.ItemName}\n진짜 구매하시겠습니까?";
            }

            // TODO
            // This is temporary value for test.
            // It should be fixed after create ItemPrice value in ItemSO.
            _cost = 300;

            _shopPurchaseConfirmDialog.text = _dialog;
            _shopPurshaceConfirmYesButtonText.text = $"구매\n{_cost}G";
            _shopPurchaseConfirmPopup.transform.position = new Vector3(
                Screen.width / 2,
                Screen.height / 2,
                0
            );
        }

        public void Purchase()
        {
            if (InventoryManager.Instance.IsInventoryFull())
            {
                CloseShopPurchaseConfirmPopup();
                return;
            }

            // add item to inventory.
            InventoryManager.Instance.MinusGold(_cost);
            InventoryManager.Instance.AddItem(_selectedItem);
            // TODO
            // pay money for item.

            CloseShopPurchaseConfirmPopup();
        }

        public void Cancel()
        {
            CloseShopPurchaseConfirmPopup();
        }
    }
}
