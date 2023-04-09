using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _healthText;
    [SerializeField] GameObject[] _screens;


    private Dictionary<string, int> _screenKeys = new Dictionary<string, int>();


    private void Awake()
    {
        _screenKeys.Add("Menu", 0);
        _screenKeys.Add("Gameplay", 1);
        _screenKeys.Add("Pause", 2);
    }



    public void SwitchScreen(string key)
    {
        int index;
        if(!_screenKeys.TryGetValue(key, out index)) return;

        foreach (GameObject screen in _screens) screen.SetActive(false);
        _screens[index].SetActive(true);
    }
    public void UpdateHP(float health)
    {
        _healthText.text = "Health: " + health;
    }
}
