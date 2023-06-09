using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using MoreMountains.Feedbacks;

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
    public Color or_color= Color.white;
    public Color space_color;
    public SpriteRenderer sr;
    public float phaseTime = 3.0f; // time limit for phasing
    public float blinkRate = 0.2f; // rate at which the player blinks when phase time is almost up

    private float phaseTimer; // timer for phasing
    private bool blinkState; // current state of the blink
    private float blinkTimer; // timer for blinking

    public coinManager cm;
    public PlayerStamins playerStamins;

    public Animator animator;
    public Sprite[] playerSprite;
    public CircleCollider2D circleCollider;
    public bool isGameOver=false;

    public static TopDownMovement instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isPhasing = false;
        or_color = Color.white;
        space_color = Color.white;
        sr = GetComponent<SpriteRenderer>();
        phaseTimer = phaseTime;
        blinkState = false;
        blinkTimer = 0f;
        animator = GetComponent<Animator>();
        sr.sprite = playerSprite[0];
        animator.SetBool("Death", false);
        animator.SetBool("Trigger", false);
        circleCollider=GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        circleCollider.enabled = true;
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
        if(isGameOver) {
            moveInput.x = 0;
            moveInput.y = 0;
        }
        moveInput.Normalize();

        rb2d.velocity = moveInput * moveSpeed;

        if (Input.GetKeyDown(KeyCode.Space)&&(playerStamins.currentStamina-playerStamins.damagePlayer >0)&&(isGameOver==false))
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
            animator.SetBool("Trigger", true);
            sr.sprite = playerSprite[1];
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
                animator.SetBool("Trigger", false);
                sr.sprite = playerSprite[0];
                sr.color = or_color;
            }
        }
        else
        {
            animator.SetBool("Trigger", false);
            sr.sprite = playerSprite[0];
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
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Obstacle"))
        //{

        //    JumpFeedback.PlayFeedbacks();

        //}
    }

}
