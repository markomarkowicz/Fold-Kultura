using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring6ToysScript15 : MonoBehaviour {
	public GameObject[] toy;
	public Transform[] toyHolder;
	GameObject[] toyPrefabControl;
	GameObject[] nrPrefabControl;

	public float curveSpeed = 1f;
	public AnimationCurve curveToy;
	// Use this for initialization
	int k;
	float backAngle = -60f;
	float nextAngle = 60f;
	bool animationRun = false;
	float tableRotation;
	GameObject d;
	public int rotGear = 1;
	public Material infoMat;

	void Start () {
		Debug.Log ("chuj");	
		toyPrefabControl = new GameObject[toyHolder.Length];
		nrPrefabControl = new GameObject[toyHolder.Length];

		tableRotation = 0;
		gameObject.transform.localEulerAngles = new Vector3(0, tableRotation, 0);


		//znaczniki małe zielone cyfry 
		/*for (int i = 0; i < 6; i++) {
			nrPrefabControl[i] = Instantiate (toy [i], transform.position, transform.rotation, toyHolder [i].transform)as GameObject;
			nrPrefabControl [i].transform.localPosition = new Vector3 (-0.3f, 0, 1);
			nrPrefabControl [i].transform.localEulerAngles = new Vector3 (0, 70, -70);
			nrPrefabControl [i].transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
			nrPrefabControl [i].transform.GetComponentInChildren<Renderer> ().material = infoMat;

		}
*/


		for (int i = 0; i < 3; i++) {
		//	Debug.Log ("j jest kurwa" + j);
			// % toy.Length;
		//	Debug.Log ("j jest rowne" + j);
				toyPrefabControl [i] = Instantiate (toy [i], transform.position, transform.rotation, toyHolder [i].transform)as GameObject;
				toyPrefabControl [i].transform.localPosition = new Vector3 (0, 0, 0);
				toyPrefabControl [i].transform.localEulerAngles = new Vector3 (0, 70, 0);
				toyPrefabControl [i].transform.localScale = new Vector3 (1, 1, 1);


		
		}

		for (int i = 0; i <3; i++) {
			//Debug.Log ("koko" + i);
			int j = 5 - i;
			k = toy.Length-1-i;


			toyPrefabControl [j] = Instantiate (toy [k], transform.position, transform.rotation, toyHolder [j].transform)as GameObject;
			toyPrefabControl [j].transform.localPosition = new Vector3 (0, 0, 0);
			toyPrefabControl [j].transform.localEulerAngles = new Vector3 (0, 70, 0);
			toyPrefabControl [j].transform.localScale = new Vector3 (1, 1, 1);

		
		
		}

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("dupa");	

		if (Input.GetKeyDown ("b")) {

			BackArrow ();
		}
		if (Input.GetKeyDown ("n")) {
		
			NextArrow ();
		}
	}

	public void NextArrow(){

		if (!animationRun) {
			
			StartCoroutine ("RotationPlus");
		}
	}

	public void BackArrow(){
		if (!animationRun) {
			BackToysChange ();
			StartCoroutine ("RotationMinus");
		}
		}



	IEnumerator RotationPlus(){
		animationRun = true;
		rotGear++;
		if (rotGear >5) {
			rotGear = 0;
		}

		float oldTableRotation = tableRotation;
		float iTime = 0;
		while (iTime < 1) {
			iTime += curveSpeed*Time.deltaTime;
			tableRotation = Mathf.Lerp(oldTableRotation,oldTableRotation+60, curveToy.Evaluate(iTime));
			gameObject.transform.localEulerAngles = new Vector3(0, tableRotation, 0);
			yield return null;

		}
		tableRotation = oldTableRotation + 60;
		yield return null;
		animationRun = false;
	}

	IEnumerator RotationMinus(){
		animationRun = true;
		rotGear--;
		if (rotGear < 0) {
			rotGear = 5;
		}
		float oldTableRotation = tableRotation;
		float iTime = 0;
		while (iTime < 1) {
			iTime += curveSpeed*Time.deltaTime;
			tableRotation = Mathf.Lerp(oldTableRotation,oldTableRotation-60, curveToy.Evaluate(iTime));
			gameObject.transform.localEulerAngles = new Vector3(0, tableRotation, 0);
			yield return null;
		
		}
		tableRotation = oldTableRotation - 60;

		//Destroy(toyPrefabControl[(rotGear -2)%6]);

		yield return null;
		animationRun = false;
	}


	public void BackToysChange(){
		//toyPrefabControl [3].Destroy (Get);
//		Destroy(toyPrefabControl [rotGear  -3].transform.GetChild(0).gameObject);
	
	}


	}






