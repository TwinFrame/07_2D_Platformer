using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private int _damage;

	public int GetDamage()
	{
		return _damage;
	}
}
