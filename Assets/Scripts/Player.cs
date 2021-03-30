using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpPower = 5;
    [SerializeField] private AudioClip _getCoinSound;
    
    private bool _isGrounded = false;
    private RaycastHit2D[] _hits = new RaycastHit2D[1];
    private float _minGroundedYvelocity = 0.1f;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * _speed, _rigidbody2D.velocity.y);

        RaycastHit2D[] hits = new RaycastHit2D[16];
        _isGrounded = (_rigidbody2D.Cast(Vector2.down, _hits, 1f) > 0) && Mathf.Abs(_rigidbody2D.velocity.y) < _minGroundedYvelocity;

        if (Input.GetKey(KeyCode.Space) && _isGrounded)
        {
            Vector2 velocity = new Vector2(0, _jumpPower);
            _rigidbody2D.velocity += velocity;
        }

        if ((_rigidbody2D.velocity.x > 0 && (_spriteRenderer.flipX == false)) || (_rigidbody2D.velocity.x < 0 && (_spriteRenderer.flipX == true)))
        {
            _spriteRenderer.flipX = !(_spriteRenderer.flipX);
        }

        _animator.SetBool("isWalk", (_rigidbody2D.velocity.x != 0));
    }

    public void AcceptCoin()
    {
        _audioSource.clip = _getCoinSound;
        _audioSource.Play();
    }
}
