using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]

public class ReachDeathZone : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<Robo>(out Robo Robo))
		{
			Robo.transform.localPosition = Robo._respawnPosition;

			Robo.GetComponent<Animator>().SetTrigger("Birth"); 

			return;
		}

		Destroy(collision.gameObject);
	}
}
