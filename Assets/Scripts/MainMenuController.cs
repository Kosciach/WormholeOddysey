using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] CanvasGroup _canvasGroup;
    [Range(0, 2)]
    [SerializeField] float _canvasDissaperaSpeed;

    public void GoToGamePlay()
    {
        LeanTween.value(_canvasGroup.gameObject, 1, 0, _canvasDissaperaSpeed).setOnUpdate((float val) =>
        {
            _canvasGroup.alpha = val;
        }).setOnComplete(() =>
        {
            SceneManager.LoadScene("MenuExitCutScene");
        });
    }
}
