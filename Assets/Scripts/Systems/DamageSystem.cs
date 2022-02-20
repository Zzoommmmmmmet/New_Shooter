using EventBusSystem;
using UnityEngine;

public class DamageSystem : MonoBehaviour // наносим дамаг игроку тут
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // когда срабатывает урон по клавише 
        {
            EventBus.RaiseEvent<IPlayerDamageSystemHandler>(h => h.HandleDamage());
            // подписываемся РайзЕвент"ом через интерфейс "IPlayerDamageSystemHandler", все те, кто подписан на него
            // вызовут метод "HandleDamage".
            //
            // В самом интерфейсе закинут метод, который он вызывает
        }
    }
}
