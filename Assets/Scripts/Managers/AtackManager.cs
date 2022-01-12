using UnityEngine;

public class AtackManager : MonoBehaviour
{
    public EnemyHealth _selectedEnemy;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(cameraRay, out RaycastHit hit, 1000f))
            {
                if (_selectedEnemy) {
                    _selectedEnemy.TurnOffTarget();
                }

                _selectedEnemy = hit.collider?.attachedRigidbody?.GetComponent<EnemyHealth>();

                if (_selectedEnemy  )
                {
                    //_currentSelectedWagon.Attack(_selectedEnemy);
                    Train.Instance.Atack(_selectedEnemy.transform);
                    _selectedEnemy.BecomeTarget();
                }
            }
        }
    }
}
