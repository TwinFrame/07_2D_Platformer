using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Robo))]
[RequireComponent(typeof(AudioSource))]

public class Robo : MonoBehaviour
{
	[SerializeField] private int _fullHealth;

	private int _health;
	private Vector3 _respawnPosition;
	private int _wallet;
	private Animator _animator;

	private void OnEnable()
	{
		_health = _fullHealth;

		_respawnPosition = transform.localPosition;

		_animator = GetComponent<Animator>();
	}

	public void AddCoin(int value)
	{
		_wallet += value;

		Debug.Log($"Кашель: {_wallet} (+{value})");
	}

	public void TakeDamage(int damage)
	{
		_health -= damage;

		if (_health <= 0)
		{
			_health = _fullHealth;

			transform.localPosition = _respawnPosition;

			BirthAnimation();

			Debug.Log("Вы проиграли.");

			return;
		}

		Debug.Log($"Здоровье: {_health} (-{damage})");
	}

	public void SetResapwnPosition()
	{
		_respawnPosition = transform.position;
	}

	public void BirthAnimation()
	{
		_animator.SetTrigger("Birth");
	}

	public Vector3 GetRespawnPosition()
	{
		return _respawnPosition;
	}
}
