using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Home()
    {
        SceneManager.LoadScene("Home");
    }

    public void CreateGame()
    {
        SceneManager.LoadScene("CreateGame");
    }

    public void JoinGame()
    {
        SceneManager.LoadScene("JoinGame");
       
    }

    public void Player()
    {
        SceneManager.LoadScene("Player");
    }

    public void Moderator()
    {
        SceneManager.LoadScene("Moderator");
    }



}
