using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToysMenago : MonoBehaviour {

	public ToyElements[] toysSC;
	GameObject[] toysSCRun;
	public GameObject[] paripati;



	// Use this for initialization
	void Start () {

		toysSC [1].ToyOn (0,paripati[0]);
		toysSC [0].ToyOn (2,paripati[1]);



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
