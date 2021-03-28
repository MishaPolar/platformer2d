using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed = 5;
    [SerializeField] float _patrulingTime = 1;

    private bool _directionIsRight = true;
    private float _timeSum = 0;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_directionIsRight)
            transform.position += _speed * Time.deltaTime * new Vector3(1,0,0);
        else
            transform.position += _speed * Time.deltaTime * new Vector3(1, 0, 0) * -1;

        _timeSum += Time.deltaTime;
        if (_timeSum >= _patrulingTime)
        {
            _timeSum = (_timeSum - _patrulingTime) * -1;
            _directionIsRight = !(_directionIsRight);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            _audioSource.Play();
            Destroy(collision.gameObject);
        }
    }

}
