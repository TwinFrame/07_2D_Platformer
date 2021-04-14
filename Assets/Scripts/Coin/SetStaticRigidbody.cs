using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStaticRigidbody : MonoBehaviour
{
	private Rigidbody2D[] _rigidBodies;

	private void Awake()
	{
		_rigidBodies = GetComponentsInChildren<Rigidbody2D>();

		foreach (var rigidBody in _rigidBodies)
		{
			rigidBody.bodyType = RigidbodyType2D.Static;
		}
	}
}
