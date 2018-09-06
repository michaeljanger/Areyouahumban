using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handcontroller : MonoBehaviour {
	public GameObject lefthand;
	public GameObject righthand;
	public GameObject finger1;
	public GameObject finger2;
	public GameObject thumb;

	public float rightstick_x;
	public float leftstick_x;
	public float rightstick_y;
	public float leftstick_y;
	public static bool lefthandgrabbing;
	public static bool righthandgrabbing;
	public bool lefthandy;
	public bool righthandy;
	public Vector3 upward = new Vector3(0f,1f,0f);
	public Vector3 downward = new Vector3(0f,-1f,0f);
	// Use this for initialization
	void Start () {
		lefthandgrabbing = false;
		righthandgrabbing = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		rightstick_x = Input.GetAxis("rightstick_x");
		rightstick_y = Input.GetAxis("rightstick_y");
		leftstick_x = Input.GetAxis("Mouse X");
		leftstick_y = Input.GetAxis("Mouse Y");
		lefthandy = lefthandgrabbing;
		righthandy = righthandgrabbing;
	
		var leftstickinput = new Vector3(leftstick_x, 0, leftstick_y);
		var rightstickinput = new Vector3(rightstick_x, 0, rightstick_y);
		if(leftstickinput != Vector3.zero)
		{
			lefthand.transform.Translate(leftstickinput*Time.deltaTime*10);
		}
		if(rightstickinput != Vector3.zero)
		{
			righthand.transform.Translate(rightstickinput*Time.deltaTime*10);
		}
		if(Input.GetKey("w"))
		{
			lefthand.transform.Translate(upward*Time.deltaTime*2);
		}
		if(Input.GetKey("s"))
		{
			lefthand.transform.Translate(upward*Time.deltaTime*-2);
		}
		//lefthand.transform.Translate(downward*Time.deltaTime*1);
		if(Input.GetMouseButton(1))
		{
			Debug.Log("button pressed!");
			lefthandgrabbing = true;
			thumb.transform.localEulerAngles = new Vector3(0f,46.39f,0f);
		}
		else
		{
			lefthandgrabbing = false;
			thumb.transform.localEulerAngles = new Vector3(38f,46.39f,0f);
		}
		if(Input.GetMouseButton(0))
		{
			Debug.Log("button pressed!");
			righthandgrabbing = true;
			finger1.transform.localEulerAngles = new Vector3(0f,0f,0f);
			finger2.transform.localEulerAngles = new Vector3(0f,0f,0f);
		}
		else
		{
			righthandgrabbing = false;
			finger1.transform.localEulerAngles = new Vector3(46f,0f,0f);
			finger2.transform.localEulerAngles = new Vector3(46f,0f,0f);
		}

	}

}
