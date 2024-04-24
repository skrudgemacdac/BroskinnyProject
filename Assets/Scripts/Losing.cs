using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Losing : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")) 
        {
            Invoke("LoadScene", 1f);
        }
    }
    void LoadScene() 
    {
        SceneManager.LoadScene("LoseMenu", LoadSceneMode.Single);
    }
}
