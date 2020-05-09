using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoover : MonoBehaviour
{
     public float speed = 10f;
    [SerializeField] private Vector3 defaultPosition;
    public bool isMooving;

     public float maxSpeed;
    private void Start()
    {
        isMooving = false;
    }
    private void Update()
    {
        if (isMooving)
        {
        transform.position += transform.forward * Time.deltaTime * speed;

        }
    }
    public void SetDefaultPosition()
    {
        isMooving = false;

        transform.position = defaultPosition;
    }
    public void SetSpeed(float mult)
    {
        speed = maxSpeed * mult;
    }
    public void SetDirection(float angle)
    {
        if(angle > 90)
        {
        transform.rotation = Quaternion.Euler(0, transform.rotation.y + (angle - 90) - 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.y - (angle - 90) -180, 0);
        }
    }


}
