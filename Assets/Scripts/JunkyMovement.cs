using UnityEngine;
using System.Collections;

public class JunkyMovement : MonoBehaviour {

    private Rigidbody2D rigidBod;
    private Animator animator;
    public float speed;

    // Use this for initialization
	void Start () {
	    rigidBod = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!animator.GetBool("Dead"))
        {
            rigidBod.velocity = Vector3.left * speed;
        }
	}
}
