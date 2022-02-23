using System.Threading.Tasks;

public class ReloadGunCommand : IActionCommandAsync
{
    private readonly ICharacter player;

    public ReloadGunCommand(ICharacter player)
    {
        this.player = player;
    }

    public async Task Execute()
    {
        player.IsReloading = true;
        await Task.Delay(20000);
        player.IsReloading = false;
    }
}
