using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour {
	public bool sticking;
	public Vector3 size;
	public Rigidbody rigid;
	public Collider collider;
	public GameObject player;
	public Vector3 offset = new Vector3(0f,0f,0f);

	// Use this for initialization
	void Start () {

		sticking = false;
		size = this.transform.localScale;
		rigid = this.GetComponent<Rigidbody>();
		collider = this.GetComponent<SphereCollider>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update () {
		if ((handcontroller.lefthandgrabbing==true||handcontroller.righthandgrabbing==true)&&sticking == true)
		{
			//Destroy (this.GetComponent<Rigidbody>());
			//Destroy (this.GetComponent<SphereCollider>());
			//transform.rotation = player.transform.localRotation;
			transform.position = player.transform.position-new Vector3(0f,0.25f,0f);
			handcontroller.isholding = true;
		}
		else
			if (handcontroller.lefthandgrabbing==false&&handcontroller.righthandgrabbing==false&&sticking==true)
		{
			//transform.parent = null;
			sticking = false;
			this.GetComponent<Rigidbody>().useGravity = true;
			this.GetComponent<Rigidbody>().isKinematic = false;
			this.transform.localScale = size;
			//gameObject.AddComponent<SphereCollider>();

		}
	}
	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player")&&handcontroller.lefthandgrabbing==true&&sticking==false)
		{
			//transform.parent = other.transform; //parent object to player
			this.GetComponent<Rigidbody>().useGravity = false;
			this.GetComponent<Rigidbody>().isKinematic = true;
			this.transform.localScale = size;
			Debug.Log("Sticking!");
			sticking = true;

		}

	}
}
