using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : Weapon
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRadius = 0.8f;
    [SerializeField] private float _attackDamage = 5f;
    [SerializeField] private AudioClip _swingSound;

    private AudioSource _audioSource;
    private Animator _shovelAnimator;
    

    protected override void Awake()
    {
        base.Awake();
        _audioSource = GetComponent<AudioSource>();
        _shovelAnimator = GetComponent<Animator>();
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

        //stessa logica di ricerca della gun
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius, _enemyLayer);

        
        foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("Pala ha colpito: " + enemy.name);
                LifeController enemyLife = enemy.GetComponent<LifeController>();
                if (enemyLife != null)
                {
                    enemyLife.TakeDamage(_attackDamage);
                }
            }
       
    }
}
