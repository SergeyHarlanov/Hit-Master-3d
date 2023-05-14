    using UnityEngine;

    public class GameMananger : MonoBehaviour
    {
        public static GameMananger Instance;
        
        [SerializeField] private WayPoint[] wayPoints;
        
        private StateMachine _stateMachine;
        private WayPointController _wayPointController;


        
        private void Awake()
        {
            Instance = this;
            _stateMachine = new StateMachine();
            _wayPointController = new WayPointController(FindObjectOfType<Player>(), wayPoints);
        }

        public void ChangeState(IState state)
        {
            _stateMachine.ChangeState(state);
        }

        public void KillEnemy()
        {
            _wayPointController.KillEnemy();
        }

        public int GetIndexPoint()
        {
           return _wayPointController.GetIndexPoint();
        }
        public Vector3 NextPointPos()
        {
          return _wayPointController.NextPointPos();
        }
        public void NextPoint()
        {
        
            _wayPointController.NextPoint();
        }

        public bool RestartGame()
        {
            return _wayPointController.RestartGame();
        }
    }