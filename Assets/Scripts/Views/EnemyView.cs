using System.Collections;
using EventBusSystem;
using UnityEngine;
using UnityEngine.AI;
using DG;
using DG.Tweening;

public class EnemyView : MonoBehaviour
{
    [SerializeField] NavMeshAgent _navMeshAgent;
    [SerializeField] Animator _animator;
    private Transform _target;

    private bool _onPause = false;
    private Transform _cachedTarget;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (other.GetType() == typeof(BoxCollider))
            {
                Debug.Log("Follow player");
                _target = other.transform;
            }
        }
    }

    private void Update()
    {
        if (_target != null)
        {
            _navMeshAgent.SetDestination(_target.position);
            if (Vector3.Distance(_target.position, this.transform.position) <= 2f && !_onPause)
            {
                _cachedTarget = _target;
                _target = null;
                _onPause = true;
                EventBus.RaiseEvent<IPlayerDamageSystemHandler>(h => h.HandleDamage());
                StartCoroutine(MakeDelay());
            }
            // float currentSpeed = _navMeshAgent.velocity.magnitude;
            // _animator.SetFloat("Speed", currentSpeed);
        }
    }

    IEnumerator MakeDelay()
    {
        yield return new WaitForSeconds(1f);
        _onPause = false;
        _target = _cachedTarget;
    }
}