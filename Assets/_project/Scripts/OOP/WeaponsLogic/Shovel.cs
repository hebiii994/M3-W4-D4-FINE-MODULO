using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : Weapon
{
    [SerializeField] private Transform _attackPoint;
    //[SerializeField] private float _attackRadius = 0.8f;  <--- al momento non più utilizzata
    [SerializeField] private float _attackDamage = 5f;
    [SerializeField] private AudioClip _swingSound;

    private AudioSource _audioSource;
    private Animator _shovelAnimator;
    private Collider2D _hitboxCollider;
    private List<Collider2D> _hitEnemiesThisSwing;

    private bool _isAttacking = false;
    private float _attackTimer = 0f;
    private float _attackDuration = 0.2f;


    protected override void Awake()
    {
        base.Awake();
        _audioSource = GetComponent<AudioSource>();
        _shovelAnimator = GetComponent<Animator>();
        _hitboxCollider = GetComponent<PolygonCollider2D>();
        _hitboxCollider.enabled = false;
        _hitEnemiesThisSwing = new List<Collider2D>();

        
    }
    protected override void Update()
    {
        
        base.Update();

        
        if (_isAttacking)
        {
            _attackTimer -= Time.deltaTime;
            if (_attackTimer <= 0f)
            {
                
                _isAttacking = false;
                _hitboxCollider.enabled = false; 
            }
        }
    }
    protected override bool CanAttack()
    {
        //visto che ho usato le classi abstract aggiungo qualche altra arma per provare, questa con una logica di attacco manuale
        return Input.GetButtonDown("Fire1");
    }

    protected override void Attack()
    {


        // aggiungiamo il suono
        if (_swingSound != null)
        {
            _audioSource.PlayOneShot(_swingSound);
        }


        if (_shovelAnimator != null)
        {
            _shovelAnimator.SetTrigger("Swing");
        }

        if (_attackPoint == null)
        {
            Debug.LogError("Attack Point non assegnato!", this);
            return;
        }

        _hitEnemiesThisSwing.Clear();
        _isAttacking = true;
        _attackTimer = _attackDuration;
        _hitboxCollider.enabled = true;

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!_hitboxCollider.enabled) return;
        if (collider.CompareTag("Enemy") && !_hitEnemiesThisSwing.Contains(collider))
        {
            _hitEnemiesThisSwing.Add(collider);
            LifeController enemyLife = collider.GetComponent<LifeController>();
            if (enemyLife != null)
            {
                enemyLife.TakeDamage(_attackDamage);
            }
        }
    }
}
