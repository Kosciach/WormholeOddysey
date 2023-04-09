using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPusher : MonoBehaviour
{
    [Header("====Debugs====")]
    [SerializeField] bool _wasPushed;



    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 20)]
    [SerializeField] float _radius;
    [SerializeField] LayerMask _playerMask;


    private Rigidbody2D _playerRigidbody;

    private void Awake()
    {
        _playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        DetectPlayer();
    }
    private void DetectPlayer()
    {
        if(Physics2D.OverlapCircle(transform.position, _radius, _playerMask))
        {
            _wasPushed = true;
            _playerRigidbody.AddForce((_playerRigidbody.transform.position - transform.position) * 300);
        }
    }
}
