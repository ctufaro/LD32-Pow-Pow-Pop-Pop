using UnityEngine;
using System.Collections;

public class PappyFire : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FireBall(AudioClip boom)
    {
        if (boom)
        {
            AudioSource.PlayClipAtPoint(boom, this.gameObject.transform.position);
        }

        Rigidbody2D tennisPrefab;
        GameObject puff = Resources.Load("puff") as GameObject;
        GameObject tennis = Resources.Load("tennis") as GameObject;
        Vector3 moveVector;

        Instantiate(puff, new Vector3(this.transform.position.x+8.06f, this.transform.position.y+1.28f, 0f), Quaternion.identity);

        moveVector = new Vector3(this.transform.position.x + 8.06f, this.transform.position.y + 1.28f - 0.213f, 0f);
        tennisPrefab = Instantiate(tennis.GetComponent<Rigidbody2D>(), moveVector, Quaternion.identity) as Rigidbody2D;
        tennisPrefab.AddForce(transform.right * 2.5f);

        if (tennisPrefab)
        {
            Destroy(tennisPrefab.gameObject, 2f);
        }
    }
}
