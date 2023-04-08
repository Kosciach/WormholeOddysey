using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuExitScript : MonoBehaviour
{


    private void Start()
    {
        StartCoroutine(EnterGameplay());
    }


    private IEnumerator EnterGameplay()
    {
        yield return new WaitForSeconds(3.3167f);
        SceneManager.LoadScene("GameplayScene");
    }
}
