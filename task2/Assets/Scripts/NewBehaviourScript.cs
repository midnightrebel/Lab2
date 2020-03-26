using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    public bool isGrounded;
    public Animator animator;
    public float h;
    public GameObject ItemToIntaract;

   

    private static NewBehaviourScript instance;
    public static NewBehaviourScript Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<NewBehaviourScript>();
            return instance;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {

        Vector3 direction = transform.right * h / 2;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, 2 * Time.deltaTime);
        if (h < 0)
            sprite.flipX = true;
        else if (h > 0)
            sprite.flipX = false;


        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) && IsGrounded())
            rb.AddForce(transform.up * 20, ForceMode2D.Impulse);


        if (h != 0 && IsGrounded())
            animator.SetInteger("stateAnimation", 1);
        if (Mathf.Abs(h) < 0.01)
            animator.SetInteger("stateAnimation", 0);
        if (!IsGrounded())
            animator.SetInteger("stateAnimation", 2);
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo;

        hitInfo = Physics2D.Raycast(transform.position - new Vector3
            (0, sprite.bounds.extents.y + 0.01f, 0), Vector2.down, 0.01f);
        if (hitInfo)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    
}


