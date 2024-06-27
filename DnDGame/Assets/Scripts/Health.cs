using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _maxHP = 100;
    private int _hp;


    public int MaxHP => _maxHP;

    public int HP
    {
        get => _hp;
        private set
        {
            var isDamage = value < _hp;
            _hp = Mathf.Clamp(value, min:0, _maxHP);
            if (isDamage)
            {
                Damaged?.Invoke(_hp);
            }
            else
            {
                Healed?.Invoke(_hp);
            }
            if (_hp <= 0)
            {
                Dead?.Invoke();
            }
        }
    }

    public UnityEvent<int> Healed;
    public UnityEvent<int> Damaged;
    public UnityEvent Dead;

    private void Awake() => _hp = _maxHP;


    public void Damage(int amount) => HP -= amount;


    public void Heal(int amount) => HP += amount;


    public void HealFull() => HP = _maxHP;


    public void Kill() => HP = 0;

    public void Adjust(int value) => HP = value;

}
