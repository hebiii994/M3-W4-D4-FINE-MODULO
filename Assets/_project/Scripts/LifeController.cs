using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{



    [SerializeField] private float _maxHealth = 30f;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private bool _isPlayer = false;

    //con la properties la leggiamo soltanto
    private float _currentHealth;
    public float CurrentHealth => _currentHealth;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        
        _currentHealth -= damageAmount;
        Debug.Log(gameObject.name + " ha subito " + damageAmount + " danni. Vita rimanente: " + _currentHealth);

        //aggiunto audio di hit
        if (_audioSource != null && _hitSound != null)
        {
            _audioSource.PlayOneShot(_hitSound);
        }


        if (_currentHealth <= 0)
        {
            
            _currentHealth = 0;

            Die();
        }
    }

    private void Die()
    {
        if (_isPlayer)
        {
            Debug.Log(gameObject.name + " è stato sconfitto.");  
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            // PlayClipAtPoint mi permette di continuare a sentire il suono anche distruggendo l'oggetto del nemico (dalla posizione di morte in pratica)
            if (_deathSound != null)
            {
                Debug.Log(gameObject.name + " è stato sconfitto.");
                AudioSource.PlayClipAtPoint(_deathSound, transform.position);
            }

            Destroy(gameObject);
        }
        
    }
}
