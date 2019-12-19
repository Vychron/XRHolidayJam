using UnityEngine;

[RequireComponent(typeof(LauncherQueue))]
public class LauncherVelocity : MonoBehaviour {

    [SerializeField] private Vector2 _currentForce;

    [SerializeField] private float _forceMultiplier = 4f;

    private Transform _poker;
    private LauncherQueue _queue;

    private Transform _currentProjectile;

    void Start() {
        _queue = GetComponent<LauncherQueue>();
        _poker = transform.GetChild(0);
        ReadyNextProjectile();
    }

    void Update() {
        if (GameManager.CurrentGameState != GameStates.Adjusting) {
            return;
        }
        _currentForce = (Vector2)transform.position - IM.MousePosition;
        if (IM.MouseDown) {
            _poker.localPosition = new Vector3(-_currentForce.x / 50 - 0.1f, 0, 1);

            float angle = Mathf.Atan2(_currentForce.y, _currentForce.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
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
        Camera.main.GetComponent<CameraFollow>().FollowingTransform = _currentProjectile;
        GameManager.CurrentGameState = GameStates.Launching;
        Rigidbody2D rb = _currentProjectile.GetComponent<Rigidbody2D>();
        rb.simulated = true;
        rb.velocity = _currentForce * _forceMultiplier;
        _currentProjectile = null;
        _currentForce = Vector2.zero;
    }

    void ReadyNextProjectile() {
        _currentProjectile = _queue.GetNextProjectile();
        _currentProjectile.GetComponent<Rigidbody2D>().simulated = false;
        _currentProjectile.position = transform.position + new Vector3(0, 0, 2);
    }

}
