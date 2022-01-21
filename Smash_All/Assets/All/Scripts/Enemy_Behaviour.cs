using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Behaviour : MonoBehaviour
{

    [SerializeField] private float speed;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private Transform player;
    private bool attack;
    private bool chase;
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (_navMeshAgent == true)
        {
            _animator.SetBool("chase", true);
        }
        _navMeshAgent.SetDestination(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("attack", true);
        }
    }

    
    
    
    
    
    
    
    
}
