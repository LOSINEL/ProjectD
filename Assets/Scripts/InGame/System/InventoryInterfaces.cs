
namespace Assets.Scripts.InGame.System
{
    public interface IObserver
    {
        public abstract void UpdateObserver();
    }

    public interface ISubject<Observer, Type> 
        where Observer : IObserver
        where Type : ItemSO
    {
        public abstract void AddObserver(Observer observer);
        public abstract void RemoveObserver(Observer observer);
        public abstract void Notify();
        public abstract Type GetState(Observer observer);
    }

    public interface IInventorySubject : ISubject<IInventoryObserver, ItemSO> { }
    public interface IInventoryObserver : IObserver { 
        public abstract void Initialize(IInventorySubject subject);
    }
    public interface IEquipmentSubject : ISubject<IEquipmentObserver, EquipmentSO> { }
    public interface IEquipmentObserver : IObserver
    {
        public abstract void Initialize(IEquipmentSubject subject);
    }

    public interface IItemSlot
    {
        public abstract ItemSO GetItem();
        public abstract void SetItem(ItemSO item);
        public abstract bool IsEmpty();
    }

    public interface IEquipmentSlot : IItemSlot
    {
        public abstract Enums.ITEM_TYPE GetEquipmentType();
    }
}
