using UnityEngine;

public class Master : MonoBehaviour
{

    public Servant servant;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            servant.DoWhatImTold(ChangeColor);
        }
    }

    void ChangeColor(GameObject go)
    {
        Renderer rend = go.GetComponent<Renderer>();
        if (rend != null)
        {
            rend.material.color = Random.ColorHSV(0, 1, 0.7f, 0.9f, 0.8f, 0.9f);
        }
    }

}
