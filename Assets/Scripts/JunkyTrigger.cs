using UnityEngine;
using System.Collections;

public class JunkyTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Player"))
        {
            SpawnJunky();
        }
    }

    void SpawnJunky()
    {
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        Vector3 justOffCamera = new Vector3(mainCamera.transform.position.x + 25f, -3.4f, 0f);
        GameObject junky = Resources.Load("Junky") as GameObject;
        Instantiate(junky, justOffCamera, Quaternion.identity);
    }
}
