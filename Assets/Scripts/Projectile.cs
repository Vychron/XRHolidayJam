using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteSwapper))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Hit))]
[RequireComponent(typeof(Rigidbody2D))]

public class Projectile : MonoBehaviour
{
    public enum ProjectileState {Healthy, Damaged, Dead};
    public enum ProjectileAirtime { None, Flying, Landed};

    public ProjectileState state = ProjectileState.Healthy;
    public ProjectileAirtime airState = ProjectileAirtime.None;

    public Sprite healthySprite;
    public Sprite damagedSprite;

    public float basePower = 1;
    public float dyingBreath = 1;
    public float power = 1;
    public float maxLifetime = 15;

    private bool hit = false;

    [SerializeField]
    private float _damagedTreshhold;

    private Rigidbody2D _rb;
    private Health _health;
    private Hit _hit;
    private SpriteSwapper _sprite;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
        _hit = GetComponent<Hit>();
        _sprite = GetComponent<SpriteSwapper>();

        _damagedTreshhold = (_damagedTreshhold != 0) ? _damagedTreshhold : _health.MaxHp / 2; 
    }

    public void ChangeSprite()
    {
        switch (state)
        {
            case ProjectileState.Healthy:
                _sprite.SetSprite(healthySprite);
                break;
            case ProjectileState.Damaged:
                _sprite.SetSprite(damagedSprite);
                break;
            default:
                _sprite.SetSprite(damagedSprite);
                break;
        }
    }

    public void CheckState()
    {
        if(state != ProjectileState.Dead)
        {
            if (_health.Hp <= _damagedTreshhold)
            {
                state = ProjectileState.Damaged;
            }
            else
            {
                state = ProjectileState.Healthy;
            }
        }
        ChangeSprite();
    }

    public void SetToLanded()
    {
        Destroy(gameObject, maxLifetime);
        airState = ProjectileAirtime.Landed;
    }

    public void Die()
    {
        if (state != ProjectileState.Dead)
        {
            state = ProjectileState.Dead;

            ChangeSprite();

            Destroy(gameObject, dyingBreath);
        }
    }
    private void Update()
    {
        switch (airState)
        {
            case ProjectileAirtime.Flying:
                float angle = Mathf.Atan2(_rb.velocity.y, _rb.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                break;
            default:
                break;
        }
        if(_rb.velocity.magnitude <= 0.03f && airState == ProjectileAirtime.Landed)
        {
            Destroy(gameObject);
        }
    }
}
