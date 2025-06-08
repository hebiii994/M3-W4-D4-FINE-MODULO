using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // metto in inspector la variabile speed 
    [SerializeField] private float _speed = 5f;
    

    //componenti che mi servono
    private Rigidbody2D _rb;
    

    // variabili per il movimento
    private float _h;
    private float _v;

    // Properties per la lettura del Vector2 Direction
    public Vector2 Direction { get; private set; }

    //direzione del pg
    

    


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
    }


   
    void Update()
    {
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");

        // usiamo la properties da utilizzare (non so ancora per cosa) all'esterno
        Direction = new Vector2(_h, _v).normalized;

    }

    private void FixedUpdate()
    {
        Vector2 newPosition = _rb.position + Direction * _speed * Time.fixedDeltaTime;
        _rb.MovePosition(newPosition);
    }



}
