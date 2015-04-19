using UnityEngine;
using System.Collections;

public class PappyMovement : MonoBehaviour {

    public int speed;
    private Animator animator;
    
    // Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        

	}

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow) && !animator.GetBool("Firing"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.right * speed;
        }

        animator.SetInteger("Speed", (int)GetComponent<Rigidbody2D>().velocity.magnitude);
        animator.SetBool("Idle", (int)GetComponent<Rigidbody2D>().velocity.magnitude == 0);
    }
}
