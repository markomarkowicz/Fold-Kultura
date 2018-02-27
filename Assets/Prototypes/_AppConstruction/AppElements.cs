using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppElements : MonoBehaviour {
	public GameObject[] sList;

	// Use this for initialization
	public GameObject testerD;


	void Start () {
	//GameObject d = sList [2].GetComponent<S_elements> ();

		 
	//	testerD = sList [2].GetComponent<S_elements> ().addons[1];

	//	Instantiate (testerD, transform.position, transform.rotation);


	//	testerD = Instantiate (d.addons[2], transform.position, transform.rotation);

	}


	void WrzucToysa (GameObject toyParent, GameObject[] toySet,int tb,int toyadd,int toyMaterial){
		GameObject toyBase, toyAddon, toyColor;


		toyBase = toySet[tb].GetComponent<S_elements> ().baseModel;
	//	toyMaterial = toySet [tb].GetComponent<S_elements> ().matToys;
		Instantiate (toyBase, testerD.transform.position, testerD.transform.rotation, testerD.transform);
	//	toyMaterial = GetComponentInChildren<Material> ();
	//	toyMaterial = 
		toyBase.transform.localPosition = Vector3.zero;

		toyAddon = toySet [tb].GetComponent<S_elements> ().addons [toyadd];
		Instantiate (toyAddon, testerD.transform.position, testerD.transform.rotation, testerD.transform);	





	
	}






	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("k")){
			WrzucToysa (testerD, sList, 2, 2, 1);
		}
	}
}	
