using UnityEngine;

public class EnemyTurret : MonoBehaviour {
    [SerializeField] private Renderer[] _renderers;
    public Collider Collider;

    public Transform _raycast;

    [SerializeField] private Transform _bulletSpawner;
    [SerializeField] private Transform _turretModelToRotateLeftRight;
    [SerializeField] private Transform _turretModelToRotateUpDown;

    [SerializeField] private EnemyBullet _bulletPrefab;

    [SerializeField] private AudioSource _shotSound;

    [SerializeField] private ParticleSystem _shotEffect;

    [SerializeField] private GameObject _muzzleFlash;

    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _fireRate = 5f;
    [SerializeField] private float _rotationSpeed = 1f;

    [SerializeField] private LayerMask _whatIsEnemy;

    public TrainWagon _currentTarget;
    [SerializeField] private ChooseTargetWagon _chooseTargetWagon;

    //public Vector2Int _size = Vector2Int.one;

    private float _nextTimeToFire = 0;

    //private TrainWagon[] _targets;

    public void _getTarget(TrainWagon currentTarget) {
        _currentTarget = currentTarget;
    }


    private void Start() {
        //_chooseTargetWagon.SetTarget();
    }

    private void Update() {
        if (_currentTarget.IsActive == true) {
            if (Aim() && Time.time >= _nextTimeToFire) {
                _nextTimeToFire = Time.time + 1 / _fireRate;
                Shoot();
            }
        } else {
            _chooseTargetWagon.ResetTarget();
        }

    }

    public void Shoot() {
        //var shotSound = Instantiate(_shotSound);
        //shotSound.volume = 0.3f;
        //_shotSound.pitch = Random.Range(0.9f, 1.1f);
        AudioSource shotSound = Instantiate(_shotSound, transform.position, Quaternion.identity);
        Destroy(shotSound.gameObject, 2f);
        //Destroy(shotSound.gameObject, 1f);

        //_muzzleFlash.SetActive(true);
        //Invoke(nameof(HideMuzzleFlash), 0.1f);

        //Bullet bullet = ObjectPool.SharedInstance.GetPooledObject();
        //if (bullet != null)
        //{
        //    bullet.transform.position = _bulletSpawner.position;
        //    bullet.transform.rotation = Quaternion.identity;
        //    bullet.gameObject.SetActive(true);
        //    bullet.GetComponent<Rigidbody>().velocity = _bulletSpawner.forward * _bulletSpeed;
        //}
        EnemyBullet bullet = Instantiate(_bulletPrefab, _bulletSpawner.position, Quaternion.identity);
        bullet.Rigidbody.velocity = _bulletSpawner.forward * _bulletSpeed;
    }


    public bool Aim() {
        //if (_currentTarget.IsActive == false) {s
        //    //_chooseTargetWagon.ResetTarget();
        //}

        Vector3 target = _currentTarget.transform.position - _bulletSpawner.position;
        Vector3 upDownRotation = new Vector3(target.x, target.y, 0);
        Vector3 leftRightRotation = new Vector3(target.x, 0, target.z);

        Quaternion targetXRotation = Quaternion.LookRotation(upDownRotation);
        Quaternion targetYRotation = Quaternion.LookRotation(leftRightRotation, Vector3.up);
        _turretModelToRotateLeftRight.rotation = Quaternion.Lerp(_turretModelToRotateLeftRight.rotation, targetYRotation, Time.deltaTime * _rotationSpeed);
       // _turretModelToRotateUpDown.rotation = Quaternion.Lerp(_turretModelToRotateUpDown.rotation, targetXRotation, Time.deltaTime * _rotationSpeed);

        return Physics.Raycast(_bulletSpawner.position, _bulletSpawner.forward, 100f, _whatIsEnemy);
    }



    private void HideMuzzleFlash() {
        _muzzleFlash.SetActive(false);
    }

    public void SetTranparent(bool isAvailable) {
        if (isAvailable) {
            foreach (Renderer renderer in _renderers) {
                renderer.material.color = new Color(0, 1, 0, .2f);
            }
        } else {
            foreach (Renderer renderer in _renderers) {
                renderer.material.color = new Color(1, 0, 0, .2f);
            }
        }
    }

    public void SetNormal() {
        foreach (Renderer renderer in _renderers) {
            renderer.material.color = new Color(1, 1, 1, 1);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(_bulletSpawner.position, _bulletSpawner.forward * 100f);

    //    //for (int x = 0; x < _size.x; x++)
    //    //{
    //    //    for (int y = 0; y < _size.y; y++)
    //    //    {
    //    //        Gizmos.color = Color.yellow;
    //    //        Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, 0.1f, 1));
    //    //    }
    //    //}
    //}
}
