using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{ 
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private Transform _target;
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag.Equals("Player"))
        {
            if(other.GetType() == typeof(BoxCollider))
                Debug.Log("Follow player");
            //_target = other.transform;
        }
    }
    
    private void Update()
    {
        if (_target != null)
        {
            //_navMeshAgent.SetDestination(_target.transform.position);
            // float currentSpeed = _navMeshAgent.velocity.magnitude;
            // _animator.SetFloat("Speed", currentSpeed);
        }
        
    }
}