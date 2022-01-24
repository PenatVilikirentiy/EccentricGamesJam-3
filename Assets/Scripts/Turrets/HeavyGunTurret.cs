using UnityEngine;

public class HeavyGunTurret : Turret
{
    [SerializeField] private Animator _animator;

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
        base.Shoot();
        _animator.SetTrigger("Shot");
    }
}
