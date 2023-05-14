using UnityEngine;

public class InputController
{
    private Player _player;
    private AttackController _attackController;
    
    private bool wasStartTouch;

    public InputController(Player player, AttackController attackController)
    {
        _player = player;
        _attackController = attackController;
    }
    public void Touch()
    {
        //первый выстрел пробный, что бы деактивировать Tap to Play UI панель, она отключается косанием по экрану своим эвентом на сцене
        if (Input.GetMouseButtonDown(0) && !wasStartTouch)
        {
            wasStartTouch = true;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            
            if (Physics.Raycast(ray, out RaycastHit hit ))
            {
                _attackController.Shoot(hit.point); 
            }
        }
    }
   
}