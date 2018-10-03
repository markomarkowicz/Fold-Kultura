using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// rozstawia toysy by sprawdzić czy mają dobrze ustawione skale pozycje i rotacje

public class ToyCheckMachineScript : MonoBehaviour {
	public GameObject toyBase;
	public GameObject[] toyAddon;
	GameObject[] toyBaseHolder;
	GameObject[] toyAddonHolder ;
	float toyAngleAdd = 0;
	public float toyOffset = 2;


	// Use this for initialization
	void Start () {
		toyAddonHolder = new GameObject[toyAddon.Length];
		toyBaseHolder = new GameObject[toyAddon.Length];


		for (int i = 0; i < toyAddon.Length; i++) {
			toyBaseHolder [i] = Instantiate (toyBase, transform.position, transform.rotation)as GameObject;
			toyBaseHolder [i].transform.localPosition = new Vector3 (toyOffset*i, 0, 0);
			toyBaseHolder [i].transform.localEulerAngles = new Vector3 (0, 0+ toyAngleAdd, 0);


				toyAddonHolder [i] = Instantiate (toyAddon[i], transform.position, transform.rotation)as GameObject;
				toyAddonHolder [i].transform.localPosition = new Vector3 (toyOffset*i, 0, 0);
				toyAddonHolder [i].transform.localEulerAngles = new Vector3 (0, 0+ toyAngleAdd, 0);
		
		
		
		}



	}
	

}
