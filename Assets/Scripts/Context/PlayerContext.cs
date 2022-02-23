using EventBusSystem;
using UnityEngine;

public class PlayerContext : MonoBehaviour
{
    [SerializeField] private PlayerView _view; // кидаем сюда вьюху которую будем в дальнейшем изменять
    private Player _player; // инициализируем игрока
    private PlayerPresenter _presenter; // инициализируем ПлеерПрезентер

    private ChangeHealthCommand _changeHealthCommand;
    private CheckPlayerHasDiedCommand _checkPlayerHasDiedCommand;
    private void Start()
    {
        _player = new Player(100, 10); // создаем игрока с жизнями и дамагом
        
        BindCommands();

        _presenter = new PlayerPresenter(_player, _view, _changeHealthCommand, _checkPlayerHasDiedCommand); // создаем презентера с игроком и его визуалкой
        _presenter.Initialize(); // инициализируме
        
    }

    private void BindCommands()
    { 
        _changeHealthCommand = new ChangeHealthCommand(_player);
        _checkPlayerHasDiedCommand = new CheckPlayerHasDiedCommand(_player);
    }
}
