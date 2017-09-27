using System;
using UnityEngine;

public class StandardEventPatternExample : MonoBehaviour
{

    // long version
    public delegate void SpacePressedHandler(object sender, SpacePressedEventArgs e);
    public event SpacePressedHandler SpacePressed1;

    // short version
    public event EventHandler<SpacePressedEventArgs> SpacePressed2;

    // even shorter - no event args
    public event EventHandler SpacePressed3;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // null check, are there subscribers
            if (SpacePressed1 != null)
            {
                // using the standard constructor
                SpacePressedEventArgs e = new SpacePressedEventArgs();
                e.message = "Hello everybody!";
                SpacePressed1(this, e);
            }

            if (SpacePressed2 != null)
            {
                // using a custom constructor
                SpacePressedEventArgs e = new SpacePressedEventArgs("Hello Again!");
                SpacePressed2(this, e);
            }

            if (SpacePressed3 != null)
            {
                // no constructor, instead pass built-in empty value
                SpacePressed3(this, EventArgs.Empty);
            }

        }
    }
}

public class SpacePressedEventArgs : EventArgs
{
    public string message { get; set; }

    // explicit standard constructor - becomes necessary, because there is a custom constructor!
    public SpacePressedEventArgs()
    {
        message = "Default message."; // optional
    }

    // custom constructor
    public SpacePressedEventArgs(string message)
    {
        this.message = message;
    }

}
