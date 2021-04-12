using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointFlag : MonoBehaviour
{
	public bool _isReached { get; set; }

	public void SetReached()
	{
		_isReached = true;
	}
}
