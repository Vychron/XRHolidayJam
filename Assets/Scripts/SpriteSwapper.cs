using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class SpriteSwapper : MonoBehaviour
{
    private SpriteRenderer _spriteRndr;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRndr = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite sprite)
    {
        _spriteRndr.sprite = sprite;
    }
    public void SetSprite(Material material)
    {
        _spriteRndr.material = material;
    }
    public void SetSprite(Sprite sprite, Material material)
    {
        _spriteRndr.sprite = sprite;
        _spriteRndr.material = material;
    }
}
