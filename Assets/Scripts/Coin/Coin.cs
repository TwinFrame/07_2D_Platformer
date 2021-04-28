using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(Coin))]
[RequireComponent(typeof(CircleCollider2D))]

public class Coin : MonoBehaviour
{
	[SerializeField] private coinFormat _coinFormat;
	[SerializeField] private float _speedDefaultRotation;
	[SerializeField] private AudioClip _collectedSound;

	private enum coinFormat
	{
		Blue = 1,
		Gold = 5
	}

	private int _nominalValue;
	private MeshRenderer _meshRenderer;
	private Coroutine _defaultRotationJob;

	private Material[] _sourceBlueCoin = new Material[4];
	private Material[] _sourceGoldCoin = new Material[4];

	private void Awake()
	{
		_sourceGoldCoin[0] = (Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/LightBlue.mat", typeof(Material));
		_sourceGoldCoin[1] = (Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/Orange.mat", typeof(Material));
		_sourceGoldCoin[2] = (Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/Blue.mat", typeof(Material));
		_sourceGoldCoin[3] = (Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/Yellow.mat", typeof(Material));

		_sourceBlueCoin[0] = (Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/Blue.mat", typeof(Material));
		_sourceBlueCoin[1] = (Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/Orange.mat", typeof(Material));
		_sourceBlueCoin[2] = (Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/Orange.mat", typeof(Material));
		_sourceBlueCoin[3] = (Material)AssetDatabase.LoadAssetAtPath("Assets/Materials/LightBlue.mat", typeof(Material));
	}

	private void OnEnable()
	{
		_meshRenderer = GetComponentInChildren<MeshRenderer>();

		_defaultRotationJob = StartCoroutine(DefaultRotation());
	}

	private void Start()
	{
		switch (_coinFormat)
		{
			case coinFormat.Blue:
			default:

				_nominalValue = coinFormat.Blue.GetHashCode();

				_meshRenderer.materials = _sourceBlueCoin;

				break;

			case coinFormat.Gold:

				_nominalValue = coinFormat.Gold.GetHashCode();

				_meshRenderer.materials = _sourceGoldCoin;

				break;
		}
	}

	public void SetRandomCoin()
	{
		if (Random.Range(0, 101) <= 30)
			_coinFormat = coinFormat.Blue;
		else
			_coinFormat = coinFormat.Gold;
	}

	public int GetCoinNominalValue()
	{
		return _nominalValue;
	}

	public AudioClip GetCollectedSound()
	{
		return _collectedSound;
	}

	private IEnumerator DefaultRotation()
	{
		while (true)
		{
			transform.Rotate(new Vector3(0, 1, 0), _speedDefaultRotation * Time.deltaTime);

			yield return null;
		}
	}
}
