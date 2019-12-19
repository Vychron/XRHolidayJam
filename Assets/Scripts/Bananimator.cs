using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bananimator : MonoBehaviour {

    private Vector2 _scale;
    [SerializeField] private float _finalScale;

    private void Awake() {
        _scale = transform.localScale;
        transform.localScale = Vector2.zero;
        StartCoroutine(Grow());
    }

    private IEnumerator Grow() {
        while (transform.localScale.x < _scale.x * _finalScale) {
            transform.localScale += (Vector3)(_scale / _finalScale / 20);
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
