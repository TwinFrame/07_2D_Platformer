using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Robo))]
[RequireComponent(typeof(AudioSource))]

public class Robo : MonoBehaviour
{
	[SerializeField] private int _health;

	public Vector3 _respawnPosition { get; set; }

	public int _wallet { get; set; }

	private void OnEnable ()
	{
		_respawnPosition = transform.localPosition;
	}

	public void AddToWallet(int value)
	{
		_wallet += value;

		Debug.Log("Кашель: " + _wallet + " +" + value);
	}

	public void TakeDamage(int damage)
	{
		_health -= damage;

		if (_health <=0)
		{
			Debug.Log("Вы проиграли.");
		}

		Debug.Log("Здоровье: " + _health + " -" + damage);
	}

	public void SetResapwnPosition()
	{
		_respawnPosition = transform.position;
	}
}
