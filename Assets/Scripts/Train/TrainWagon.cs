using System.Collections.Generic;
using UnityEngine;

public class TrainWagon : MonoBehaviour
{
    [SerializeField] private List<Turret> _turrets;

    public void Attack(EnemyHealth enemy)
    {
        foreach (Turret turret in _turrets)
        {
            turret.CurrentTarget = enemy.transform;
        }
    }

    public void AddTurret(Turret turret)
    {
        if (turret == null) return;

        _turrets.Add(turret);
        // Play Sound
    }

    public void RemoveTurret(Turret turret)
    {
        _turrets.Remove(turret);
    }
}
