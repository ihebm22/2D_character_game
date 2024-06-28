using System.Collections;
using System.Collections.Generic;
//using System.Media;
using System.Threading;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;
    private bool gameWin = false;
    
    public GameObject _losePanel;
    public GameObject _winPanel;


    // Start is called before the first frame update
    void Start()
    {
        _losePanel.SetActive(false);
        _winPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            UnityEngine.Debug.Log("--------------here is game manager, you lost");
            //Time.deltaTime = 0;
            _losePanel.SetActive(true);
        }
        if (gameWin)
        {
            UnityEngine.Debug.Log("--------------here is game manager, you won !");
            //Time.deltaTime = 0;
            _winPanel.SetActive(true);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
    }
    public void GameWin()
    {
        gameWin = true;
    }
}
