using UnityEngine;

public class Killer : MonoBehaviour
{

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }
    }

}
