using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    PlatformMoving platform;
    [SerializeField] private GameObject txt;

    private void Start()
    {
        txt.SetActive(false);
        platform = GetComponent<PlatformMoving>();
    }

    private void OnTriggerStay(Collider other)
    {
        //txt.SetActive(true);
        //if (Input.GetKeyDown(KeyCode.E)) 
        //{
        //    platform.canMove = true;
        //    txt.SetActive(false);
        //}
        Invoke("Move", 1.5f);
    }

    private void OnTriggerExit(Collider other)
    {
        platform.canMove = false;
    }

    private void Move()
    {
        platform.canMove = true;
    }
}