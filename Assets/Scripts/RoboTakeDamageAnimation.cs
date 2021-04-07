using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboTakeDamageAnimation : MonoBehaviour
{
    [SerializeField] private float _durationDamage;

    private float _currentTime;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Flashingopacity()
    {
        if (_currentTime < _durationDamage)
        {
            _currentTime++;

            float normalizeCurrentTime = _currentTime / _durationDamage;

            
        }
        yield return null;
    }
}
