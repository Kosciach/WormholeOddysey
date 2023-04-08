using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTimelineChanger : MonoBehaviour
{
    [SerializeField] float _timeLineDuration;
    [SerializeField] string _nextSceneName;


    private void Start()
    {
        StartCoroutine(EnterGameplay());
    }


    private IEnumerator EnterGameplay()
    {
        yield return new WaitForSeconds(_timeLineDuration);
        SceneManager.LoadScene(_nextSceneName);
    }
}
