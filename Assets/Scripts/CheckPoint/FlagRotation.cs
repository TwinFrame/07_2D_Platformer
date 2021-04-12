using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlagRotation : MonoBehaviour
{
    [SerializeField] private float _angleFlagRotation;
    [SerializeField] private float _timeFlagRotation;

    private CheckPointFlag _checkPointFlag;
    private Sequence _flagRotationSequence;

    private void Start()
    {
        _checkPointFlag = GetComponentInChildren<CheckPointFlag>();
        _flagRotationSequence = DOTween.Sequence();
    }

    public void FlagLoopRotaion()
    {
        _flagRotationSequence.Append(_checkPointFlag.transform.DORotate(new Vector3(0, 0, _angleFlagRotation), _timeFlagRotation).SetLoops(-1, LoopType.Yoyo));
        //_flagRotationSequence.Insert(0, _checkPointFlag.transform.DORotate(new Vector3(0, 0, 360 - _angleFlagRotation), _timeFlagRotation));
        _flagRotationSequence.SetLoops(-1, LoopType.Yoyo);
    }
}
