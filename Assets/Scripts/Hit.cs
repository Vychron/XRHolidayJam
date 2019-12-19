using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]

public class Hit : MonoBehaviour
{
    [SerializeField] private AudioPlayer _player;

    private Collider2D _cldr;

    [SerializeField]
    private float _baseDamage;
    public float BaseDamage {
        private set { _baseDamage = BaseDamage; }
        get { return _baseDamage; }
    }

    [SerializeField]
    private float _damageMultiplier;

    [SerializeField]
    private UnityEvent _onHit;

    // Start is called before the first frame update
    void Start()
    {
        _cldr = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _player.PlayAudio();

        Health hitHealth = collision.gameObject.GetComponent<Health>();

        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (hitHealth)
        {
            float damage = Vector2.Distance(collision.transform.position, rb.velocity) * _damageMultiplier + _baseDamage;

            Debug.Log(damage);

            hitHealth.ReduceHealth(damage);
        }

        _onHit?.Invoke();
    }
}
