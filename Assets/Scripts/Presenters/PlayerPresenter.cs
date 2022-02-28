using System.Collections;
using DG.Tweening;
using EventBusSystem;
using UnityEngine;

public class PlayerPresenter : IPlayerDamageSystemHandler, IInputSystemHandler, IAttackOnEnemyHandler // осуществляет все подписки в этом методе
{
    private readonly ICharacter _player;
    private readonly PlayerView _view;
    private readonly ChangeHealthCommand _changeHealthCommand;
    private readonly CheckPlayerHasDiedCommand _checkPlayerHasDiedCommand;
    private readonly ReloadGunCommand _reloadGunCommand;
    public PlayerPresenter(
        ICharacter player, 
        PlayerView view,
        ChangeHealthCommand changeHealthCommand, 
        CheckPlayerHasDiedCommand checkPlayerHasDiedCommand,
        ReloadGunCommand reloadGunCommand)
    {
        _player = player;
        _view = view;
        _changeHealthCommand = changeHealthCommand;
        _checkPlayerHasDiedCommand = checkPlayerHasDiedCommand;
        _reloadGunCommand = reloadGunCommand;
    }

    public void Initialize() // инициализируем подписку
    {
        EventBus.Subscribe(this); // подписались шиной тут
        _player.OnHealthEvent += h => _view.OnHealthChanged(h); // при срабатывании евента меняем во вьюхе здоровье игрока
        _player.OnStateEvent += h => _view.OnStateChanged(h);
    }

    public void HandleDamage() // метод который наносит урон игроку
    {
        _changeHealthCommand.Execute(10);
        _checkPlayerHasDiedCommand.Execute();
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
        _view.OnMove(1f, 0f);
    }

    public void HandleMoveLeft()
    {
        Debug.Log("Move left");
        _view.OnMove(-1f, 0f);
    }

    public void HandleAttackOnEnemy(EnemyView enemyView) // атака по противнику
    {        
        if(_player.IsReloading) return;
        var action = _reloadGunCommand.Execute();
        enemyView.gameObject.SetActive(false);
    }
}