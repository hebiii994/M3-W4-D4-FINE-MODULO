using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    //vediamo di flippare anche l'arma con l'animazione del player
    private Animator _playerAnimator;
    private Vector2 _initialLocalScale;
    private void Awake()
    {
        _playerAnimator = GetComponentInParent<Animator>();
        _initialLocalScale = transform.localScale;
    }
  
    void Update()
    {
        if (_playerAnimator == null) return;

        float moveX = _playerAnimator.GetFloat("moveX");

        //tutto normale verso destra
        if (moveX > 0.1f)
        {
            transform.localScale = _initialLocalScale;
        }
        else if (moveX < 0.1f) //flippiamo se guardo a sinistra
        {
            transform.localScale = new Vector2(-_initialLocalScale.x, _initialLocalScale.y);
        }

    }
}
