using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedParticle : MonoBehaviour
{
    WaitForSeconds waitTime;

    private void Awake()
    {
        waitTime = new(Nums.particleLifeTime);
    }

    private void OnEnable()
    {
        transform.SetAsLastSibling();
        StartCoroutine(PlayParticle());
    }

    private void OnDisable()
    {
        transform.SetAsFirstSibling();
    }

    IEnumerator PlayParticle()
    {
        yield return waitTime;
        gameObject.SetActive(false);
    }
}