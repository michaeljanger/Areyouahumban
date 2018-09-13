using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handcontroller : MonoBehaviour {
	public GameObject lefthand;

	public Animator handanim;

	public float leftstick_x;
	public float leftstick_y;
	public static bool lefthandgrabbing;
	public static bool righthandgrabbing;
	public bool lefthandy;
	public bool righthandy;
	public Vector3 upward = new Vector3(0f,1f,0f);
	public Vector3 downward = new Vector3(0f,-1f,0f);
	public bool leftbuttonstate;
	public bool rightbuttonstate;
	public static bool isholding;
	public static bool ispoking;
	public float grabtimer = 2f;

	// Use this for initialization
	void Start () {
		lefthandgrabbing = false;
		righthandgrabbing = false;
		leftbuttonstate = false;
		isholding = false;
		ispoking = false;

		//handmeshcol = GetComponent<MeshCollider>();
	}

	// Update is called once per frame
	void Update () {
		

		leftstick_x = Input.GetAxis("Mouse X"); //get mouse x value
		leftstick_y = Input.GetAxis("Mouse Y"); //get mouse y value
		lefthandy = lefthandgrabbing;
		if(handanim.GetCurrentAnimatorStateInfo(0).IsName("grab")&&isholding==false)
		{
			//Debug.Log("counting down  " + grabtimer);
			grabtimer -= Time.deltaTime;
			if(grabtimer < 0f)
			{
				handanim.Play("idle");
				isholding=false;
				lefthandgrabbing = false;
				grabtimer = 2f;

			}
		}
		else if (isholding==true)
		{
			grabtimer = 2f;
			if(grabtimer <1.5f);
			{

			}
		}
		//declare state
		if (Input.GetMouseButtonDown(0)) //grab state with left mouse button
		{
			leftbuttonstate = true;
			if(isholding==true)
			{
				//isholding=false;
				//lefthandgrabbing = false;
			}
			else
			{
				handanim.Play("ready");
			}
		
		}
		if (Input.GetMouseButtonUp(0)) //grab state with left mouse button
		{
			leftbuttonstate = false;
			if(isholding==false)
			{
				handanim.Play("grab");
				lefthandgrabbing = true;
			}
			else
			{
				handanim.Play("idle");
				isholding=false;
				lefthandgrabbing = false;
			}
		}
		if (Input.GetMouseButtonDown(1)) //grab state with left mouse button
		{
			rightbuttonstate = true;
			if(isholding==true)
			{
				//isholding=false;
				//lefthandgrabbing = false;
			}
			else
			{
				
			}

		}
		if (Input.GetMouseButtonUp(1)) //grab state with left mouse button
		{
			rightbuttonstate = false;
			if(isholding==false)
			{
				if(ispoking==false)
				{
				handanim.Play("poke");
				ispoking = true;

				}
				else
				{
				handanim.Play("idle");

					ispoking = false;
				}
			}
			else
			{

			}
		}


		var leftstickinput = new Vector3(leftstick_x*-1, 0, leftstick_y*-1); //get mouse position
	
		if(leftstickinput != Vector3.zero)
		{
			lefthand.transform.Translate(leftstickinput*Time.deltaTime*10);
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

	}
}
