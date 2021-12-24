using System.Collections.Generic;
using UnityEngine;

public class TrainWagon : MonoBehaviour
{
    [SerializeField] private List<Turret> _turrets;

    public void Attack(TestEnemy enemy)
    {
        foreach(Turret turret in _turrets)
        {
            turret.CurrentTarget = enemy.transform;
        }
    }
}
