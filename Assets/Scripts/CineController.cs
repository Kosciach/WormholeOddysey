using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineController : MonoBehaviour
{
    [SerializeField] float _offset;
    [SerializeField] float _offsetSpeed;


    private CinemachineVirtualCamera _cineCamera;
    private CinemachineTransposer _cineTransposer;


    private void Awake()
    {
        _cineCamera = GetComponent<CinemachineVirtualCamera>();
        _cineTransposer = _cineCamera.GetCinemachineComponent<CinemachineTransposer>();
    }
    private void Start()
    {
        //_cineTransposer.m_FollowOffset.y = 0;
        LeanTween.value(3.52f, _offset, _offsetSpeed).setOnUpdate((float val) =>
        {
            Debug.Log(_cineTransposer.m_FollowOffset.y);
            _cineTransposer.m_FollowOffset = new Vector3(0f, val, -10);
        });
    }
}
