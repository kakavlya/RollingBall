using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class PanelOpener : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;
    
    public void OpenPanel()
    {
        if (Panel != null)
            Panel.SetActive(true);
    }
}
