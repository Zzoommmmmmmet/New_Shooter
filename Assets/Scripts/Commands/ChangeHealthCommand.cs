public class ChangeHealthCommand : IActionCommand<int>
{
    private readonly ICharacter player;
    
    public ChangeHealthCommand(ICharacter player)
    {
        this.player = player;
    }

    public void Execute(int param)
    {
        if (player.Health <= 0) return;
        player.Health -= param;
    }
}