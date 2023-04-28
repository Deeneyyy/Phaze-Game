using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float phaseTime = 2.0f;
    public float phaseCooldown = 5.0f;
    public LayerMask obstacleLayer;
    private bool isPhasing = false;
    private float phaseTimer = 0.0f;
    private float phaseCooldownTimer = 0.0f;
    private Collider2D playerCollider;

    void Start()
    {
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isPhasing && phaseCooldownTimer <= 0.0f)
        {
            isPhasing = true;
            phaseTimer = phaseTime;
            playerCollider.enabled = false;
        }

        if (isPhasing)
        {
            phaseTimer -= Time.deltaTime;

            if (phaseTimer <= 0.0f)
            {
                isPhasing = false;
                phaseCooldownTimer = phaseCooldown;
                playerCollider.enabled = true;
            }
        }

        if (phaseCooldownTimer > 0.0f)
        {
            phaseCooldownTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (!isPhasing)
        {
            // Move the player normally
        }
        else
        {
            // Phase through obstacles
            RaycastHit2D hit = Physics2D.Raycast(transform.position, GetComponent<Rigidbody2D>().velocity.normalized, 0.5f, obstacleLayer);

            if (hit.collider != null)
            {
                transform.position = hit.point + (GetComponent<Rigidbody2D>().velocity.normalized * 0.1f);
            }
        }
    }
}