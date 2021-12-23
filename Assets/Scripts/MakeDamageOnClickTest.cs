using UnityEngine;

public class MakeDamageOnClickTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(cameraRay, out RaycastHit hit, 100f))
            {
                hit.collider.GetComponentInParent<Health>().TakeDamage(50);
            }
        }
    }
}
