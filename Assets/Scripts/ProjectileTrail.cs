using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrail : MonoBehaviour {

    [SerializeField] private Transform _trailContainer;
    [SerializeField] private GameObject[] _trailPrefabs;

    private int _currentPrefab;

    private Projectile _projectile;
    

    [SerializeField] private int _delay; //drawing delay in frames;
    private int _currentDelay;
    void Start() {
        _projectile = GetComponent<Projectile>();
    }

    void Update() {
        //Needs to get a condition ASAP!
        if (IM.MouseUp) {
            if (_trailContainer.childCount != 0) {
                for (int i = 0; i < _trailContainer.childCount; i++) {
                    Destroy(_trailContainer.GetChild(i).gameObject);
                }
            }
        }
        if (true) {
            _currentDelay++;
            if (_currentDelay >= _delay) {
                DrawTrail();
                _currentDelay -= _delay;
            }
        }
    }

    void DrawTrail() {
        GameObject trail = Instantiate(_trailPrefabs[_currentPrefab], transform.position, Quaternion.identity);
        trail.transform.parent = _trailContainer;
        _currentPrefab++;
        if (_currentPrefab >= _trailPrefabs.Length) {
            _currentPrefab -= _trailPrefabs.Length;
        }
    }
}
