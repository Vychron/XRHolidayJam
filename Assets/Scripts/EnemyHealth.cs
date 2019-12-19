using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {
    private void Awake() {
        GameManager.EnemyCount++;
    }

    public override void Die() {
        base.Die();
        GameManager.EnemyCount--;
        if (GameManager.EnemyCount < 1) {
            SceneLoader.LoadNextScene();
        }
    }
}
