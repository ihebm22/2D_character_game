using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Hosting;
using UnityEngine;
using UnityEngine.SceneManagement;
//using static System.Net.Mime.MediaTypeNames;

public class MainMenu : MonoBehaviour
{
    
    //public Image  _options;

    // Start is called before the first frame update
    public void continueGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game scene");

    }
    public void newGame()
    {
        SceneManager.LoadScene("Game scene");

    }
    public void quitGame()
    {
        Application.Quit();

    }
    public void showMessage()
    {
        //_options.gameObject.SetActive(true);
    }
    public void closeMessage()
    {
        //_options.gameObject.SetActive(false);
    }



}
