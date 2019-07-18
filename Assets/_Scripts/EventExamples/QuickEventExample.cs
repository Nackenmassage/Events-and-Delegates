using System;
using UnityEngine;

public class QuickEventExample : MonoBehaviour
{
    // use an Action as a prebuilt delegate - returns void takes zero parameters
    public event Action OnLShiftDown;
    public event Action<int, float> PDown;
    public event Func<int, float, QuickEventExample> SomethingHappened;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnLShiftDown?.Invoke();
            //if (OnLShiftDown != null)
            //{
            //    OnLShiftDown();
            //}
        }
    }
}
