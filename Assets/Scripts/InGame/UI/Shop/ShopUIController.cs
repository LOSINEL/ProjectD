using UnityEngine;

namespace Assets.Scripts.InGame.UI.Shop
{
    public class ShopUIController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _shopPopup;
        [SerializeField]
        private GameObject _shopPurchaseConfirmPopup;
        private bool _isShopPopupUIOpen;
        public bool IsShopPopupUIOpen
        {
            get { return _shopPopup.activeSelf; }
        }

        public void OpenShopPopupUI()
        {
            _shopPopup.SetActive(true);
        }

        public void CloseShopPopupUI()
        {
            _shopPopup.SetActive(false);
            _shopPurchaseConfirmPopup.SetActive(false);
        }
    }
}
