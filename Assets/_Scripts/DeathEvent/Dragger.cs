using UnityEngine;

public class Dragger : MonoBehaviour
{

    Vector3 offset;
    Plane castedPlane = new Plane(Vector3.up, Vector3.zero);

    void OnMouseDown()
    {
        offset = gameObject.transform.position - GetPointOnPlane();
    }

    void OnMouseDrag()
    {
        transform.position = GetPointOnPlane() + offset;
    }

    Vector3 GetPointOnPlane()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter = 100f;

        if (castedPlane.Raycast(ray, out enter))
        {
            var hitPoint = ray.GetPoint(enter);
            return hitPoint;
        }
        else
        {
            return Vector3.zero;
        }
    }

}
