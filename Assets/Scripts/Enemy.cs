using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator), typeof(CapsuleCollider))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Slider _progressBarHp;
    [SerializeField] private float _forceRagdoll;
    [SerializeField] private int hpStart;
    
    private RagdollController _ragdollController;

    private Animator _animator;
    private CapsuleCollider _capsuleCollider;
    private Player _player;
    
    private int _hpCurrent;
    
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _animator = GetComponent<Animator>();
        _capsuleCollider = GetComponent<CapsuleCollider>();

        _ragdollController = new RagdollController(transform, _progressBarHp.gameObject, _capsuleCollider, _animator);


        _hpCurrent = hpStart;
    }
    private void OnTriggerEnter(Collider other)
    {
        //проверяем что бы мы находились на одном и том же с player поинте и наносим себе урон
        if (other.CompareTag("Bullet") && GameMananger.Instance.GetIndexPoint() == transform.parent.GetSiblingIndex())
        {

            _hpCurrent -= _player.GetDamage();
            
            _progressBarHp.value = (float)_hpCurrent / (float)hpStart;
            
            
            if (_hpCurrent<=0)
            {
                _ragdollController.ActiveRagdoll((transform.position - _player.transform.position).normalized * _forceRagdoll);
                GameMananger.Instance.KillEnemy();

            }
        }
    }


}
