using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReachDeathZone : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<Robo>(out Robo Robo))
		{
			Robo.transform.localPosition = Robo._respawnPosition;
			return;
		}

		Destroy(collision.gameObject);
	}
}
