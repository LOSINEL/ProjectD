using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<Tkey, Tvalue>
{
    [SerializeField] List<Tkey> keyList = new();
    [SerializeField] List<Tvalue> valueList = new();

    public int Count { get { return valueList.Count; } }

    public void Add(Tkey key, Tvalue value)
    {
        keyList.Add(key);
        valueList.Add(value);
    }

    public Tvalue GetValue(Tkey key)
    {
        return valueList[keyList.IndexOf(key)];
    }

    public Tvalue GetValue(int index)
    {
        return valueList[index];
    }

    public void Remove(Tkey key)
    {
        valueList.Remove(valueList[keyList.IndexOf(key)]);
        keyList.Remove(key);
    }

    public void Clear()
    {
        keyList.Clear();
        valueList.Clear();
    }
}