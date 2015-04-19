using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JunkyBehavior : MonoBehaviour {

    private int hitCrazy = 3;
    private int hitDead = 5;
    private int hitCount;
    private Animator animator;
    private Rigidbody2D rigidBod;
    public AudioClip pain;
    public static event EventHandler OnKill; 
    
    // Use this for initialization
	void Start () {
        hitCount = 0;        
        animator = this.GetComponent<Animator>();
        rigidBod = this.GetComponent<Rigidbody2D>();        
	}
	
	// Update is called once per frame
	void Update () {
        CheckDead();
    }

    IEnumerator HitWait()
    {
        rigidBod.velocity = Vector2.zero;
        animator.SetBool("Hit", true);
        yield return new WaitForSeconds(.1f);
        animator.SetBool("Hit", false);
        CheckDead();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ball"))
        {
            hitCount++;
            //Destroy(collision.gameObject);
            StartCoroutine(HitWait());
            AudioSource.PlayClipAtPoint(pain, this.transform.position);
        }
    }

    void CheckDead()
    {
        if (hitCount == hitDead)
        {
            Dead();          
        }
        else if (hitCount == hitCrazy)
        {
            animator.SetBool("Crazy", true);   
        }
    }

    void Dead()
    {
        animator.SetBool("Dead", true);
        rigidBod.velocity = Vector2.zero;
        Destroy(this.gameObject);
        //StartCoroutine(FadeTo(this.gameObject.transform, 20f, 100f));

        if (OnKill != null)
        {
            OnKill(this.gameObject, EventArgs.Empty);
        }        
    }



    IEnumerator FadeTo(Transform tran, float aTime, float newX)
    {
        float x, y = 0f;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            x = this.transform.localPosition.x;
            y = this.transform.localPosition.y;
            tran.localPosition = new Vector3(Mathf.Lerp(x, x + newX, t), y, 0f);
            yield return null;
        }
    }

 
}
