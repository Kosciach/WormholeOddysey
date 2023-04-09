using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalOpener : MonoBehaviour
{
    [SerializeField] GameObject _portal;



    public void OpenPortal()
    {
        _portal.SetActive(true);
    }
    private void OnDestroy()
    {
        OpenPortal();
    }
}
