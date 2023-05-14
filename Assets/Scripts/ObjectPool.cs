using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int size;

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Start()
    {
        for (int i = 0; i < size; i++)
        {
            var obj = Instantiate(prefab);
            obj.SetActive(false);
            obj.transform.parent = transform;
            
            obj.GetComponent<Bullet>().objectPool = this;
            
            pool.Enqueue(obj);
        }
    }

    public GameObject Get()
    {
        if (pool.Count == 0)
        {
            for (int i = 0; i < size; i++)
            {
                var obj = Instantiate(prefab);
                obj.SetActive(false);
                pool.Enqueue(obj);
            }
        }

        var newObj = pool.Dequeue();
        newObj.SetActive(true);
        return newObj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}