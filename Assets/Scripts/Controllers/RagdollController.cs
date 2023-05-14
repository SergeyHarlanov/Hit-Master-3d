using System.Collections.Generic;
using UnityEngine;

public class RagdollController
{
    private Animator _animator;
    private CapsuleCollider _capsuleCollider;

    private GameObject _progressBarHp;
    private List<Rigidbody> _rigidbodiesBone = new List<Rigidbody>();

    public RagdollController(Transform transformEnemy, GameObject progressBarHp, CapsuleCollider capsuleCollider, Animator animator)
    {
        _capsuleCollider = capsuleCollider;
        _animator = animator;
        _progressBarHp = progressBarHp;
            
        _rigidbodiesBone = new List<Rigidbody>(transformEnemy.GetComponentsInChildren<Rigidbody>());
        _rigidbodiesBone.ForEach(x=>x.isKinematic = true);
    }
    public void ActiveRagdoll(Vector3 dir)
    {
        _rigidbodiesBone.ForEach(x =>
        {
            x.isKinematic = false;
            x.AddForce(dir);
        });
            
        _capsuleCollider.enabled = false;
        _animator.enabled =false;
        _progressBarHp.SetActive(false);
    }
}
