using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.VFX;

public class DamageDealerScript : MonoBehaviour
{
    [Header("====Reference====")]
    [SerializeField] AttackScript _attackScript;
    [SerializeField] VisualEffect _enemyHitEffect;

    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 100)]
    [SerializeField] float _damage;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_attackScript.CheckCanDealDamage()) return;

        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyStats>()?.TakeDamage(_damage);
            Destroy(Instantiate(_enemyHitEffect, transform.position, Quaternion.identity), 3);
        }
    }
}
