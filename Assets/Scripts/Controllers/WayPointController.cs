using UnityEngine;

public class WayPointController
{
    private Player _player;
    private WayPoint[] _wayPoints;
    
    private int _indexPoint;
    private int _enemyToKill;

    private bool _restartGame;
    
    public WayPointController(Player player, WayPoint[] wayPoints)
    {
        _player = player;
        _wayPoints = wayPoints;
        
        _enemyToKill = _wayPoints[_indexPoint].enemyToKill;
    }
    public void NextPoint()
    {
        //даем переместиться на поинт даже если он последний
        _player.Move(_wayPoints[_indexPoint].point.position);
        
        //в случае если он действительно последний, то отмечаем это
        if (_wayPoints.Length - 1 <= _indexPoint)
        {
            _restartGame = true;
            return;
        }
        
        _indexPoint++;

        _enemyToKill = _wayPoints[_indexPoint].enemyToKill;
    }

    public Vector3 NextPointPos()
    {
        return _wayPoints[_indexPoint].point.position;
    }

    public void KillEnemy()
    {
        _enemyToKill--;
        if (_enemyToKill == 0) 
        {
         GameMananger.Instance.NextPoint();
        }
    }

    public int GetIndexPoint()
    {
        return _indexPoint;
    }

    public bool RestartGame()
    {
        return _restartGame;
    }
}
