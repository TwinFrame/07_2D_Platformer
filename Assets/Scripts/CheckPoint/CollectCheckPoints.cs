using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCheckPoints : MonoBehaviour
{
	private CheckPointFlag[] _checkPointFlags;

	private void Start()
	{
		_checkPointFlags = GetComponentsInChildren<CheckPointFlag>();

	}

	public void CollectedAllCheckPoints()
	{
		foreach (var flag in _checkPointFlags)
		{
			if (!flag._isReached)
			{
				return;
			}
		}

		Debug.Log("***\n    Finish");
	}
}
