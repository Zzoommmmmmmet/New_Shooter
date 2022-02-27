public class ChangeHealthCommand : IActionCommand<int> // класс изменения жизни
{
    private readonly ICharacter player; // добавляем для изменения жизней
    
    public ChangeHealthCommand(ICharacter player)
    {
        this.player = player;
    }

    public void Execute(int param) // в этом методе принимает
    {
        if (player.Health <= 0) return; // если жизни равны 0, то не работает
        player.Health -= param; // жизни меняем (урон - жизни)
    }
}