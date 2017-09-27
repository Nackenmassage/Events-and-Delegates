using UnityEngine;

public class DelegateExample: MonoBehaviour
{
    // syntax: 
    // delegate [return type] [delegate name] [parameter list]
    public delegate void MyDelegate(int number);

    void Start()
    {
        MyDelegate md = new MyDelegate(MyMethod); // new delegate instance containing first method
        md(3);
        md = MyOtherMethod; // replace with second method
        md(4);
        md += MyMethod; // add the first method again, but keep the second
        md(5);
        MyDelegate methodContainer = MyMethod; // neues delegate
        ExecuteAGivenDelegate(methodContainer); // wie Variable an andere Methode uebergeben
    }

    void MyMethod(int amount)
    {
        Debug.Log("The amount is: " + amount);
    }

    void MyOtherMethod(int size)
    {
        Debug.Log("The size is: " + size);
    }

    void ExecuteAGivenDelegate(MyDelegate x)
    {
        x(999);
    }
}
