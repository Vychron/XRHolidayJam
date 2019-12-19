using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    [SerializeField] private AudioClip[] _clips;
    private AudioSource _source;

    void Start() {
        _source = Camera.main.GetComponent<AudioSource>();
    }

    public void PlayAudio() {
        if (_clips != null) {
            int i = Random.Range(0, _clips.Length);
            _source.clip = _clips[i];
            _source.Play();
        }
    }

}
