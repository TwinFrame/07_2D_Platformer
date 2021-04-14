using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Coin))]
[RequireComponent(typeof(Rigidbody2D))]

public class Coin : MonoBehaviour
{
	[SerializeField] private int _nominalValue;
	[SerializeField] private float _speedDefaultRotation;
	[SerializeField] private AudioClip _collectedSound;

	private Coroutine _defaultRotation;

	private void OnEnable()
	{
		_defaultRotation = StartCoroutine(DefaultRotation());
	}

	public int GetCoinNominalValue()
	{
		return _nominalValue;
	}

	public AudioClip GetCollectedSound()
	{
		return _collectedSound;
	}

	private IEnumerator DefaultRotation()
	{
		while (true)
		{
			transform.Rotate(new Vector3(0, 1, 0), _speedDefaultRotation * Time.deltaTime);

			yield return null;
		}
	}
}
