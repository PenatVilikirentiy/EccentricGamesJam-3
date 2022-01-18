using UnityEngine;

public class HeavyGunTurret : Turret
{
    private void Update()
    {
        if (Aim() && Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1 / _fireRate;
            Shoot();
        }
    }
}
