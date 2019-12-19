using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {

    [SerializeField] private AudioPlayer _player;
    [SerializeField] private GameObject _particle;
    private void Awake() {
        GameManager.EnemyCount++;
    }

    public override void Die() {
        base.Die();
        _player.PlayAudio();
        GameManager.EnemyCount--;
        if (GameManager.EnemyCount < 1) {
            SceneLoader.LoadNextScene();
        }
    }

    private void OnDestroy() {
        Instantiate(_particle, transform.position, Quaternion.identity);
        _particle.transform.parent = null;
    }
}
