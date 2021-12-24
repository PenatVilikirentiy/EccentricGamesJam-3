using System.Collections.Generic;
using UnityEngine;

public class TrainWagon : MonoBehaviour
{
    [SerializeField] private List<Turret> _turrets;

    public void Attack()
    {
        foreach(Turret turret in _turrets)
        {

        }
    }
}
