using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private int _poolCount = 200;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private Bullet _bulletPrefab;

    public PoolMono<Bullet> _pool;

    private void Awake()
    {
        _pool = new PoolMono<Bullet>(_bulletPrefab, _poolCount, transform);
        _pool.AutoExpand = _autoExpand;
    }
}
