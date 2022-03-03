using System.Collections;
using EventBusSystem;
using UnityEngine;
using UnityEngine.AI;
using DG;
using DG.Tweening;

public class EnemyView : MonoBehaviour // класс за отображение противника
{
    [SerializeField] NavMeshAgent _navMeshAgent; // переменная отвечает за передвижение противника
    [SerializeField] Animator _animator; // анимация противника
    private Transform _target; // цель противника

    private bool _onPause = false; // пауза атаки противника
    private Transform _cachedTarget; // переменная для запоминания кто противник

    private void OnTriggerEnter(Collider other) // срабатывание на поиск противника (в нашем случае игрока)
    //////////
    {
        if (other.tag.Equals("Player")) //поиск коллайдера с тегом "Игрок"
        {
            if (other.GetType() == typeof(BoxCollider)) // проверка что на нем есть Бокс_Коллайдер
            {
                Debug.Log("Follow player"); // Лог в подвтерждение что нашёл противника
                _target = other.transform; // цель игрока становится трансформ (местоположение) игрока
            }
        }
    }

    private void Update()
    {
        if (_target != null) // проверка на цель противника
        {
            _navMeshAgent.SetDestination(_target.position); // если цель есть, то преследуем её
            if (Vector3.Distance(_target.position, this.transform.position) <= 2f && !_onPause)
                //проверка на расстояние между игроком и персонажем ( а = местоположение игрока (цели) , б - местоположение противника (зомби)
            {
                _cachedTarget = _target; // кэшируем цель зомби ( зомби => игрок)
                _target = null; // цель зомби обнуляется, чтобы зомби остановился
                _onPause = true; // пауза включена для того чтобы зомби бил с периодом
                EventBus.RaiseEvent<IPlayerDamageSystemHandler>(h => h.HandleDamage());
                // срабатывает 
                StartCoroutine(MakeDelay()); //вызываем корутинку сбрасывая атаку и преследование игрока
                                                    //(если выполняется условие)
                // float currentSpeed = _navMeshAgent.velocity.magnitude;
                // _animator.SetFloat("Speed", currentSpeed);
            }
        }

        IEnumerator MakeDelay() // корутина на перезарядку
        {
            yield return new WaitForSeconds(1f); // корутина на перезарядку
            _onPause = false;
            _target = _cachedTarget;
        }
    }
}