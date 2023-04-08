using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInCanvas : MonoBehaviour
{
    [SerializeField] CanvasGroup _canvasGroup;
    [Range(0, 1)][SerializeField] float _canvasFadeInSpeed;

    private void Start()
    {
        LeanTween.value(_canvasGroup.gameObject, 0, 1, _canvasFadeInSpeed).setOnUpdate((float val) =>
        {
            _canvasGroup.alpha = val;
        });
    }
}
