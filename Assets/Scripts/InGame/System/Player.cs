using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] PlayerData data;



    public PlayerData Data { get { return data; } }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }

    void InitStat()
    {
    }

    [System.Serializable]
    public class PlayerData
    {
        [SerializeField] SerializableDictionary<Enums.STAT_TYPE, Stat> stats = new();

        public Stat GetStat(Enums.STAT_TYPE statType) => stats.GetValue(statType);

        public void AddStat(Enums.STAT_TYPE statType, float num) => stats.GetValue(statType).AddStat(num);
        public void SubStat(Enums.STAT_TYPE statType, float num) => stats.GetValue(statType).SubStat(num);
    }

    [System.Serializable]
    public class Stat
    {
        [SerializeField] string statName;
        [SerializeField] float statValue;

        public string StatName { get { return statName; } }
        public float StatValue { get { return statValue; } }

        public void AddStat(float num) => statValue += num;
        public void SubStat(float num) => statValue -= num;
    }
}