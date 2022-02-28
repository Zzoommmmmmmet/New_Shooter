using System;

public enum StateType // состояния игрока
{
    Idle,
    Move,
    Die
}

public interface ICharacter // создаем интерфейс который будет содержать данные и методы игрока 
{
    int Health { get; set; }
    int Dmg { get; set; }
    bool IsAttacking { get; set; } // переменная для атаки стрельба он/офф
    bool IsReloading { get; set; }
    StateType State { get; set; } // состояния игрока 
    void DoIdle();
    void DoMove();

    event Action<int> OnHealthEvent; // создаем евент на который будет подписан игрок
    event Action<StateType> OnStateEvent; // принятие состояний евент (содержит в себе состояния)
    event Action<bool> OnAttackEvent; // евент на атаку игрока
}