using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public float followSpeed = 2f;
    public float yOffset = 1f;
    [SerializeField]
    public Transform target;


    //[SerializeField]
    //private int _leftLives = 4;
    //[SerializeField]
    //private Text _livesText;

    //planned to display lives amount but it doesnt work so im skipping for now
    void Start()
    {
        //_livesText.text = "" + _leftLives.ToString();
        //_livesText.text = player._lives;
    }

    

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position,newPos,followSpeed*Time.deltaTime);

        //_countLives = player._lives;
    }

    /*
    public void UpdateLives(int lives)
    {
        _countLives.text = "" + lives.ToString();
        _leftLives = lives;
    }*/

    public void launchMainMenu()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("Main Menu");
    }
    public void restartGame()
    {
        SceneManager.LoadScene("Game scene");
    }

}
