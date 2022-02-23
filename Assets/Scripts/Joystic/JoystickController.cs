using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class JoystickController : MonoBehaviour
{
 [SerializeField] private Rigidbody _rigidbody; // физическое поведение игрока (компонента)
 [SerializeField] private FixedJoystick _joystick; // сам джостик
 [SerializeField] private Animator _animator; // анимируем игрока

 [SerializeField] private float _moveSpeed; // устанавливаем скорость игрока


 private void Update()
 {
  _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed * -1f, _rigidbody.velocity.y,
   _joystick.Vertical * _moveSpeed * -1f); // задаем вектор скоррости игрока

  if (_joystick.Horizontal != 0 || _joystick.Vertical != 0) // повороты игрока
  {
   transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
   _animator.SetBool("IsRunning", true);
  }
  else
  {
   _animator.SetBool("IsRunning", false);
  }
 }
}
