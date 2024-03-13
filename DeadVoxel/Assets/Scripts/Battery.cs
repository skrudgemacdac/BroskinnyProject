using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public Flash flash;
    public GameObject text;

    void Start()
    {
        text.SetActive(false);
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                flash.Energy += 25;
                Destroy(gameObject);
                text.SetActive(false);
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            text.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player")) 
        {
            text.SetActive(false);
        }
    }
}