using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [SerializeField] PlayerMovementController _playerMovementController;
    [SerializeField] Rigidbody2D _playerRigidbody;
    [Range(0, 100)]
    [SerializeField] float _speed;

    public void FixedUpdate()
    {
        transform.GetChild(0).position -= new Vector3(_playerRigidbody.velocity.x, _playerRigidbody.velocity.y, 0f) / (_speed * 4);
        transform.GetChild(1).position -= new Vector3(_playerRigidbody.velocity.x, _playerRigidbody.velocity.y, 0f) / (_speed * 10);
    }
}
