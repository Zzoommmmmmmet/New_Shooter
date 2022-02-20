using System;

public interface ICharacter // создаем интерфейс который будет содержать данные и методы игрока 
{
    int Health { get; set; }
    int Dmg { get; set; }
    void DoIdle();
    void DoMove();

    event Action<int> OnHealthEvent; // создаем евент на который будет подписан игрок
}