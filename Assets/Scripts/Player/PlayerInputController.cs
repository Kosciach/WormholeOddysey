using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [Header("====InputValues====")]
    [SerializeField] Vector3 _movementInputVector; public Vector3 MovementInputVector { get { return _movementInputVector; } }


    public delegate void PlayerInputEvent();
    public static event PlayerInputEvent Jump;
    public static event PlayerInputEvent AttackLeft;
    public static event PlayerInputEvent AttackRight;

    private PlayerInputs _playerInputs;


    private void Awake()
    {
        _playerInputs = new PlayerInputs();
    }
    private void Start()
    {
        _playerInputs.Player.Jump.performed += ctx => Jump();
        _playerInputs.Player.AttackLeft.performed += ctx => AttackLeft();
        _playerInputs.Player.AttackRight.performed += ctx => AttackRight();
    }
    private void Update()
    {
        Vector2 tempInputVector = _playerInputs.Player.Move.ReadValue<Vector2>();
        _movementInputVector = new Vector3(tempInputVector.x, 0f, 0f);
    }



    private void OnEnable()
    {
        _playerInputs.Enable();
    }
    private void OnDisable()
    {
        _playerInputs.Disable();
    }
}
