using EventBusSystem;

public interface IInputSystemHandler : IGlobalSubscriber // интрефейс Шины который вызывает нажатие клавищ
{
       void HandleMoveUp();
       void HandleMoveDown();
       void HandleMoveRight();
       void HandleMoveLeft();
}