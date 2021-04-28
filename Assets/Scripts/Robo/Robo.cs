using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Robo))]
[RequireComponent(typeof(AudioSource))]

public class Robo : MonoBehaviour
{
	[SerializeField] private int _inputHealth;

	private int _health;
	public Vector3 _respawnPosition { get; set; }
	public int _wallet { get; set; }

	private void OnEnable()
	{
		_health = _inputHealth;

		_respawnPosition = transform.localPosition;
	}

	public void AddToWallet(int value)
	{
		_wallet += value;

		Debug.Log($"Кашель: {_wallet} (+{value})");
	}

	public void TakeDamage(int damage)
	{
		_health -= damage;

		if (_health <= 0)
		{
			_health = _inputHealth;

			transform.localPosition = _respawnPosition;

			GetComponent<Animator>().SetTrigger("Birth");

			Debug.Log("Вы проиграли.");

			return;
		}

		Debug.Log($"Здоровье: {_health} (-{damage})");
	}

	public void SetResapwnPosition()
	{
		_respawnPosition = transform.position;
	}
}
