using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    public bool isPhasing;
    //public BoxCollider2D br;
    public Color or_color;
    public Color space_color;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //br= GetComponent<BoxCollider2D>();
        isPhasing = false;
        or_color= new Color(0.282f, 0.643f, 0.737f);
        space_color = new Color(0.886f, 0.624f, 0.212f);
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb2d.velocity = moveInput * moveSpeed;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            isPhasing=!isPhasing;  
        }

        if(isPhasing) 
        { 
          //  br.enabled=false;
            sr.color =space_color; 
        }
        else { 
          // br.enabled=true;
            sr.color = or_color; }

    }
*/




public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    public bool isPhasing;
    public Color or_color;
    public Color space_color;
    public SpriteRenderer sr;
    public float phaseTime = 3.0f; // time limit for phasing
    public float blinkRate = 0.2f; // rate at which the player blinks when phase time is almost up

    private float phaseTimer; // timer for phasing
    private bool blinkState; // current state of the blink
    private float blinkTimer; // timer for blinking

    public coinManager cm;
    public PlayerStamins playerStamins;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isPhasing = false;
        or_color = new Color(0.282f, 0.643f, 0.737f);
        space_color = new Color(0.886f, 0.624f, 0.212f);
        sr = GetComponent<SpriteRenderer>();
        phaseTimer = phaseTime;
        blinkState = false;
        blinkTimer = 0f;
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
       
        if (moveInput.x !=0)
        {
            moveInput.y = 0;
        }
        else if (moveInput.y !=0)
        {
            moveInput.x = 0;
        }

        moveInput.Normalize();

        rb2d.velocity = moveInput * moveSpeed;

        if (Input.GetKeyDown(KeyCode.Space)&&(playerStamins.currentStamina-playerStamins.damagePlayer >0))
        {
            //this is for stamina bar
            //StaminaBar.Instance.UseStamina(15);
            
            isPhasing = !isPhasing;
            phaseTimer = phaseTime;
            blinkState = false;
            blinkTimer = 0f;
        }

        if (isPhasing)
        {
            sr.color = space_color;

            // Update phase timer and blink timer
            phaseTimer -= Time.deltaTime;
            blinkTimer += Time.deltaTime;

            // Blink effect when phase timer is almost up
            if (phaseTimer <= blinkRate)
            {
                blinkTimer = 0f;
                blinkState = !blinkState;
                sr.enabled = !blinkState;
            }

            // Switch back to original state
            if (phaseTimer <= 0f)
            {
                isPhasing = false;
                sr.enabled = true;
                sr.color = or_color;
            }
        }
        else
        {
            sr.color = or_color;
        }
    }





//this is the collectible
private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("collectible")) 
        {
            cm.coinCount++;
            print("we have collected");

           Destroy(collision.gameObject);
        }
    }
    
}
