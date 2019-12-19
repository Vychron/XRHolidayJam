using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private float _moveSpeed = 1;

    public Transform FollowingTransform { get { return _followingTransform; } set { _followingTransform = value; } }
    private Transform _followingTransform;
    private Vector3 _startingPosition;

    void Start() {
        _startingPosition = transform.position;
    }


    void Update() {
        if (_followingTransform != null) {
            transform.position = Vector3.Slerp(transform.position, new Vector3(_followingTransform.position.x, transform.position.y, transform.position.z), _moveSpeed);
        }
        else {
            transform.position = Vector3.Slerp(transform.position, _startingPosition, _moveSpeed);
        }
    }
}
