using UnityEngine;

public enum Barrel { First, Second}

public class TwoGunTurret : Turret
{
    [SerializeField] private Transform _secondBulletSpawner;
    [SerializeField] private Barrel _currentBarrel;
    [SerializeField] private GameObject _secondMuzzleFlash;
    [SerializeField] private Animator _animator;

    private Transform _currentBulletSpawner;
    private GameObject _currentMuzzleFlash;

    private void Start()
    {
        _currentBarrel = Barrel.First;
        _currentBulletSpawner = _bulletSpawner;
        _currentMuzzleFlash = _muzzleFlash;
    }

    private void Update()
    {
        if (Aim() && Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1 / _fireRate;
            Shoot();
        }
    }

    protected override void Shoot()
    {
        var shotSound = Instantiate(_shotSound);
        shotSound.pitch = Random.Range(0.9f, 1.1f);
        shotSound.volume = Random.Range(0.3f, 0.5f);
        _shotSound.Play();
        Destroy(shotSound.gameObject, 1f);

        if(_currentBarrel == Barrel.First)
        {
            _currentBarrel = Barrel.Second;
            _currentBulletSpawner = _secondBulletSpawner;
            _currentMuzzleFlash = _secondMuzzleFlash;
            _animator.SetTrigger("Shot2");
        }
        else
        {
            _currentBarrel = Barrel.First;
            _currentBulletSpawner = _bulletSpawner;
            _currentMuzzleFlash = _muzzleFlash;
            _animator.SetTrigger("Shot1");
        }

        Bullet bullet = Instantiate(_bulletPrefab, _currentBulletSpawner.position, _currentBulletSpawner.rotation);
        bullet.Rigidbody.velocity = _currentBulletSpawner.forward * _bulletSpeed;
        _currentMuzzleFlash.SetActive(true);
        Invoke(nameof(HideMuzzleFlash), 0.05f);
    }

    protected override bool Aim()
    {
        if (CurrentTarget == null) return false;

        Vector3 targetPos = CurrentTarget.position - _currentBulletSpawner.position;

        // Rotation left-right
        Quaternion goalRotation = Quaternion.LookRotation(targetPos);
        var eulerRotation = goalRotation.eulerAngles;
        var clampedQuaternion = Quaternion.Euler(0, eulerRotation.y, 0);
        _turretModelToRotateLeftRight.localRotation = Quaternion.Lerp(_turretModelToRotateLeftRight.localRotation, clampedQuaternion, Time.deltaTime * _rotationSpeed);

        // Rotation up-down
        clampedQuaternion = Quaternion.Euler(eulerRotation.x - _upDownAimOffset, 0, 0);
        _turretModelToRotateUpDown.localRotation = Quaternion.Lerp(_turretModelToRotateUpDown.localRotation, clampedQuaternion, Time.deltaTime * _rotationSpeed);

        return Physics.Raycast(_currentBulletSpawner.position, _currentBulletSpawner.forward, 100f, _whatIsEnemy);
    }

    protected override void HideMuzzleFlash()
    {
        _muzzleFlash.SetActive(false);
        _secondMuzzleFlash.SetActive(false);
    }
}
