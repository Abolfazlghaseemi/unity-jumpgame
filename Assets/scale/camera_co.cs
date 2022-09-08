using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_co : MonoBehaviour {
    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {

            transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        }
		
	}
}
