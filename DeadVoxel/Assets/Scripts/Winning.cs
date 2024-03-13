using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            Invoke("LoadScene", 1f);
        }
    }

    void LoadScene() 
    {
        SceneManager.LoadScene("WinMenu");
    }
}
