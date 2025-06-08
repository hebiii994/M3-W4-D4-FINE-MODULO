using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    //faccio lo stesso con Weapon per poter implementare diverse tipologie di armi
    [SerializeField] private float _fireRate = 1f; // rispetto l'ultima (esercitazione precedente) volta utilizzo _fireRate come colpi effettivi al secondo, invece che dover diminuire il valore per aumentare il _firerate
    [SerializeField] private float _range = 10f;

    //l'arma veniva raccolta ed instanziata ma in un punto random non nella mano del player, provo ad aggiungere questa e la corrispettiva properties
    [SerializeField] private Transform _grip;

    [SerializeField] protected LayerMask _enemyLayer;

    private float _nextFireTime = 0f;

    protected float Range => _range;
    public Transform Grip => _grip;

    protected virtual void Update()
    {
        if (Time.time >= _nextFireTime)
        {
            if (CanAttack())
            {
                _nextFireTime = Time.time + 1f / _fireRate;
                Attack();
            }
        }
    }
    //può arma X attaccare? per la pistola (Gun) daremo un range maggiore, probabilmente implementerò qualcosa di melee per provare 
    protected abstract bool CanAttack();

    //stessa idea, che tipo di attacco farà la mia arma X? 
    protected abstract void Attack();


}
