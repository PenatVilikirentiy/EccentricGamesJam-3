using UnityEngine;

public class MachineGunTurret : Turret
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
