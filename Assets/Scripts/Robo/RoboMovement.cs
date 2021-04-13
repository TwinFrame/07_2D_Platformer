using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class RoboMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _timeBeforeRunning;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private Vector2 _jumpForce;
    private Vector3 _leftDirection;
    private Vector3 _rightDirection;
    private float _runningTime;
    private float _currentSpeed;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();


        _rightDirection = transform.localScale;
        _leftDirection = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void Update()
    {
        if (!Input.anyKey)
        {
            _runningTime = 0;
            _animator.SetBool("Run", false);
            _animator.SetBool("Walk", false);
        }

        _runningTime += Time.deltaTime;

        Debug.Log(_runningTime);

        if (_runningTime >= _timeBeforeRunning)
        {
            _animator.SetBool("Run", true);
        }

        if (_animator.GetBool("Run"))
        {
            _currentSpeed = _speed * 1.6f;
        }
        else
        {
            _currentSpeed = _speed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {

            _animator.SetBool("Walk", true);

            transform.localScale = _rightDirection;

            transform.Translate(_currentSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _animator.SetBool("Walk", true);

            transform.Translate(-1 * _currentSpeed * Time.deltaTime, 0, 0);

            transform.localScale = _leftDirection;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _animator.SetTrigger("Jump");

            _jumpForce = new Vector2(0, _jumpPower * _currentSpeed);
            _rigidbody2D.AddForce(_jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("Hit");
        }
    }
}
