using UnityEngine;
using UnityEngine.SceneManagement;

public class IdleState : IState
{
    private Player _player;
    public void Enter()
    {
        if (!_player)
        {
            _player = GameObject.FindObjectOfType<Player>();
        }
        
        //проверяем сможем ли мы перезагрузить сцену, в случае если последний поинт
        if (GameMananger.Instance.RestartGame())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            return;
        }
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