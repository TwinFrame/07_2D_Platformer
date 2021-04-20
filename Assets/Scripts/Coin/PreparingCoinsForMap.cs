using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparingCoinsForMap : MonoBehaviour
{
	private Rigidbody2D[] _rigidBodies;
	private Collider2D[] _colliders;

	private void Awake()
	{
		_rigidBodies = GetComponentsInChildren<Rigidbody2D>();
		_colliders = GetComponentsInChildren<CircleCollider2D>();

		foreach (var rigidBody in _rigidBodies)
		{
			if (rigidBody.TryGetComponent<Rigidbody2D>(out Rigidbody2D rigidbody2D))
			{
				Destroy(rigidbody2D);
			}
		}

		foreach (var collider in _colliders)
		{
			collider.isTrigger = true;
		}
	}
}
