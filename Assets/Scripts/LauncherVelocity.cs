using UnityEngine;

[RequireComponent(typeof(LauncherQueue))]
public class LauncherVelocity : MonoBehaviour {

    [SerializeField] private Vector2 _currentForce;
    private LauncherQueue _queue;

    private Transform _currentProjectile;

    void Start() {
        _queue = GetComponent<LauncherQueue>();
        ReadyNextProjectile();
    }

    void Update() {
        if (GameManager.CurrentGameState != GameStates.Adjusting) {
            return;
        }
        _currentForce = (Vector2)transform.position - IM.MousePosition;

        if (IM.MouseUp) {
            Launch();
        }
    }

    void Launch() {
        if (_currentProjectile == null) {
            Debug.LogError("Currently no projectile loaded, grabbing next...");
            _currentProjectile = _queue.GetNextProjectile();
        }

        if (_currentProjectile == null) {
            Debug.LogError("No projectiles found...");
            return;
        }
        GameManager.CurrentGameState = GameStates.Launching;
        Rigidbody2D rb = _currentProjectile.GetComponent<Rigidbody2D>();
        rb.simulated = true;
        rb.velocity = _currentForce;
        _currentProjectile = null;
        _currentForce = Vector2.zero;
    }

    void ReadyNextProjectile() {
        _currentProjectile = _queue.GetNextProjectile();
        _currentProjectile.GetComponent<Rigidbody2D>().simulated = false;
        _currentProjectile.position = transform.position;
    }

}
