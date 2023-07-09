using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Controller : MonoBehaviour
{
    public float _speed = 1f;
    public float _jumpforce = 1f;
    private Rigidbody2D _rb;
    private bool _isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        jump();
    }

    void FixedUpdate()
    {


        if(Mathf.Abs(_rb.velocity.x) < _speed)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                _rb.AddForce(Vector2.right * 50f);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                _rb.AddForce(- Vector2.right * 50f);
            }
        }
        
    }

    void jump()
    {
        // Ground check code (This might be different based on your project)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider != null)
        { 
            _isGrounded = hit.distance < 0.01f;
        }
            
        // Jump code
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * _jumpforce, ForceMode2D.Impulse);
        }

    }
}