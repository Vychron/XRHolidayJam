using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudioPlayer : MonoBehaviour
{

    [SerializeField] private AudioPlayer _player;

    [SerializeField] private float _minDelay, _maxDelay;
    private float _currentDelay, _targetDelay;

    void Start() {
        SetDelay(); 
    }

    void SetDelay() {
        _currentDelay = 0;
        _targetDelay = Random.Range(_minDelay, _maxDelay);
    }

    // Update is called once per frame
    void Update()
    {
        _currentDelay++;
        if (_currentDelay >= _targetDelay) {
            _player.PlayAudio();
            SetDelay();
        }
    }
}
