using System.Collections;
using System.Collections.Generic;
using EventBusSystem;
using UnityEngine;

public class AttackOnEnemySystem : MonoBehaviour // атака противника
{
    private void OnTriggerEnter(Collider other) // ищем противника по коллайдеру
    {
        if (other.tag.Equals("Enemy")) // если тег = Енеми, то это наш противник
        {
            if (other.GetType() == typeof(BoxCollider)) // есди тег эними и он БоксКоллайдер, то точно наш противник
            {
                Debug.Log("Attack on " + other.name); // пишем кого атакуем
                var enemyView = other.gameObject.GetComponent<EnemyView>(); // достаем из объекта вьюшку
                EventBus.RaiseEvent<IAttackOnEnemyHandler>(h => h.HandleAttackOnEnemy(enemyView));
                // вызываем метод который
                // подписан на интерфейс "IAttackOnEnemyHandler" 
            }
        }
    }
}