using UnityEngine;

public class MachineGunTurret : Turret
{
    [SerializeField] private int _maxAmmoAmount = 20;
    [SerializeField] private float _timeToReaload = 3f;

    private bool _isReloading = false;
    private int _currentAmmoAmount;

    private void Start()
    {
        _currentAmmoAmount = _maxAmmoAmount;
    }

    private void Update()
    {
        if (Aim() && Time.time >= _nextTimeToFire && !_isReloading)
        {
            _nextTimeToFire = Time.time + 1 / _fireRate;
            Shoot();
        }
    }

    protected override void Shoot()
    {
        base.Shoot();

        _currentAmmoAmount--;

        if(_currentAmmoAmount <= 0)
        {
            _isReloading = true;
            Invoke(nameof(Reload), _timeToReaload);
        }
    }

    private void Reload()
    {
        _currentAmmoAmount = _maxAmmoAmount;
        _isReloading = false;
    }
}
