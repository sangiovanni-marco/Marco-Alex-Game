using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField] private GameObject Settings;
    [SerializeField] private GameObject Controls;
   
    public void OpenSettings()
    {
        Settings.SetActive(true);
    }

    public void CloseSettings()
    {
        Settings.SetActive(false);
    }
    public void OpenControls()
    {
        Controls.SetActive(true);
    }

    public void CloseControls()
    {
        Controls.SetActive(false);
    }
}
