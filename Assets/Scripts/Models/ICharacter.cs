using System;

public enum StateType
{
    Idle,
    Move,
    Die
}

public interface ICharacter // создаем интерфейс который будет содержать данные и методы игрока 
{
    int Health { get; set; }
    int Dmg { get; set; }
    bool IsAttacking { get; set; }
    bool IsReloading { get; set; }
    StateType State { get; set; }
    void DoIdle();
    void DoMove();

    event Action<int> OnHealthEvent; // создаем евент на который будет подписан игрок
    event Action<StateType> OnStateEvent;
    event Action<bool> OnAttackEvent;
}