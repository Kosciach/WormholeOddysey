using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] PlayerInputController _playerInputController;
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] Transform _groundCheckPosition;


    [Space(20)]
    [Header("====Debug====")]
    [SerializeField] bool _isGrounded;


    [Space(20)]
    [Header("====Settings====")]
    [Range(0, 10)] [SerializeField] float _speed;
    [Range(0, 10)] [SerializeField] float _accelerationSpeed;
    [Range(0, 10)] [SerializeField] float _jumpForce;
    [Range(0, 10)] [SerializeField] float _groundDetectionRadius;
    [SerializeField] LayerMask _groundMask;


    private Vector2 _movementVector;


    private void Update()
    {
        CheckGround();
    }

    public void GroundedMovement()
    {
        Vector3 targetMovementVector = _playerInputController.MovementInputVector * _speed * 100 * Time.deltaTime;

        _movementVector = Vector3.Lerp(_movementVector, targetMovementVector, _accelerationSpeed * Time.deltaTime);
        _movementVector.y = _rigidbody.velocity.y;

        _rigidbody.velocity = _movementVector;
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
        _isGrounded = Physics2D.CircleCast(_groundCheckPosition.position, _groundDetectionRadius, Vector2.down, 0, _groundMask);
    }
}
