using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{
    // Open popup
    public void Open()
    {
        gameObject.SetActive(true);
    }
    // Close popup
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
