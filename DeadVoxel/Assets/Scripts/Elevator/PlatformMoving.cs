using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    public bool canMove;

    [SerializeField] Transform[] points;
    [SerializeField] int startPoint;
    [SerializeField] float speed;

    int i;
    bool reverse;

    void Start()
    {
        transform.position = points[startPoint].position;
        i = startPoint;
    }

    void Update()
    {
        Invoke("Movement", 1.5f);
    }

    void Movement() 
    {
        if (Vector3.Distance(transform.position, points[i].position) < 0.01f)
        {
            canMove = false;

            if (i == points.Length - 1)
            {
                reverse = true;
                i--;
                return;
            }
            else if (i == 0)
            {
                reverse = true;
                i++;
                return;
            }
        }

        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
    }
}