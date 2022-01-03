using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private TrainWagon _currentSelectedWagon;
    private EnemyHealth _selectedEnemy;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(cameraRay, out RaycastHit hit, 100f))
            {
                //TrainWagon wagon = hit.collider?.attachedRigidbody?.GetComponent<TrainWagon>();

                if (_selectedEnemy) {
                    _selectedEnemy.TurnOffTarget();
                }
                //if (_selectedEnemy && hit.collider?.attachedRigidbody?.GetComponent<EnemyHealth>()) {
                //    _selectedEnemy.TurnOffTarget();
                //}                


                _selectedEnemy = hit.collider?.attachedRigidbody?.GetComponent<EnemyHealth>();


                //if (wagon)
                //{
                //    _currentSelectedWagon = wagon;
                //}

                if (_selectedEnemy && _currentSelectedWagon)
                {
                    _currentSelectedWagon.Attack(_selectedEnemy);
                    _selectedEnemy.BecomeTarget();

                }
            }
        }
    }
}
