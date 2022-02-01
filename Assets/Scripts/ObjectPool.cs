//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ObjectPool : MonoBehaviour
//{
//    private static ObjectPool _instance;

//    public List<Pool> Pools;
//    public Dictionary<string, Queue<Bullet>> BulletsPool;
//    public Bullet bulletToPool;
//    public int amountToPool;

//    public static ObjectPool Instance
//    {
//        get
//        {
//            if (_instance == null)
//                _instance = new ObjectPool();

//            return _instance;
//        }
//    }

//    void Start()
//    {
//        BulletsPool = new Dictionary<string, Queue<Bullet>>();

//        Bullet tmpBullet;

//        for (int i = 0; i < amountToPool; i++)
//        {
//            tmpBullet = Instantiate(bulletToPool);
//            tmpBullet.gameObject.SetActive(false);
//            pooledObjects.Add(tmpBullet);
//        }
//    }
//    public Bullet GetPooledObject()
//    {
//        for (int i = 0; i < amountToPool; i++)
//        {
//            if (!pooledObjects[i].gameObject.activeInHierarchy)
//            {
//                return pooledObjects[i];
//            }
//        }
//        return null;
//    }
//}
