using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [Header("====Debugs====")]
    [SerializeField] bool _isPlayerDetected; public bool IsPlayerDetected { get { return _isPlayerDetected; } }
    [SerializeField] bool _isPlayerDead;



    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 20)]
    [SerializeField] float _radius;
    [SerializeField] LayerMask _playerMask;


    private void Update()
    {
        DetectPlayer();
    }
    private void DetectPlayer()
    {
        if (_isPlayerDead) return;
        _isPlayerDetected = Physics2D.OverlapCircle(transform.position, _radius, _playerMask);
    }

    private void SetPlayerDeath()
    {
        _isPlayerDead = true;
        _isPlayerDetected = false;
    }



    private void OnEnable()
    {
        PlayerStats.Death += SetPlayerDeath;
    }
    private void OnDisable()
    {
        PlayerStats.Death -= SetPlayerDeath;
    }
}
