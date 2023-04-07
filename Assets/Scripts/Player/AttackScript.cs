using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] Transform _weapon;
    [SerializeField] TrailRenderer _trailRenderer;

    [Space(20)]
    [Header("====Settings====")]
    [SerializeField] Vector3 _topRotation;
    [SerializeField] Vector3 _bottomRotation;
    [SerializeField] Vector3 _currentRotation;
    [Range(0, 4)] [SerializeField] float _attackSpeed;


    private void TurnLeft()
    {
        transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        Attack();
    }
    private void TurnRight()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        Attack();
    }

    private void Attack()
    {
        _trailRenderer.emitting = true;
        LeanTween.rotateLocal(_weapon.gameObject, _currentRotation, _attackSpeed).setOnComplete(() =>
        {
            _trailRenderer.emitting = false;
        });

        _currentRotation = _currentRotation == _topRotation ? _bottomRotation : _topRotation;
    }




    private void OnEnable()
    {
        PlayerInputController.AttackLeft += TurnLeft;
        PlayerInputController.AttackRight += TurnRight;
    }
    private void OnDisable()
    {
        PlayerInputController.AttackLeft -= TurnLeft;
        PlayerInputController.AttackRight -= TurnRight;
    }
}
