using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagedParticle : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, Nums.particleLifeTime);
    }
}