public class CheckPlayerHasDiedCommand : IActionCommand // отыгровка состояний игрока (более точно тут) это смерть
{
    private readonly ICharacter _player; // данные игрока
    public CheckPlayerHasDiedCommand(ICharacter player) // конструктором прокидываем хп игрока
    {
        _player = player;
    }

    public void Execute() // проверка хп игрока на смерть
    {
        if (_player.State == StateType.Die) return; // если уже смерть наступила - тогда ничего не делаем
        if (_player.Health <= 0) // проверка хп на 0
            _player.State = StateType.Die; // если хп = 0
    }
}