using UnityEngine;
public class IdleState : IState
{
    private Player _player;
    public void Enter()
    {
        if (!_player)
        {
            _player = GameObject.FindObjectOfType<Player>();
        }
        //пробуем перезагрузить сцену, в случае если последний поинт
        GameMananger.Instance.RestartGame();
    
        _player.IdleAnim();
        _player.LookToNextPoint();
    }

    public void Execute()
    {
    }

    public void Exit()
    {

    }
}