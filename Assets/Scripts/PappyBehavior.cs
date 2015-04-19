using UnityEngine;
using System.Collections;

public class PappyBehavior : MonoBehaviour {

    private Animator animator;
    private Rigidbody2D rigidBody2D;

    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rigidBody2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();            
        }        
    }

    void Fire()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        animator.SetBool("Firing", true);
        animator.SetBool("Idle", false);
        rigidBody2D.velocity = Vector2.zero;
        yield return new WaitForSeconds(.5f);
        animator.SetBool("Firing", false);
        animator.SetBool("Idle", true);
    }
}
