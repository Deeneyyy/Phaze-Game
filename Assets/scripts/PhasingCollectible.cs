using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasingCollectible : MonoBehaviour
{
    public BoxCollider2D capcl;
    public bool colliderStatus = true;
    public bool isPhase;
    public float phaseTime = 3.0f; // time limit for phasing

    private float phaseTimer; // timer for phasing

    // Start is called before the first frame update
    void Start()
    {
        capcl = GetComponent<BoxCollider2D>();
        capcl.enabled = true;
        isPhase = false;
        phaseTimer = phaseTime;
    }

    // Update is called once per frame
    void Update()
    {

        //if (/*Input.GetKeyDown(KeyCode.Space)*/Input.GetButtonDown("Jump"))
        //{
        //    this.crobstl.enabled=!colliderStatus;
        //    colliderStatus=!colliderStatus;
        //    //Debug.Log(crobstl.enabled);

        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPhase = !isPhase;
            phaseTimer = phaseTime;
        }

        if (isPhase)
        {
           capcl.enabled = false;

            // Update phase timer and blink timer
            phaseTimer -= Time.deltaTime;



            // Switch back to original state
            if (phaseTimer <= 0f)
            {
                isPhase = false;
                capcl.enabled = true;
            }
        }
        else
        {
            capcl.enabled = true;
        }
    }
}
