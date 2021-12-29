//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ObjectPool : MonoBehaviour
//{
//public static ObjectPool SharedInstance;
//public List<Bullet> pooledObjects;
//public Bullet bulletToPool;
//public int amountToPool;

//void Awake()
//{
//    SharedInstance = this;
//}

//void Start()
//{
//    pooledObjects = new List<Bullet>();
//    Bullet tmpBullet;
//    for(int i = 0; i < amountToPool; i++)
//    {
//        tmpBullet = Instantiate(bulletToPool);
//        tmpBullet.gameObject.SetActive(false);
//        pooledObjects.Add(tmpBullet);
//    }
//}
//public Bullet GetPooledObject()
//{
//    for(int i = 0; i < amountToPool; i++)
//    {
//        if(!pooledObjects[i].gameObject.activeInHierarchy)
//        {
//            return pooledObjects[i];
//        }
//    }
//    return null;
//}
//}
