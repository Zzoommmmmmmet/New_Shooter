using EventBusSystem;
using UnityEngine;

public class PlayerContext : MonoBehaviour
{
    [SerializeField] private PlayerView _view;                      // кидаем сюда вьюху которую будем в дальнейшем изменять
    private Player _player;                                         // инициализируем игрока
    private PlayerPresenter _presenter;                             // инициализируем ПлеерПрезентер

    private ChangeHealthCommand _changeHealthCommand;               // прокидываем интерфейс 
    private CheckPlayerHasDiedCommand _checkPlayerHasDiedCommand;   // прокидываем команду смерти
    private ReloadGunCommand _reloadGunCommand;                     //
    private void Start()
    {
        _player = new Player(100, 10);                    // создаем игрока с жизнями и дамагом
        
        BindCommands();

        _presenter = new PlayerPresenter
            (
                _player, 
                _view, 
                _changeHealthCommand, 
                _checkPlayerHasDiedCommand,
                _reloadGunCommand
            );                                                      // создаем презентера с игроком и его визуалкой
        
        _presenter.Initialize();                                    // инициализируме
    }

    private void BindCommands()                                     // метод для создания команд
    { 
        _changeHealthCommand = new ChangeHealthCommand(_player);
        _checkPlayerHasDiedCommand = new CheckPlayerHasDiedCommand(_player);
        _reloadGunCommand = new ReloadGunCommand(_player);
    }
}
