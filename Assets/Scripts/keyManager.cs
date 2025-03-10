using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class keyManager : MonoBehaviour
{
    public int keyCount;
    [SerializeField] TMP_Text keyText;

    void Start()
    {
       
    }

    void Update()
    {
        keyText.text = keyCount.ToString() + "/1";       
    }    
}
