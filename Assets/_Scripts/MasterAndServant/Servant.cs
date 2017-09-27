using System;
using UnityEngine;

public class Servant : MonoBehaviour
{

    public void DoWhatImTold(Action<GameObject> a)
    {
        a(gameObject);
    }

}
