using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPurchaseConfirmPopupController : MonoBehaviour
{
    [SerializeField]
    private GameObject _shopPurchaseConfirmPopup;
    [SerializeField]
    private Text _shopPurchaseConfirmDialog;
    [SerializeField]
    private Text _shopPurshaceConfirmYesButtonText;

    public bool IsShopPurchaseConfirmPopupUIOpen {
        get {
            return _shopPurchaseConfirmPopup.activeSelf;
        }
    }

    public void OpenShopPurchaseConfirmPopupUI(ItemSO _item) {
        _shopPurchaseConfirmPopup.SetActive(true);

        string dialog = $"진짜 구매하시겠습니까?";
        int cost = 300;

        Initialize(dialog, cost);
    }

    public void CloseShopPurchaseConfirmPopup() {
        _shopPurchaseConfirmPopup.SetActive(false);
    }

    public void Initialize(string dialog, int cost)
    {
        _shopPurchaseConfirmDialog.text = dialog;
        _shopPurshaceConfirmYesButtonText.text = $"구매\n{cost}G";
        _shopPurchaseConfirmPopup.transform.position = new Vector3(Screen.width/2, Screen.height/2, 0);
    }

    public void Purchase() { }

    public void Cancel() { }
}
