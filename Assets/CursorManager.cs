using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private TrainWagon _currentSelectedWagon;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(cameraRay, out RaycastHit hit, 100f))
            {
                TrainWagon wagon = hit.collider.attachedRigidbody.GetComponent<TrainWagon>();
                //Enemy enemy = hit.collider.attachedRigidbody.GetComponent<Enemy>();

                if (wagon)
                {
                    _currentSelectedWagon = wagon;
                }

                //if (enemy && _currentSelectedWagon)
                //{
                //    _currentSelectedWagon.Attack();
                //}
            }            
        }
    }
}