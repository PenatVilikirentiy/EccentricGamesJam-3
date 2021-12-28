using UnityEngine;

public class TurretsPlacer : MonoBehaviour
{
    private Turret _turretToPlace;

    private bool _isAvailableToPlace;

    private void Update()
    {
        if(_turretToPlace != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                Physics.Raycast(_turretToPlace._raycast.position, _turretToPlace._raycast.forward, out RaycastHit groundHit, 15f);
                _turretToPlace.transform.position = new Vector3(0, groundHit.point.y, hit.point.z);

                TrainWagon wagon = groundHit.collider?.attachedRigidbody?.GetComponent<TrainWagon>();

                if (wagon)
                {
                    _isAvailableToPlace = _turretToPlace.transform.position.z >= wagon._gridSize.y - _turretToPlace._size.y &&
                                          _turretToPlace.transform.position.z <= wagon._gridSize.y + _turretToPlace._size.y;
                }

                _turretToPlace.SetTranparent(_isAvailableToPlace);

                if (Input.GetMouseButtonDown(0))
                {
                    _turretToPlace.transform.position = new Vector3(0, groundHit.point.y, 1);
                    wagon.Turrets.Add(_turretToPlace);
                    _turretToPlace.transform.parent = wagon.transform;
                    _turretToPlace.SetNormal();
                    _turretToPlace = null;
                }
            }
        }
    }

    public void PlaceTurret(Turret turret)
    {
        if(_turretToPlace != null)
        {
            Destroy(_turretToPlace.gameObject);
        }

        _turretToPlace = Instantiate(turret);
    }

    private void OnDrawGizmos()
    {
        if(_turretToPlace != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(_turretToPlace._raycast.position, _turretToPlace._raycast.forward * 15f);
        }
    }
}
