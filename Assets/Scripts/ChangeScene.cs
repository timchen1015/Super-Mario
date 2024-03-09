using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    MarioMovement mm;
    GameObject player;

    private void Start()
    {
        mm = GameObject.FindGameObjectWithTag("Player").GetComponent<MarioMovement>();
    }
    public void startgame()
    {
        SceneManager.LoadScene(2);
      
        
    }

    public void teach()
    {
        SceneManager.LoadScene(1);
       
    }
    public void exit()
    {
        Application.Quit();
       
    }
    public void back()
    {
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        if (mm == null) return;
        if (!mm.isGrounded && transform.position.y < -20)
        {
            mm.isDead = true;
            SceneManager.LoadScene(3);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
