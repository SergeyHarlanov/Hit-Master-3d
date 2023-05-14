using UnityEngine;

public class AttackController
{
    private ObjectPool _objectPool;
    
    private Transform _posSpawnBullet;
    private float _speedBullet;
    
    public AttackController( Transform posSpawnBullet, ObjectPool objectPool, float speedBullet)
    {
        
        _speedBullet = speedBullet;
        _objectPool = objectPool;
        _posSpawnBullet = posSpawnBullet;
    }
    public void Shoot(Vector3 lastPos)
    {
        GameObject bullet = _objectPool.Get();

        bullet.name += Random.Range(0, 9999);
        bullet.transform.position = _posSpawnBullet.position;

        Vector3 dir = (lastPos - bullet.transform.position).normalized * _speedBullet;
        Debug.DrawRay(bullet.transform.position, dir, Color.black, 1f);
        bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bullet.GetComponent<Rigidbody>().AddForce(dir);
    }
}