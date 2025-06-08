using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>(); 
    }
    void Update()
    {
        
        Vector2 velocity = _rb.velocity;
        bool isMoving = velocity.sqrMagnitude > 0.1f;
        _animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            _animator.SetFloat("moveX", velocity.x);
            _animator.SetFloat("moveY", velocity.y);
        }

        

        // h va a destra?
        if (velocity.x > 0.01f)
        {
            // Se si non devo flippare
            _spriteRenderer.flipX = false;
        }
        else if (velocity.x < -0.01f)
        {
            // Se si muove a sinistra flippiamo
            _spriteRenderer.flipX = true;
        }
        
    }
}
