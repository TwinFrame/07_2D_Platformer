using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class RoboMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _jumpForce;
    private Vector3 _leftDirection;
    private Vector3 _rightDirection;
    private float _currentSpeed;
    private bool _isMoving;
    private Coroutine _movingJob;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _rightDirection = transform.localScale;
        _leftDirection = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    public void Moving(bool isRightDirection)
    {
        if (_movingJob != null)
            StopCoroutine(_movingJob);

        _movingJob = StartCoroutine(MovingJob(isRightDirection));
    }

    public void Running()
    {
        _currentSpeed = _speed * 1.8f;
    }

    public void StopMovement()
    {
        _isMoving = false;
        _currentSpeed = _speed;

        if (_movingJob != null)
            StopCoroutine(_movingJob);
    }

    public void Jump()
    {
        _jumpForce = new Vector2(0, _jumpPower * _currentSpeed);
        _rigidbody2D.AddForce(_jumpForce);
    }

    private IEnumerator MovingJob(bool isRightDirection)
    {
        _isMoving = true;

        while (_isMoving)
		{
            if (isRightDirection)
			{
                transform.localScale = _rightDirection;

                transform.Translate(_currentSpeed * Time.deltaTime, 0, 0);
            }
			else
			{
                transform.localScale = _leftDirection;

                transform.Translate(-1 * _currentSpeed * Time.deltaTime, 0, 0);
            }
            
            yield return null;
        }
    }
}
