using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class PlayerView : MonoBehaviour // вся магия с анимацией
{
    [SerializeField] private Animator _animator; // закидываем сюда игрока который будет менять свою анимацию
    [SerializeField] private HealthBarView _healthBarView; // кидаем сюда хелсБар для его изменения
    [SerializeField] private SphereCollider sphereCollider;
    
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    // переименовываем Аниматор.СтрингТоХэш на инт позицию для комфорта

    private const float TimeToChange = 1f; // время изменения в ДОТВин

    [SerializeField] private float _rotateSpeed = 50f;
    public void OnHealthChanged(int health) // метод изменяем хелсБар
    {
        Debug.Log("Health: "+health);
        _healthBarView.UpdateHealthFiller(health); // Анимация для хелсБара изменения хп
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            if (other.GetType() == typeof(BoxCollider))
            {
                Debug.Log("Attack on "+other.name);
            }
        }
    }

    public void OnStateChanged(StateType state)
    {
        switch (state)
        {
            case StateType.Idle:
                break;
            case StateType.Move:
                break;
            case StateType.Die:
                _animator.SetTrigger("Dead");
                break;
        }
    }

    public void OnMove(float x, float z) // Анимация бега
    {
        Vector3 currentPosition = this.transform.position;
        Vector3 newPosition = new Vector3(currentPosition.x + x * -1f, currentPosition.y, currentPosition.z + z * -1f);
        this.transform.DOMove(newPosition, TimeToChange);
        
        
        _animator.SetBool(IsRunning, true);
    }

    // public void OnTurn(float rotate)
    // {
    //    this.transform.Rotate(Vector3.up, rotate*_rotateSpeed*Time.deltaTime);
    // }
}
