using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerController _playerController;

    // l'assets che avevo scaricato aveva una idle animazione particolare che ho pensato di usare se il player non si muove per più di 3 secondi
    private float inactiveTimeCounter = 0f;
    private Vector2 _lastMoveDirection;

    void Awake()
    {
        // passiamo i componenti alle variabili
        _animator = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        //facciamo partire di faccia il player
        _lastMoveDirection = Vector2.down;
        _animator.SetFloat("moveY", -1f);
        _animator.SetFloat("moveX", 0f);
    }

    void Update()
    {
        // Ecco che torna la Properties
        Vector2 direction = _playerController.Direction;

        // se non è 0 si sta muovendo
        bool isMoving = direction.sqrMagnitude > 0.01f;

        _animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            // Diciamo all'Animator la nostra ultima direzione di movimento
            _lastMoveDirection = direction;
            _animator.SetFloat("moveX", direction.x);
            _animator.SetFloat("moveY", direction.y);

            //dopo il movimento resetto il contatore del tempo inattivo 
            inactiveTimeCounter = 0f;

        }
        else
        {
            _animator.SetFloat("moveX", _lastMoveDirection.x);
            _animator.SetFloat("moveY", _lastMoveDirection.y);
            inactiveTimeCounter += Time.deltaTime;
        }

        _animator.SetFloat("inactiveTime", inactiveTimeCounter);

    }
}
