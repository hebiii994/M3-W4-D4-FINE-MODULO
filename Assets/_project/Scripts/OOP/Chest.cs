using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Pickup _pickupToSpawn;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private AudioClip _openSound;

    private Animator _animator;
    private AudioSource _audioSource;
    private bool _isAlreadyOpened = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>(); 
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (_isAlreadyOpened)
        {
            return;
        }

        if (collider.CompareTag("Player"))
        {
            OpenChest();
        }
    }

    private void OpenChest()
    {
        _isAlreadyOpened = true;
        _animator.SetBool("isOpened", true);

        if (_audioSource != null && _openSound != null)
        {
            _audioSource.PlayOneShot(_openSound);
        }

        if (_pickupToSpawn != null && _spawnPoint != null)
        {
            Instantiate(_pickupToSpawn, _spawnPoint.position, _spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("La cassa non ha un pickup o uno spawn point assegnato!", this);
        }
    
    }
}
