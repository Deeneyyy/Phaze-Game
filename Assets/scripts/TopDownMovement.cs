using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    public bool isPhasing;
    public BoxCollider2D br;
    public Color or_color;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        br= GetComponent<BoxCollider2D>();
        isPhasing = false;
        or_color=Color.cyan;
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
            br.enabled=false;
            sr.color = Color.magenta;
        }
        else { 
            br.enabled=true;
            sr.color = or_color; }

    }
  
    //this is the collectible
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("collectible")) 
        {
            print("we have collected");

           Destroy(collision.gameObject);
        }
    }
    
}
