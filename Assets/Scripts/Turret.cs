using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform CurrentTarget;

    //renderers to change to highlight placement
    [SerializeField] private Renderer[] _renderers;
    //material to change to highlight placement
    [SerializeField] private Material _regularMaterial;
    [SerializeField] private Material _highlightedMaterial;

    [SerializeField] private Transform _bulletSpawner;
    [SerializeField] private Transform _turretModelToRotateLeftRight;
    [SerializeField] private Transform _turretModelToRotateUpDown;

    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] private AudioSource _shotSound;

    [SerializeField] private ParticleSystem _shotEffect;

    [SerializeField] private GameObject _muzzleFlash;

    [SerializeField] private float _bulletSpeed = 100f;
    [SerializeField] private float _fireRate = 5f;
    [SerializeField] private float _rotationSpeed = 1f;

    [SerializeField] private LayerMask _whatIsEnemy;

    private float _nextTimeToFire = 0;

    private void Update()
    {
        if (Aim() && Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1 / _fireRate;
            Shoot();
        }
    }

    public void Shoot()
    {
        var shotSound = Instantiate(_shotSound);
        shotSound.pitch = Random.Range(0.9f, 1.1f);
        shotSound.volume = Random.Range(0.3f, 0.5f);
        _shotSound.Play();
        Destroy(shotSound.gameObject, 1f);

        _muzzleFlash.SetActive(true);
        Invoke(nameof(HideMuzzleFlash), 0.05f);

        Bullet bullet = Instantiate(_bulletPrefab, _bulletSpawner.position, _bulletSpawner.rotation);
        bullet.Rigidbody.velocity = _bulletSpawner.forward * _bulletSpeed;
    }

    public bool Aim()
    {
        if (CurrentTarget == null) return false;

        Vector3 targetPos = CurrentTarget.position - _bulletSpawner.position;

        // Rotation left-right
        Quaternion goalRotation = Quaternion.LookRotation(targetPos);
        var eulerRotation = goalRotation.eulerAngles;
        var clampedQuaternion = Quaternion.Euler(0, eulerRotation.y, 0);
        _turretModelToRotateLeftRight.localRotation = Quaternion.Lerp(_turretModelToRotateLeftRight.localRotation, clampedQuaternion, Time.deltaTime * _rotationSpeed);

        // Rotation up-down
        clampedQuaternion = Quaternion.Euler(eulerRotation.x, 0, 0);
        _turretModelToRotateUpDown.localRotation = Quaternion.Lerp(_turretModelToRotateUpDown.localRotation, clampedQuaternion, Time.deltaTime * _rotationSpeed);

        return Physics.Raycast(_bulletSpawner.position, _bulletSpawner.forward, 100f, _whatIsEnemy);
    }

    private void HideMuzzleFlash()
    {
        _muzzleFlash.SetActive(false);
    }

    
    public void SetHightlightedMaterial (){
        foreach (Renderer renderer in _renderers) {
            renderer.material = _highlightedMaterial;
        }
    }
    public void SetNormalMaterial (){
        foreach (Renderer renderer in _renderers) {
            renderer.material = _regularMaterial;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_bulletSpawner.position, _bulletSpawner.forward * 100f);
    }
}
