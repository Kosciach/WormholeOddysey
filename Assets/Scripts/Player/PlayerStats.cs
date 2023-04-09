using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IStatsInterface
{
    [Header("====References====")]
    [SerializeField] CanvasController _canvasController;


    [Space(20)]
    [Header("====Debugs====")]
    [SerializeField] bool _isDead;
    [SerializeField] bool _canTakeDamage;


    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 100)]
    [SerializeField] float _health;


    public delegate void PlayerStatsEvent();
    public static event PlayerStatsEvent Death;



    private void Start()
    {
        _canTakeDamage = true;
    }

    public void TakeDamage(float damage)
    {
        if (!_canTakeDamage) return;

        Debug.Log("elo");
        _health -= damage;
        _health = Mathf.Clamp(_health, 0, 100);
        _canvasController.UpdateHP(_health);

        if (_health == 0) Die();
    }

    public void Die()
    {
        if (_isDead) return;
        _isDead = true;


        Death();
    }

    private void Heal()
    {
        TakeDamage(-15);
    }
    public void ToggleCanTakeDamage(bool enable)
    {
        _canTakeDamage = enable;
    }


    private void OnEnable()
    {
        EnemyStats.Death += Heal;
    }
    private void OnDisable()
    {
        EnemyStats.Death -= Heal;
    }
}
