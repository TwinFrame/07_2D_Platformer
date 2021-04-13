using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraToObject : MonoBehaviour
{
	[SerializeField] GameObject _trackingObject;

	private Vector3 _startPosition;

	private void Start()
	{
		_startPosition = transform.position;
	}

	private void FixedUpdate()
	{
		Vector3 currentPosition = _startPosition + _trackingObject.transform.position;

		transform.SetPositionAndRotation(currentPosition, Quaternion.identity);
	}
}
