using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHealth : Health {

    [SerializeField] private AudioPlayer _player;

    void Awake() {
        GameManager.ProjectileCount++;
    }

    public override void Die() {
        base.Die();
        StartCoroutine(OnDeath());
    }

    private IEnumerator OnDeath() {
        yield return new WaitForSeconds(1.9f);
        _player.PlayAudio();
        GameManager.ProjectileCount--;
        if (GameManager.ProjectileCount < 1) {
            GameManager.CurrentGameState = GameStates.Paused;
            GameObject.Find("UI").GetComponent<Canvas>().enabled = true;
        }
        GameManager.CurrentGameState = GameStates.Adjusting;
    }
}
