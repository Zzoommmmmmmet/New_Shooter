using EventBusSystem;
using UnityEngine;

public class PlayerContext : MonoBehaviour
{
    [SerializeField] private PlayerView _view; // кидаем сюда вьюху которую будем в дальнейшем изменять
    private Player _player; // инициализируем игрока
    private PlayerPresenter _presenter; // инициализируем ПлеерПрезентер
    private void Start()
    {
        _player = new Player(100, 10); // создаем игрока с жизнями и дамагом
        _presenter = new PlayerPresenter(_player, _view); // создаем презентера с игроком и его визуалкой
        _presenter.Initialize(); // инициализируме
    }
}
