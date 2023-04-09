using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] CanvasGroup _canvasGroup;
    [Range(0, 2)]
    [SerializeField] float _canvasAlphaSpeed;


    private void Start()
    {
        LeanTween.value(_canvasGroup.gameObject, 0, 1, _canvasAlphaSpeed).setOnUpdate((float val) =>
        {
            _canvasGroup.alpha = val;
        });
    }
    public void GoToGamePlay()
    {
        LeanTween.value(_canvasGroup.gameObject, 1, 0, _canvasAlphaSpeed).setOnUpdate((float val) =>
        {
            _canvasGroup.alpha = val;
        }).setOnComplete(() =>
        {
            SceneManager.LoadScene("MenuExitCutScene");
        });
    }

    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
