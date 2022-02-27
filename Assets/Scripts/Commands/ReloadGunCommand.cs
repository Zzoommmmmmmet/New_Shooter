using System.Threading.Tasks;

public class ReloadGunCommand : IActionCommandAsync // команда для перезарядки стрельбы
{
    private readonly ICharacter player; // прокидываем пользовательский бул (тру/фолс)

    public ReloadGunCommand(ICharacter player)
    {
        this.player = player;
    }

    public async Task Execute() // через таск делаем перезарядку в 20 000 мсек
    {
        player.IsReloading = true; // выставляем значение тру
        await Task.Delay(20000); // ждем 20 сек
        player.IsReloading = false; // фолс - перезарядка
    }
}
