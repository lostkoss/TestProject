using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{
    public GameObject ball;

    public float startSpeed;
    public float speed;
    float speedUP;

    BallMoover ballComponent;
    Transform ballTransform;

    Transform _transform;
    void Start()
    {
        speedUP = startSpeed / 2;
        speed = startSpeed;
        ballComponent = ball.GetComponent<BallMoover>();
        ballTransform = ball.GetComponent<Transform>();
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        _transform.position = Vector3.MoveTowards(transform.position, new Vector3(ballTransform.position.x, transform.position.y,transform.position.z), speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ballComponent.SetDefaultPosition();
        }
    }
    public void LvlUp()
    {
        speed += speedUP;
    }
}
