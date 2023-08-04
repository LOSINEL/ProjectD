using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager instance;

    [SerializeField] SerializableDictionary<Enums.EFFECT_TYPE, Effect> effects = new();
    [SerializeField] Material[] itemBoxMetarials;
    Transform tr;

    public Material[] ItemBoxMaterials { get { return itemBoxMetarials; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        tr = transform;
    }

    private void Start()
    {
        InitEffects();
    }

    void InitEffects()
    {
        for (int i = 0; i < effects.Count; i++)
        {
            GameObject tmp = new GameObject();
            tmp.transform.SetParent(tr);
            Effect tmpEffect = effects.GetValue((Enums.EFFECT_TYPE)i);
            for (int j = 0; j < tmpEffect.EffectNum; j++)
            {
                Instantiate(tmpEffect.EffectObject, Vector3.zero, Quaternion.identity, tmp.transform);
            }
        }
    }

    public void PlayEffect(Enums.EFFECT_TYPE type, Vector3 pos)
    {
        Transform tmp = tr.GetChild((int)type);
        GameObject tmpObject = tmp.GetChild(0).gameObject;
        if (tmpObject.activeSelf)
        {
            Instantiate(effects.GetValue(type).EffectObject, Vector3.zero, Quaternion.identity, tmp);
        }
        tmpObject.SetActive(true);
        tmpObject.transform.position = pos;
    }

    [System.Serializable]
    public class Effect
    {
        [SerializeField] GameObject effectObject;
        [SerializeField] int effectNum;
        public GameObject EffectObject { get { return effectObject; } }
        public int EffectNum { get { return effectNum; } }
    }
}