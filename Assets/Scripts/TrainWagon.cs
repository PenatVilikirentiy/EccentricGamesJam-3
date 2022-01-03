using System.Collections.Generic;
using UnityEngine;

public class TrainWagon : MonoBehaviour
{
    //public Vector2Int _gridSize = new Vector2Int(2, 2);
    [SerializeField] private List<Turret> _turrets;
    [SerializeField] public Transform _gridStartPoint;

    public Turret[,] _grid;

    private void Awake()
    {
        //_grid = new Turret[_gridSize.x, _gridSize.y];
    }

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

    //private void OnDrawGizmos()
    //{
    //    if (_gridStartPoint)
    //    {
    //        for (int x = 0; x < _gridSize.x; x++)
    //        {
    //            for (int y = 0; y < _gridSize.y; y++)
    //            {
    //                Gizmos.DrawCube(_gridStartPoint.position + new Vector3(x, 0, y), new Vector3(1, 0.1f, 1));
    //            }
    //        }
    //    }
    //}
}
