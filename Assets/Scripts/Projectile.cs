using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileSprite))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Hit))]
[RequireComponent(typeof(Rigidbody2D))]

public class Projectile : MonoBehaviour
{
    public enum ProjectileState {Healthy, Damaged, Dead};
    public enum ProjectileAirtime { None, Flying};

    public ProjectileState state = ProjectileState.Healthy;
    public ProjectileAirtime airState = ProjectileAirtime.None;

    public Sprite healthySprite;
    public Sprite damagedSprite;

    public float basePower;
    public float dyingBreath = 3;
    public float power = 5;

    private bool hit = false;

    [SerializeField]
    private float _damagedTreshhold;

    private Rigidbody2D _rb;
    private Health _health;
    private Hit _hit;
    private ProjectileSprite _sprite;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
        _hit = GetComponent<Hit>();
        _sprite = GetComponent<ProjectileSprite>();
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
        airState = ProjectileAirtime.None;
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
    }
}
