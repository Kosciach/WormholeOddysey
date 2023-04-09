using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DamageDealerScript : MonoBehaviour
{
    [Header("====Reference====")]
    [SerializeField] AttackScript _attackScript;

    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 100)]
    [SerializeField] float _damage;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_attackScript.CheckCanDealDamage()) return;

        if (collision.CompareTag("Brozgon") || collision.CompareTag("BrozgonHive"))
        {
            collision.GetComponent<IStatsInterface>().TakeDamage(_damage);
        }
    }
}
