using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherQueue : MonoBehaviour {

    [SerializeField] private List<Transform> _projectiles;

    public Transform GetNextProjectile() {
        Transform nextProjectile = null;
        if (_projectiles.Count > 0) {
            nextProjectile = _projectiles[0];
            _projectiles.Remove(nextProjectile);
            return nextProjectile;
        }
        return null;
    }

}
