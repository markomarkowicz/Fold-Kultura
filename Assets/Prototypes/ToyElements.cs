using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyElements : MonoBehaviour {

	public GameObject toyBase;
	GameObject toyBaseR;
	public GameObject toyAddon;
	public Material[] toyMaterila;



	// Use this for initialization
	void Start () {
	


	}

	public void ToyOn(int colMat,GameObject toyParent){
		Instantiate (toyBase, toyParent.transform.position, toyParent.transform.rotation, toyParent.transform);
		Instantiate (toyAddon, toyParent.transform.position, toyParent.transform.rotation, toyParent.transform);
		toyBase.GetComponentInChildren<Renderer> ().material = toyMaterila [colMat];
		toyAddon.GetComponentInChildren<Renderer> ().material = toyMaterila [colMat];
	
	
	
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}
