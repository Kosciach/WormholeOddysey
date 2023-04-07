using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputController : MonoBehaviour
{
    public delegate void GameInputEvent();
    public static event GameInputEvent Pause;

    private GameInputs _gameInputs;



    private void Awake()
    {
        _gameInputs = new GameInputs();
    }

    private void Start()
    {
        _gameInputs.Game.Pause.performed += ctx => Pause();
    }









    private void OnEnable()
    {
        _gameInputs.Enable();
    }
    private void OnDisable()
    {
        _gameInputs.Disable();
    }
}
