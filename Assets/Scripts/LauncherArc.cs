using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherArc : MonoBehaviour {
    private LauncherVelocity _launcherVelocity;
    private Vector2 _shootVelocity;

    private Vector2 _mousePosOld;
    private LineRenderer _renderer;

    private float _velocity;
    private float _radianAngle;
    [SerializeField] private int _segments;


    void Start() {
        _launcherVelocity = GetComponent<LauncherVelocity>();
        _renderer = GetComponent<LineRenderer>();
    }

    void Update() {
        if (IM.MouseDown && IM.MousePosition != _mousePosOld) {
            //if (!_renderer.enabled) {
            //    _renderer.enabled = true;
            //}
            _mousePosOld = IM.MousePosition;
            DrawArc();
        }
        if (GameManager.CurrentGameState == GameStates.Launching) {
            //if (_renderer.enabled) {
            //    _renderer.enabled = false;
            //}
        }
    }

    void DrawArc() {
        _shootVelocity = _launcherVelocity.CurrentForce;
        _velocity = _shootVelocity.magnitude * 0.955f;
        _radianAngle = Mathf.Atan2(_shootVelocity.y, _shootVelocity.x);
        _renderer.positionCount = _segments;
        _renderer.SetPositions(CalculateArcArray());
    }

    Vector3[] CalculateArcArray() {
        Vector3[] arcArray = new Vector3[_segments + 1];

        //_radianAngle = Mathf.Deg2Rad * _angle;
        float maxDistance = (_velocity * _velocity * Mathf.Sin(2 * _radianAngle));
        for (int i = 0; i <= _segments; i++) {
            float t = (float)i / (float)_segments;
            arcArray[i] = CalculateArcPoint( t, maxDistance);
        }

        return arcArray;
    }

    Vector3 CalculateArcPoint(float t, float maxDistance) {

        float x = t * maxDistance;
        float y = x * Mathf.Tan(_radianAngle) - ((x * x) / (2 * (_velocity * _velocity * Mathf.Cos(_radianAngle) * Mathf.Cos(_radianAngle))));
        return new Vector3(x + transform.position.x, y + transform.position.y);
    }

}
