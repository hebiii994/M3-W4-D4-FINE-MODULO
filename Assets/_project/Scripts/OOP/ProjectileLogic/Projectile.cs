using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    //spero di non fare una c*** ma non utilizzo le classi abstract da tempo, quindi provo a farlo per Bullet partendo da questa

    [SerializeField] private float _speed = 15f;
    [SerializeField] private float _damage = 1f;
    [SerializeField] private float _lifeTime = 3f;

    private Rigidbody2D _rb;

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction)
    {
        _rb.velocity = direction.normalized * _speed;
        //mi era già successo con le frecce dell'esercizio precedente, se lo sprite del proiettile è rivolto verso l'alto posso usare transform.up=direction per far calcolare a unity la rotazione
        transform.up = direction;
        Destroy(gameObject, _lifeTime);
    }

    public float GetDamage()
    {
        return _damage;
    }

    protected abstract void OnHit(Collider2D collider);

    private void OnTriggerEnter2D(Collider2D collider)
    {
        OnHit(collider);
    }
}
