using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pause_UI : MonoBehaviour
{
    public GameObject PauseObject;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        PauseObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PauseObject.SetActive(isPaused);

     if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
    }

    public void Resume()
    {
        PauseObject.SetActive(false);
        isPaused = !isPaused;
    }
}
