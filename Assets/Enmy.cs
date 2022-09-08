using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enmy : MonoBehaviour {
    public float speed;
    public bool Go_Left, Go_Right;
    public float Scale_x;
    public float xpos_Right, xpos_Left;

	// Use this for initialization
	void Start () {
        Scale_x = transform.localScale.x;
        int My_Random = Random.Range(0, 2);
        switch (My_Random)
        {
            case 0:
                {
                Go_Left = true;
                Go_Right=false;
                break;
        }
        case 1:
            {
            Go_Left=false;
            Go_Right=true;
            break;
        }
            default:
        break;
    }
}
	
	// Update is called once per frame
	void Update () {
        if (Go_Left)
        {
            transform.localScale = new Vector3(Scale_x, transform.localScale.y, transform.localScale.z);
            transform.Translate(new Vector2(-speed*Time.deltaTime,0));
            
        }
        if (Go_Right)
        {
            transform.localScale = new Vector3(-Scale_x, transform.localScale.y, transform.localScale.z);
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
        }
            if (transform.position.x > xpos_Right)
            {
                Go_Left = true;
                Go_Right = false;
            }
            if (transform.position.x< xpos_Left)
            {
                Go_Left = false;
                Go_Right = true;
            }
        }
		
	}
