using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppElements : MonoBehaviour {
	public GameObject[] sList;
	// Use this for initialization
	public GameObject testerD;


	void Start () {
	//GameObject d = sList [2].GetComponent<S_elements> ();

		 
		testerD = sList [1].GetComponent<S_elements> ().addons[2];

		Instantiate (testerD, transform.position, transform.rotation);


	//	testerD = Instantiate (d.addons[2], transform.position, transform.rotation);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
