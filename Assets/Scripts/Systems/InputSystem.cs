using EventBusSystem;
using UnityEngine;
public class InputSystem : MonoBehaviour // метод который отслеживает событие нажатий клавищ,
                                         // в случае его срабатываения, вызывает определенные методы 
{
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            EventBus.RaiseEvent<IInputSystemHandler>(h => h.HandleMoveUp()); // реализация через RaiseEvent
        }
            
        if (Input.GetKey(KeyCode.S))
        {
            EventBus.RaiseEvent<IInputSystemHandler>(h => h.HandleMoveDown());
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            EventBus.RaiseEvent<IInputSystemHandler>(h => h.HandleMoveLeft());
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            EventBus.RaiseEvent<IInputSystemHandler>(h => h.HandleMoveRight());
        }
    }
}