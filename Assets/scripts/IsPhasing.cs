using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPhasing : MonoBehaviour
{
    public CircleCollider2D crobstl;
    public bool colliderStatus=true;
    public bool isPhase;
    public float phaseTime = 3.0f; // time limit for phasing
    public PlayerStamins playerStamins;

    private float phaseTimer; // timer for phasing

    // Start is called before the first frame update
    void Start()
    {
        crobstl=GetComponent<CircleCollider2D>();
        crobstl.enabled=true;
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

          if (Input.GetKeyDown(KeyCode.Space) )
        {
            isPhase = !isPhase;
            phaseTimer = phaseTime;
        }

        if (isPhase)
        {
            crobstl.enabled = false;

            // Update phase timer and blink timer
            phaseTimer -= Time.deltaTime;
            


            // Switch back to original state
            if (phaseTimer <= 0f)
            {
                isPhase = false;
                crobstl.enabled = true;
            }
        }
        else
        {
            crobstl.enabled = true;
        }
    }
}
