using EventBusSystem;

public interface IAttackOnEnemyHandler : IGlobalSubscriber
{
    void HandleAttackOnEnemy(EnemyView enemyView);
}
