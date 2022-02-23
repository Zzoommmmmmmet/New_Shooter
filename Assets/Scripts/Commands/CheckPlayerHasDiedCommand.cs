public class CheckPlayerHasDiedCommand : IActionCommand
{
    private readonly ICharacter _player;
    public CheckPlayerHasDiedCommand(ICharacter player)
    {
        _player = player;
    }

    public void Execute()
    {
        if (_player.State == StateType.Die) return;
        if (_player.Health <= 0)
            _player.State = StateType.Die;
    }
}