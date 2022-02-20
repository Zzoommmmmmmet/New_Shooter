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

    public Player(int health, int dmg)
    {
        _health = health;
        _dmg = dmg;
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

    private int _health;
    private int _dmg;
}
