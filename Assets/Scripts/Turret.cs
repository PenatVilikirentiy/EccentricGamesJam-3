using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform CurrentTarget;

    [SerializeField] private Transform _bulletSpawner;
    [SerializeField] private Transform _turretModel;

    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] private AudioSource _shotSound;

    [SerializeField] private ParticleSystem _shotEffect;

    [SerializeField] private GameObject _muzzleFlash;

    [SerializeField] private float _bulletSpeed = 10f;
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
        //var shotSound = Instantiate(_shotSound);
        //shotSound.volume = 0.3f;
        //shotSound.Play();
        //Destroy(shotSound.gameObject, 1f);

        //_muzzleFlash.SetActive(true);
        //Invoke(nameof(HideMuzzleFlash), 0.1f);

        Bullet bullet = Instantiate(_bulletPrefab, _bulletSpawner.position, Quaternion.identity);
        bullet.Rigidbody.velocity = _bulletSpawner.forward * _bulletSpeed;
    }

    public bool Aim()
    {
        if (CurrentTarget == null) return false;

        Vector3 target = CurrentTarget.position - _turretModel.position;
        Quaternion targetRotation = Quaternion.LookRotation(target);
        _turretModel.rotation = Quaternion.Lerp(_turretModel.rotation, targetRotation, Time.deltaTime * _rotationSpeed);

        return Physics.Raycast(_bulletSpawner.position, _bulletSpawner.forward, 100f, _whatIsEnemy);
    }

    private void HideMuzzleFlash()
    {
        _muzzleFlash.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_bulletSpawner.position, _bulletSpawner.forward * 100f);
    }
}
