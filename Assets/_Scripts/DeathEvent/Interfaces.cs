using System;
using UnityEngine;

public interface INotifyOnDeath
{
    event Action<GameObject> OnDeath;
}
