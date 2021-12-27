using System.Collections.Generic;
using UnityEngine;

public class TrainWagon : MonoBehaviour
{
    public Vector2Int _gridSize = new Vector2Int(2, 2);

    public List<Turret> Turrets;

    [SerializeField] private Transform _gridStartPoint;

    private Turret[,] _grid;

    private void Awake()
    {
        _grid = new Turret[_gridSize.x, _gridSize.y];
    }

    public void Attack(TestEnemy enemy)
    {
        foreach(Turret turret in Turrets)
        {
            turret.CurrentTarget = enemy.transform;
        }
    }

    private void OnDrawGizmos()
    {
        if (_gridStartPoint)
        {
            for (int x = 0; x < _gridSize.x; x++)
            {
                for (int y = 0; y < _gridSize.y; y++)
                {
                    Gizmos.DrawCube(_gridStartPoint.position + new Vector3(x, 0, y), new Vector3(1, 0.1f, 1));
                }
            }
        }
    }
}
