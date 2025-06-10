using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private LifeController _playerLifeController;
    [SerializeField] private Image[] _heartImages;


    private void Update()
    {
        if (_playerLifeController == null) return;

        float playerHealth = _playerLifeController.CurrentHealth;
        Debug.Log("UpdateHearts chiamato! Vita attuale del player: " + playerHealth);

        for (int i = 0; i < _heartImages.Length; i++)
        {
            _heartImages[i].enabled = (playerHealth > i * 10);
        }
    }
}
