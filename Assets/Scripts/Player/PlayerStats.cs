using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IStatsInterface
{
    [Header("====Settings====")]
    [Range(0, 100)]
    [SerializeField] float _health;

    private bool _isDead;

    public delegate void PlayerStatsEvent();
    public static event PlayerStatsEvent Death;





    public void TakeDamage(float damage)
    {
        _health -= damage;
        _health = Mathf.Clamp(_health, 0, 100);

        if (_health == 0) Die();
    }

    public void Die()
    {
        if (_isDead) return;
        _isDead = true;


        Death();
    }
}
