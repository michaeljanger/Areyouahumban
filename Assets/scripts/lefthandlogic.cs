using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lefthandlogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onCollision (Collision other)
	{
		if(other.gameObject.tag == "object")
		{
			if(handcontroller.lefthandgrabbing==true)
			{
				other.transform.parent=this.transform;
				Debug.Log("grabbing left hand");
			}
			else
			{
				other.transform.parent=null;
				Debug.Log("not grabbing left hand");
			}
		}
	}
}
