using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    //Health will be protected from manipulation, but can be retrieved
    private float _hp;
    public float Hp
    {
        private set { _hp = Hp; }
        get { return _hp; }
    }

    [SerializeField]
    private float _maxHp;
    public float MaxHp
    {
        private set { MaxHp = _maxHp; }
        get { return _maxHp; }
    }

    [SerializeField]
    private UnityEvent _onDamaged;

    [SerializeField]
    private UnityEvent _onDead;

    [SerializeField]
    private UnityEvent _onHealed;


    // Start is called before the first frame update
    void Start()
    {
        _hp = MaxHp;
    }

    public void ReduceHealth(float damaging)
    {
        _hp -= damaging;
        _onDamaged?.Invoke();
        Debug.Log(gameObject.name + " hit");
        if (_hp <= 0)
        {
            _onDead?.Invoke();
        }
    }

    public void AddHealth(float healing)
    {
        _hp += healing;
        _onHealed?.Invoke();
    }

    public void Die()
    {
        Debug.Log(gameObject.name + " dead");
        Destroy(gameObject,0.05f);
    }
}
