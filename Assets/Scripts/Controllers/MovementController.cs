using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class MovementController
{
    private NavMeshAgent _navMeshAgent;
    private Player _player;

    public MovementController(NavMeshAgent navMeshAgent, Player player)
    {
        _navMeshAgent = navMeshAgent;
        _player = player;
    }
    public void Move( Vector3 nextPos)
    {
        _navMeshAgent.SetDestination(nextPos);
        GameMananger.Instance.ChangeState(new MoveState());
    }

    public void RotateToNextPoint()
    {
        Vector3 nextposClamp = GameMananger.Instance.NextPointPos();
        nextposClamp.y = _player.transform.position.y;
        
        _player.transform.DOLookAt(nextposClamp, 0.5f);
    }
}
