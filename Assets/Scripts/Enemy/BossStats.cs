using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : EnemyStats
{
    [SerializeField] float _healFactor;

    void Update()
    {
        Heal();
    }

    public void Heal()
    {
        if (_isDead) return;

        _health += _healFactor;
        _health = Mathf.Clamp(_health, 0, 300);
    }
}
