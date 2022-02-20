using EventBusSystem;

public interface IPlayerDamageSystemHandler : IGlobalSubscriber // интерфейс который вызывает нанесение урона
{
    void HandleDamage();
}