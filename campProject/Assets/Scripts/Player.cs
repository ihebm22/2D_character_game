using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _jumpSpeed = 11f;
    [SerializeField]
    private bool _isGrounded;
    [SerializeField]
    public int _lives = 4;
    public bool gameOver;
    private bool _gameWin;

    private bool _playerHit;

    private Rigidbody2D rb;
    Animator animator;
    private GameManager _gameManager;

    //[SerializeField]
    //private CameraFollow _cameraScript;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(3f,-1.7f);

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //_cameraScript = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector2 direction = new Vector2(horizontalInput, 0);
        
        rb.velocity = new Vector2(horizontalInput * _speed , rb.velocity.y);
        animator.SetFloat("xInput", Math.Abs(rb.velocity.x));
        animator.SetFloat("yInput", Math.Abs(rb.velocity.y));

        //float faceDirection = Mathf.Sign(horizontalInput);
        //transform.localScale = new Vector3(faceDirection, 1 ,1);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            rb.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            _isGrounded = false;
            animator.SetBool("isJumping", !_isGrounded);
        }
    }

    void FlipPlayer()
    {

    }


    private void OnCollisionEnter2D(Collision2D x)
    {
        if (x.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            animator.SetBool("isJumping", !_isGrounded);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        } else if (x.gameObject.CompareTag("Fire"))
        {
            playerIsHit(1);
            _playerHit = false;
        }
        if (x.gameObject.CompareTag("Spikes"))
        {
            playerIsHit(1);
        }
        if (x.gameObject.CompareTag("Wheel Trap"))
        {
            playerIsHit(2);
        }
        

    }

    void OnTriggerEnter2D(Collider2D x)
    {
        if (x.gameObject.CompareTag("Potions"))
        {
            _lives += 1;
            //animator.SetBool("isCollected", true);
            Destroy(x.gameObject);
        }
        if (x.gameObject.CompareTag("Finish Line"))
        {
            UnityEngine.Debug.Log("you won");
            _gameWin = true;
            animator.SetBool("isWin", _gameWin);
            _gameManager.GameWin();
        }
    }

    void playerIsHit(int damage)
    {
        _lives -= damage;
        _playerHit = true;

        if(_lives > 0)
        {
            animator.SetBool("isHit", _playerHit);
            _playerHit = false;
        }
        else
        {
            gameOver = true;
            _gameManager.GameOver();
        }

    }
}
