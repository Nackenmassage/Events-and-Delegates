using System;
using UnityEngine;

public class Monster : MonoBehaviour, INotifyOnDeath
{
    public event Action<GameObject> OnDeath;

    void OnDisable()
    {
        if (OnDeath != null)
        {
            OnDeath(gameObject);
        }
    }
}
