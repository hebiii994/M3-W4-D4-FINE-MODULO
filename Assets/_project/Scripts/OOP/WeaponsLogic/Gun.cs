using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{

    [SerializeField] private Projectile _bulletPrefab; 
    [SerializeField] private Transform _firePoint;
    [SerializeField] private AudioClip _shootSound;
    
    private Animator _animatorGun;
    private Transform _targetEnemy;
    private AudioSource _audioSource;

    protected override void Awake()
    {
        base.Awake();
        _audioSource = GetComponent<AudioSource>();
        _animatorGun = GetComponent<Animator>();
    }
    protected override bool CanAttack()
    {
        // Physics2D.OverlapCircleAll è perfetto in questo caso visto che ci da una lista di tutti i collider presenti in un area circolare
        // con _enemyLayer restringiamo la ricerca al solo Layer Enemy che assegnerò ai nemici
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, Range, _enemyLayer);

        //per qualche motivo la pistola non spara metto un debug temporaneo da cancellare
        if (enemiesInRange.Length > 0)                                                     // <-- TO DELETE
        {
            Debug.Log("Nemici nel raggio d'azione: " + enemiesInRange.Length);             // <-- TO DELETE
        }

        if (enemiesInRange.Length > 0)
        {

            _targetEnemy = enemiesInRange[0].transform;
            return true;
        }
        _targetEnemy = null;
        return false;
    }

    protected override void Attack()
    {
        if (_bulletPrefab == null && _firePoint == null && _targetEnemy == null)
        {
            Debug.Log("Controllare setup di Gun!");
            return;
        }
        // aggiunto audio di sparo
        if (_audioSource != null && _shootSound != null)
        {
            _audioSource.PlayOneShot(_shootSound);
        }

        if (_animatorGun != null)
        {
            _animatorGun.SetTrigger("Fire");
        }

        Vector2 directionToEnemy = (_targetEnemy.position - _firePoint.position).normalized;
        Projectile projectileInstance = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        projectileInstance.Shoot(directionToEnemy);
    }
    
}
