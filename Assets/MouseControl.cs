using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float maxY = 4.2f;
    [SerializeField] float minY = -4.2f;
    [SerializeField] float minX = -8.23f;
    [SerializeField] float maxX = 8.23f;
    Animator animator;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();//get reference toAnimator componenet
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("Up", Input.GetKey(KeyCode.UpArrow));
            transform.Translate(0f, speed * Time.deltaTime, 0f);
        }
        else
        {
            animator.SetBool("Up", false);
        }
        //animator.SetBool("Down", Input.GetKey(KeyCode.DownArrow));
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("Down", Input.GetKey(KeyCode.DownArrow));
            transform.Translate(0f, -speed * Time.deltaTime, 0f);
        }
        else
        {
            animator.SetBool("Down", false);
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("Right", true);
            spriteRenderer.flipX = false;
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("Right", true);
            spriteRenderer.flipX = true;
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);

        }
        else
        {
            animator.SetBool("Right", false);
        }
        if (transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY, 0f);
        }
        if (transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, 0f);
        }
        if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, 0f);
        }
        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, 0f);
        }
    }
}
