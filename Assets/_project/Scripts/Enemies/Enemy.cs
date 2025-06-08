using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _stoppingDistance = 1f;

    private Rigidbody2D _rb;
    private Transform _playerTarget;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Acerchiamo il GameObject del giocatore tramite il suo Tag
        
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            _playerTarget = playerObject.transform;
        }
        else
        {
            
            Debug.LogError("Player non trovato!");
            enabled = false;
        }
    }

    void FixedUpdate()
    {
        
        if (_playerTarget == null) return;

        
        float distanceToPlayer = Vector2.Distance(transform.position, _playerTarget.position);

        
        if (distanceToPlayer > _stoppingDistance)
        {

            Vector2 direction = (_playerTarget.position - transform.position).normalized;


            _rb.velocity = direction * _speed;
        }
        else
        {

            _rb.velocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Destroy(gameObject);

           
        }
    }
}
