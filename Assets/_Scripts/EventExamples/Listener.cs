using System;
using UnityEngine;

public class Listener : MonoBehaviour
{

    public GameObject broadcaster;
    TextMesh textMesh;

    void OnEnable()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        // subscribe
        broadcaster.GetComponent<StandardEventPatternExample>().SpacePressed1 += OnSpacePressed1;
        broadcaster.GetComponent<StandardEventPatternExample>().SpacePressed2 += OnSpacePressed2;
        broadcaster.GetComponent<StandardEventPatternExample>().SpacePressed3 += OnSpacePressed3;
        broadcaster.GetComponent<QuickEventExample>().OnLShiftDown += OnLeftShiftDown;
    }

    void OnDisable()
    {
        // unsubscribe
        broadcaster.GetComponent<StandardEventPatternExample>().SpacePressed1 -= OnSpacePressed1;
        broadcaster.GetComponent<StandardEventPatternExample>().SpacePressed2 -= OnSpacePressed2;
        broadcaster.GetComponent<StandardEventPatternExample>().SpacePressed3 -= OnSpacePressed3;
        broadcaster.GetComponent<QuickEventExample>().OnLShiftDown -= OnLeftShiftDown;
    }

    void OnSpacePressed1(object sender, SpacePressedEventArgs e)
    {
        textMesh.text += e.message + "\n"; // "\n" escape character new line
    }

    void OnSpacePressed2(object sender, SpacePressedEventArgs e)
    {
        textMesh.text += e.message + "\n";
    }

    void OnSpacePressed3(object sender, EventArgs e)
    {
        textMesh.text += "I was given empty event args...\n";
    }

    void OnLeftShiftDown()
    {
        textMesh.text += "Left Shift was pressed.\n";
    }

}
