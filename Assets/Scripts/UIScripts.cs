using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIScripts : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerWin() {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>().RestartGame();
        Destroy(gameObject);
    }
    public void PlayerLose() {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameLogic>().RestartGame();
        Destroy(gameObject);
    }
}
