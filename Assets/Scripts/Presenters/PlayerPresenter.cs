using EventBusSystem;
using UnityEngine;

public class PlayerPresenter : IPlayerDamageSystemHandler, IInputSystemHandler // осуществляет все подписки в этом методе
{
    private readonly ICharacter _player;
    private readonly PlayerView _view;
    
    public PlayerPresenter(ICharacter player, PlayerView view)
    {
        _player = player;
        _view = view;
    }

    public void Initialize() // инициализируем подписку
    {
        EventBus.Subscribe(this); // подписались шиной тут
        _player.OnHealthEvent += h => _view.OnHealthChanged(h); // при срабатывании евента меняем во вьехе здоровье игрока
    }
    
    // private void OnEnable()
    // {
    //     EventBus.Subscribe(this);
    // }
    //
    // private void OnDisable()
    // {
    //     EventBus.Unsubscribe(this);
    // }

    public void HandleDamage() // метод который наносит урон игроку
    {
        if (_player.Health <= 0) return; // усли у игрока меньше 0 хп, то ничего не делаем
        _player.Health -= 10;

        // if (_player.Health <= 0)
        //     _player.State = State.Death;
    }

    public void HandleMoveUp()
    {
        Debug.Log("Move up");
        _view.OnMove(0f, 0.1f);
    }

    public void HandleMoveDown()
    {
        Debug.Log("Move down");
        _view.OnMove(0f, -1f);
    }

    public void HandleMoveRight()
    {
        Debug.Log("Move right");
      //  _view.OnMove(1f, 0f);
      _view.OnTurn(1f);
    }

    public void HandleMoveLeft()
    {
        Debug.Log("Move left");
        //_view.OnMove(-1f, 0f);
        _view.OnTurn(-1f);
    }
}