using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float speed;
    Vector3 targetPos;

    public GameObject ways;
    public Transform[] wayPoints;
        int pointIndex;
    int pointCount;
    int direction = 1;
    public CircleCollider2D col2D;
    public bool colliderState=true;

    private void Awake()
    {
        wayPoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.gameObject.transform.childCount; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i).gameObject.transform;
        }

    }

    private void Start()
    {
        pointCount = wayPoints.Length;
        pointIndex = 1;
        targetPos = wayPoints[pointIndex].transform.position;
     //   col2D= GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (TopDownMovement.instance.isGameOver == false)
        {
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
            if (transform.position == targetPos)
            {
                NextPoint();
            }
        }

      /*  if(Input.GetKeyDown(KeyCode.Space))
        {
            col2D.enabled = !colliderState;
            colliderState = !colliderState;
        }
      */
    }

    void NextPoint()
    {
        if (pointIndex == pointCount - 1)
        {
            direction = -1;
        }

        if (pointIndex == 0)
        {
            direction = 1;

        }
        pointIndex += direction;
        targetPos = wayPoints[pointIndex].transform.position;
    }

    


}
