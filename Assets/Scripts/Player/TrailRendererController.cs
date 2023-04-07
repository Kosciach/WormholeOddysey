using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRendererController : MonoBehaviour
{
    [SerializeField] Transform _targetWidth;
    [SerializeField] TrailRenderer _trailRenderer;
    [Range(0, 10)] [SerializeField] float _widthLerpSpeed;

    void Update()
    {
        _trailRenderer.startWidth = Mathf.Lerp(_trailRenderer.startWidth, (_targetWidth.localScale.x + _targetWidth.localScale.y) / 2, _widthLerpSpeed * Time.deltaTime);
    }
}
