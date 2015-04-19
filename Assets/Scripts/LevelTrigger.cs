using UnityEngine;
using System;
using System.Collections;

public class LevelTrigger : MonoBehaviour {

    public bool lastLevel;
    public static event EventHandler OnGameOver;
    public static event EventHandler OnLevelOver;
    
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
            if (!lastLevel)
            {
                if (OnLevelOver != null)
                {
                    OnLevelOver(null, EventArgs.Empty);
                }
            }
            else
            {
                if (OnGameOver != null)
                {
                    OnGameOver(null, EventArgs.Empty);
                }
            }
        }
    }


}
