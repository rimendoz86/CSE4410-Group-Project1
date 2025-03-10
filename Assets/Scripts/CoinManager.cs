using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coinCount;                 
    [SerializeField] TMP_Text coinText;        

    public int totalCoins = 10;            

    void Update()
    {
        coinText.text = coinCount.ToString() + "/" + totalCoins;        
    }
}


