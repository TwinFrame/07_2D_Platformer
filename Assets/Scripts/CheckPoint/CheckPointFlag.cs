using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointFlag : MonoBehaviour
{
	private bool _isReached;

	public void SetIsReached()
	{
		_isReached = true;
	}

	public bool GetIsReached()
	{
		return _isReached;
	}
}
