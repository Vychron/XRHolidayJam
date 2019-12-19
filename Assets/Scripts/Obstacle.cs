using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(SpriteSwapper))]

public class Obstacle : MonoBehaviour
{
    public Sprite originalSprite;
    public Sprite damagedSprite;

    private Health _hp;
    private SpriteSwapper _spriteRndr;

    // Start is called before the first frame update
    void Start()
    {
        _hp = gameObject.GetComponent<Health>();
        _spriteRndr = gameObject.GetComponent<SpriteSwapper>();
    }

    public void CheckHealthState()
    {
        if (_hp.Hp < _hp.MaxHp/2)
        {
            _spriteRndr.SetSprite(damagedSprite);
        }
    }
}
