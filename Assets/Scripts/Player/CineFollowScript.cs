using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineFollowScript : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField] float _followSpeed;
    [SerializeField] Transform _followTarget;



    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _followTarget.position, _followSpeed * Time.deltaTime);
    }
}
