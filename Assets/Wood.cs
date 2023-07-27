using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Wood : MonoBehaviour, ICollectible
{
    public static event Action OnWoodCollected;

    public void Collect()
    {
        Destroy(gameObject);
        OnWoodCollected?.Invoke();
    }
}

