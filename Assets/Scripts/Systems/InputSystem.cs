using EventBusSystem;
using UnityEngine;
public class InputSystem : MonoBehaviour // метод который отслеживает событие нажатий клавищ,
                                         // в случае его срабатываения, вызывает определенные методы 
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            EventBus.RaiseEvent<IInputSystemHandler>(h => h.HandleMoveUp()); // реализация через RaiseEvent
        }
            
        if (Input.GetKeyDown(KeyCode.S))
        {
            EventBus.RaiseEvent<IInputSystemHandler>(h => h.HandleMoveDown());
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            EventBus.RaiseEvent<IInputSystemHandler>(h => h.HandleMoveLeft());
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            EventBus.RaiseEvent<IInputSystemHandler>(h => h.HandleMoveRight());
        }
    }
}