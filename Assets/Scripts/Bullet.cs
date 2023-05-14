using System.Collections;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    [SerializeField] private float _secondToDestroy = 3;
    [HideInInspector] public ObjectPool objectPool;

    private void OnEnable()
    {
        StartCoroutine(DisabledBullet());;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            StopAllCoroutines();
            objectPool.ReturnToPool(gameObject);
           
        }
    }

    private IEnumerator DisabledBullet()
    {
        yield return new WaitForSeconds(_secondToDestroy);
        objectPool.ReturnToPool(gameObject);
    }
}