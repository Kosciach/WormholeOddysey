using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] Rigidbody2D _rigidbody;


    [Space(20)]
    [Header("====Debug====")]
    [SerializeField] bool _isGrounded;


    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 10)][SerializeField] float _speed;
    [Range(0, 10)][SerializeField] float _accelerationSpeed;
    [Range(0, 10)][SerializeField] float _jumpForce;
    [Range(0, 10)][SerializeField] float _groundDetectionRadius;
    [SerializeField] LayerMask _groundMask;


    private Vector2 _movementVector;


    private void Update()
    {
        CheckGround();
    }

    public void GroundedMovement()
    {

    }
    public void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }



    public bool IsGrounded()
    {
        return _isGrounded;
    }
    private void CheckGround()
    {
        _isGrounded = Physics2D.CircleCast(transform.position, _groundDetectionRadius, Vector2.down, 0, _groundMask);
    }
}
