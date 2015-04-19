using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float followX;
    public float followY;

    private Transform _t;

    void Awake()
    {
        //camera.orthographicSize = ((Screen.height / 1.0f) / 100f);
    }

    // Use this for initialization
    void Start()
    {
        _t = target.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_t)
            transform.position = new Vector3(_t.position.x + followX, _t.position.y + followY, transform.position.z);
    }
}
