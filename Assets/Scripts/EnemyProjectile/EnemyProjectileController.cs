using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.VFX;

public class EnemyProjectileController : MonoBehaviour, IStatsInterface
{
    [Header("====References====")]
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] VisualEffect _enemyHitEffect;


    [Header("====Settings====")]
    [Range(0, 10)]
    [SerializeField] float _damage;
    [Range(0, 20)]
    [SerializeField] float _speed;
    [Range(0, 50)]
    [SerializeField] float _health;


    private bool _isDead;
    private bool _canMove;
    private Transform _player;

    private Vector2 _movementVector;


    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        _rigidbody.AddForce(Vector2.up * Random.Range(1, 5), ForceMode2D.Impulse);
        Invoke("StartMovement", 0.1f * Random.Range(1, 4));
    }

    private void Update()
    {
        float diffX = _player.GetChild(0).position.x - transform.position.x;
        float diffY = _player.GetChild(0).position.y - transform.position.y;

        float angle = Mathf.Atan2(diffY, diffX) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);



        UpdateScale();
    }
    private void FixedUpdate()
    {
        if (!_canMove) return;

        Vector2 movementVectorTemp = transform.up * _speed * 10 * Time.deltaTime;
        _movementVector = Vector2.Lerp(_movementVector, movementVectorTemp, 10 * Time.deltaTime);
        _rigidbody.velocity = _movementVector;
    }
    private void UpdateScale()
    {
        transform.localScale = Vector2.one * (_health / 100);
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

        Destroy(gameObject);
    }

    private void InstanciateHitEffect(Transform hitTransform)
    {
        VisualEffect newEffect = Instantiate(_enemyHitEffect, transform.position, Quaternion.identity);
        newEffect.transform.localScale = hitTransform.transform.localScale * 2;
        Destroy(newEffect, 3);
    }
    private void StartMovement()
    {
        _canMove = true;
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            InstanciateHitEffect(transform);
            collision.GetComponent<IStatsInterface>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }





    private void SetPlayerDeath()
    {
        InstanciateHitEffect(transform);
        Destroy(gameObject);
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
