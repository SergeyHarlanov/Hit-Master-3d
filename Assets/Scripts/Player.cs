using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof( Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _transformSpawnBullet;
    [SerializeField] private float _speedBullet;
    [SerializeField] private int _damage;
    
    private InputController _inputController;
    private AttackController _attackController;
    private MovementController _movementController;
    
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();


        _attackController = new AttackController( _transformSpawnBullet, FindObjectOfType<ObjectPool>(), _speedBullet);
        _inputController = new InputController(this, _attackController);
        _movementController = new MovementController(_navMeshAgent, this);

    }

    void Update()
    {
        _inputController.Touch();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            GameMananger.Instance.ChangeState(new IdleState());
        }
    }

    public void IdleAnim()
    {
        _animator.SetBool("Run", false);
    }
    public void RunAnim()
    {
        _animator.SetBool("Run", true);
    }

    public void LookToNextPoint()
    {
        _movementController.RotateToNextPoint();
    }
    public void Move(Vector3 NextPos)
    {
        _movementController.Move( NextPos);
    }

    public int GetDamage()
    {
        return _damage;
    }
}

