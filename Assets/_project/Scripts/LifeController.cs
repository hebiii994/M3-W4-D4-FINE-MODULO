using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 30f;

    //con la properties la leggiamo soltanto
    private float _currentHealth;
    public float CurrentHealth => _currentHealth;


   
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        
        _currentHealth -= damageAmount;
        Debug.Log(gameObject.name + " ha subito " + damageAmount + " danni. Vita rimanente: " + _currentHealth);

        
        if (_currentHealth <= 0)
        {
            
            _currentHealth = 0;

            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " è stato sconfitto.");

        // TODO: suoni o effetti speciali, vediamo se ci arrivo

        Destroy(gameObject);
    }
}
