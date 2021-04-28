using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCoins : MonoBehaviour
{
	[SerializeField] private int _countCoins;
	[SerializeField] private float _duration;
	[SerializeField] private Coin _coin;

	private Vector2 _currentForce;
	private WaitForSeconds _waitForDurationSeconds;
	private Coroutine _startInstantiateCoins;
	private int _countInstantiatedCoins;

	private void OnEnable()
	{
		_waitForDurationSeconds = new WaitForSeconds(_duration);
	}

	public void StartInstantiateCoins()
	{
		if (_startInstantiateCoins != null)
		{
			StopCoroutine(_startInstantiateCoins);
		}

		_startInstantiateCoins = StartCoroutine(PeriodicallyInstantiateCoins());
	}

	private IEnumerator PeriodicallyInstantiateCoins()
	{
		while (_countInstantiatedCoins <= _countCoins)
		{
			_currentForce.Set(Random.Range(-300f, 300f), 0);

			var _currentCoin = Instantiate(_coin, transform.localPosition, Quaternion.identity);

			_coin.SetRandomCoin();

			_currentCoin.GetComponent<Rigidbody2D>().AddForce(_currentForce);

			_countInstantiatedCoins++;

			yield return _waitForDurationSeconds;
		}
	}
}
