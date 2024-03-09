using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagScripts : MonoBehaviour
{
    Transform mf;
    [SerializeField] float ColdTime;
    float GotoTime = 0;
    bool down = false;


    void Start()
    {
        mf = transform.transform.GetChild(1);
    }


    void Update()
    {
        FlagDown();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Mario")
        {
            down = true;
        }
    }
    private void FlagDown()
    {
        if (mf.position.y < 34)
        {
         SceneManager.LoadScene(4);
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        
        if (down && Time.time - GotoTime >= ColdTime)
        {
            Vector3 temp = new Vector3(0, -0.05f, 0);
            mf.position += temp;
            GotoTime = Time.time;
        }
    }
}