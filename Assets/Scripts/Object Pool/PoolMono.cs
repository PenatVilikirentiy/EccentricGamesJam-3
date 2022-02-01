using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    public T Prefab { get; }
    public bool AutoExpand { get; set; }
    public Transform Container { get; }

    private List<T> _pool;

    public PoolMono(T prefab, int count, Transform container = null)
    {
        Prefab = prefab;
        Container = container;
        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++)
            CreateObject();        
    }

    private T CreateObject(bool isActivebyDefault = false)
    {
        var createdObj = Object.Instantiate(Prefab, Container);
        createdObj.gameObject.SetActive(isActivebyDefault);
        _pool.Add(createdObj);
        return createdObj;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var mono in _pool)
        {
            if (!mono.gameObject.activeInHierarchy)
            {
                element = mono;                
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement(bool activate = true)
    {
        if (HasFreeElement(out var element))
        {
            element.gameObject.SetActive(activate);
            return element;
        }            

        if (AutoExpand)
            return CreateObject(activate);

        throw new System.Exception($"There is no free element in pool of type {typeof(T)}");
    }
}
