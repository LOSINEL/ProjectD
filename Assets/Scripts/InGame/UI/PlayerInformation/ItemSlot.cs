//using System.Collections;
//using UnityEngine;
//using UnityEngine.UI;

//using Assets.Scripts.InGame.System;

//public class ItemSlot<Subject, Observer, Type> :
//    MonoBehaviour,
//    IObserver<Subject>
//    where Subject : ISubject<Observer, Type>
//    where Observer : IObserver<Subject>
//    where Type : ItemSO
//{
//    private Image _itemImage;
//    private Subject _subject;
//    private InventoryItemSlotDragHandler _itemSlotDragHandler;

//    void Start()
//    {
//        _itemImage = GetComponent<Image>();
//    }

//    public void Initialize(Subject subject)
//    {
//        _subject = subject;
//    }

//    public void UpdateObserver()
//    {
//        ItemSO item = _subject.GetState(this);
//        _itemImage.sprite = item.ItemSprite;
//    }
//}
