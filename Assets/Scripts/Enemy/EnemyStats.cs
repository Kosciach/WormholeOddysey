using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("====Settings====")]
    [Range(0, 300)]
    [SerializeField] float _health;

    private bool _isDead;

    public delegate void EnemyStatsEvent();
    public static event EnemyStatsEvent Death;




    public void TakeDamage(float damage)
    {
        _health -= damage;
        _health = Mathf.Clamp(_health, 0, 300);

        if (_health == 0) Die();
    }

    public void Die()
    {
        if (_isDead) return;
        _isDead = true;

        //Death();
        Destroy(gameObject);
    }
}
