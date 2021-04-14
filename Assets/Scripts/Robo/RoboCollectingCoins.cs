using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RoboCollectingCoins : MonoBehaviour
{
	private Coroutine _destroyCoin;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
		{
			gameObject.GetComponent<Robo>().AddToWallet(coin.GetCoinNominalValue());

			GetComponent<AudioSource>().PlayOneShot(coin.GetCollectedSound());

			Destroy(collision.gameObject);
		}
	}
}
