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

    public ProjectileState state = ProjectileState.Healthy;

    public Material healthySprite;
    public Material damagedSprite;
    public Material deadSprite;

    public float basePower;
    public float dyingBreath = 3;
    public float power = 5;

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

    public void LaunchProjectile(Vector2 vectorAngle, float power)
    {
        _rb.AddForce(vectorAngle * (basePower + power));
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
            case ProjectileState.Dead:
                _sprite.SetSprite(deadSprite);
                break;
            default:
                _sprite.SetSprite(healthySprite);
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
    }

    public void Die()
    {
        state = ProjectileState.Dead;

        Destroy(gameObject, dyingBreath);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchProjectile(Vector2.right, power);
        }
    }
}
