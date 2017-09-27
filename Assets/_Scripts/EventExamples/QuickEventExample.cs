using System;
using UnityEngine;

public class QuickEventExample : MonoBehaviour
{
    // use an Action as a prebuilt delegate - returns void takes zero parameters
    public event Action OnLShiftDown;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (OnLShiftDown != null)
            {
                OnLShiftDown();
            }
        }
    }
}
