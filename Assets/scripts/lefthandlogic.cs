using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lefthandlogic : MonoBehaviour {
	public static bool pickingupobj;
	// Use this for initialization
	void Start () {
		pickingupobj = false;
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
				pickingupobj=true;
				Debug.Log("grabbing left hand");
			}
			else
			{
				other.transform.parent=null;
				pickingupobj=false;
				Debug.Log("not grabbing left hand");
			}
		}
	}
}
