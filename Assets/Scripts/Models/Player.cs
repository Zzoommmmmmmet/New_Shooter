using System;

public class Player : ICharacter
{
    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            OnHealthEvent?.Invoke(value); // реактивно изменяем жизни игрока, при изменении значения вызываем евент
        }
    }

    public int Dmg
    {
        get => _dmg; 
        set => _dmg = value;
    }

    public bool IsAttacking
    {
        get => _isAttacking;
        set
        {
            _isAttacking = value;
            OnAttackEvent?.Invoke(value);
        }
    }

    public bool IsReloading
    {
        get => _isReloading; 
        set => _isReloading = value;
    }

    public StateType State
    {
        get => _state;
        set
        {
            _state = value;
            OnStateEvent?.Invoke(value);
        }
    }

    public Player(int health, int dmg) // конструктор
    {
        _health = health;
        _dmg = dmg;
        _state = StateType.Idle;
        _isReloading = false; 
    }

    public void DoIdle()
    {
        throw new System.NotImplementedException();
    }

    public void DoMove()
    {
        throw new System.NotImplementedException();
    }

    public event Action<int> OnHealthEvent; // создали евент, который подписан на изменение жизней
    public event Action<StateType> OnStateEvent;
    public event Action<bool> OnAttackEvent;

    private int _health; // хп игрока
    private int _dmg;   // дамаг игрока
    private StateType _state;
    private bool _isAttacking;
    private bool _isReloading;
}
