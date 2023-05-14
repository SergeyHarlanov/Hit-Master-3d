
    using UnityEngine;

    public class MoveState : IState
    {
        private Player _player;
        public void Enter()
        {
            if (!_player)
            {
                _player = GameObject.FindObjectOfType<Player>();
            }
            _player.RunAnim();
        }

        public void Execute()
        {
        }

        public void Exit()
        {
        }
    }
