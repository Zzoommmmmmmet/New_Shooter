using System.Collections;
using System.Collections.Generic;
using EventBusSystem;
using UnityEngine;

public class AttackOnEnemySystem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            if (other.GetType() == typeof(BoxCollider))
            {
                Debug.Log("Attack on " + other.name);
                var enemyView = other.gameObject.GetComponent<EnemyView>();
                EventBus.RaiseEvent<IAttackOnEnemyHandler>(h => h.HandleAttackOnEnemy(enemyView));
            }
        }
    }
}
