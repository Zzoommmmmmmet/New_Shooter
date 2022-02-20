using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class PlayerView : MonoBehaviour // вся магия с анимацией
{
    [SerializeField] private Animator _animator; // закидываем сюда игрока который будет менять свою анимацию
    [SerializeField] private HealthBarView _healthBarView; // кидаем сюда хелсБар для его изменения
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    // переименовываем Аниматор.СтрингТоХэш на инт позицию для комфорта

    private const float TimeToChange = 1f; // время изменения в ДОТВин
    public void OnHealthChanged(int health) // метод изменяем хелсБар
    {
        Debug.Log("Health: "+health);
        _healthBarView.UpdateHealthFiller(health); // Анимация для хелсБара изменения хп

        if (health <= 0)
            _animator.SetTrigger("Dead"); // если 0 - то умирает
    }
    
    public void OnMove(float x, float z) // Анимация бега
    {
        Vector3 currentPosition = this.transform.position;
        Vector3 newPosition = new Vector3(currentPosition.x + x * -1f, currentPosition.y, currentPosition.z + z * -1f);
        this.transform.DOMove(newPosition, TimeToChange);
        
        this.transform.DORotate(Vector3.up, 1f);
        _animator.SetBool(IsRunning, true);
    }
}
