using UnityEngine;

public class ObjectsPoolsManager : MonoBehaviour
{
    public static ObjectsPoolsManager Instance { get; private set; }

    [SerializeField] private BulletsPool[] _bulletsPools;

    private void Awake()
    {
        Instance = this;
    }

    public BulletsPool GetPool(PoolType poolType)
    {
        foreach (var pool in _bulletsPools)
        {
            if(pool.PoolType == poolType)
            {
                return pool;
            }
        }

        return null;
    }
}
