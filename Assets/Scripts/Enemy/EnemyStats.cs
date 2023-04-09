using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class EnemyStats : MonoBehaviour, IStatsInterface
{
    [Header("====References====")]
    [SerializeField] VisualEffect _enemyHitEffect;

    [Header("====Settings====")]
    [Range(0, 300)]
    [SerializeField] float _health;

    private bool _isDead;

    public delegate void EnemyStatsEvent();
    public static event EnemyStatsEvent Death;



    private void Update()
    {
        UpdateScale();
    }
    private void UpdateScale()
    {
        transform.localScale = Vector2.one * (_health/100);
    }


    public void TakeDamage(float damage)
    {
        if (_isDead) return;

        _health -= damage;
        _health = Mathf.Clamp(_health, 0, 300);
        InstanciateHitEffect(transform);

        if (_health == 0) Die();
    }

    public void Die()
    {
        if (_isDead) return;
        _isDead = true;

        //Death();
        Destroy(gameObject);
    }


    private void InstanciateHitEffect(Transform hitTransform)
    {
        VisualEffect newEffect = Instantiate(_enemyHitEffect, transform.position, Quaternion.identity);
        newEffect.transform.localScale = hitTransform.transform.localScale * 2;
        Destroy(newEffect, 3);
    }
}
