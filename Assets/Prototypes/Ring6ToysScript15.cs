using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//To Do

// Touch only in center
// Limit Angle
// Change Spawn Place



public class Ring6ToysScript15 : MonoBehaviour {
	public GameObject[] toy;
	public GameObject toyBase;

	public float toyAngleAdd;
	public Transform[] toyHolder;
	GameObject[] toyBasePrefabControl;
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
	public int rotGear = 0;
	public int toyGear = 0;
	public Material infoMat;
	int rg;
	int rotPlaceOffset = 2;
	int rotGearLength = 6;
	public int toyHPos ;
	int toyGearNr; // index toya wrzucanego po next lub back;

	public GameObject cameraPivot;
	public float screenW_Low; 
	public float screenW_Hi;
	bool touchScreenOn = false; 
	float toyRot; 
	float cameraRot;
	float lastClickX;
	float lastClickY;
	int mouseAreaCheck;



	void Start () {
		screenW_Low = Screen.width*0.25f;
		screenW_Hi = Screen.width*0.75f;

		//Debug.Log ("Screen.width= " + Screen.width); 
		toyPrefabControl = new GameObject[toyHolder.Length];
		toyBasePrefabControl = new GameObject[toyHolder.Length];
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
	
			// % toy.Length;
		
				toyPrefabControl [i] = Instantiate (toy [i], transform.position, transform.rotation, toyHolder [i].transform)as GameObject;
				toyPrefabControl [i].transform.localPosition = new Vector3 (0, 0, 0);
				toyPrefabControl [i].transform.localEulerAngles = new Vector3 (0, 70+ toyAngleAdd, 0);
				toyPrefabControl [i].transform.localScale = new Vector3 (1, 1, 1);

			toyBasePrefabControl[i]= Instantiate (toyBase, transform.position, transform.rotation, toyHolder [i].transform)as GameObject;
			toyBasePrefabControl [i].transform.localPosition = new Vector3 (0, 0, 0);
			toyBasePrefabControl [i].transform.localEulerAngles = new Vector3 (0, 70+ toyAngleAdd, 0);
			toyBasePrefabControl [i].transform.localScale = new Vector3 (1, 1, 1);
		
		}

		for (int i = 0; i <3; i++) {

			int j = 5 - i;
			k = toy.Length-1-i;


			toyPrefabControl [j] = Instantiate (toy [k], transform.position, transform.rotation, toyHolder [j].transform)as GameObject;
			toyPrefabControl [j].transform.localPosition = new Vector3 (0, 0, 0);
			toyPrefabControl [j].transform.localEulerAngles = new Vector3 (0, 70+ toyAngleAdd, 0);
			toyPrefabControl [j].transform.localScale = new Vector3 (1, 1, 1);

			toyBasePrefabControl[j]= Instantiate (toyBase, transform.position, transform.rotation, toyHolder [j].transform)as GameObject;
			toyBasePrefabControl [j].transform.localPosition = new Vector3 (0, 0, 0);
			toyBasePrefabControl [j].transform.localEulerAngles = new Vector3 (0, 70+ toyAngleAdd, 0);
			toyBasePrefabControl [j].transform.localScale = new Vector3 (1, 1, 1);

		
		}

	}

	void OnGui(){
	
		GUI.Label (new Rect(50, 50, 200,70),mouseAreaCheck.ToString());
	}
	
	void Update () {
		
	
		if (Input.GetMouseButtonDown (0)) {
			Vector3 mousePosCheck = Input.mousePosition;



			Vector3 mousePos;

			if (mousePosCheck.x < screenW_Low && mousePosCheck.x > screenW_Hi) {
				mousePos = Input.mousePosition;
				mouseAreaCheck = 0;
			}
				if (mousePosCheck.x > screenW_Low && mousePosCheck.x < screenW_Hi) {
					mousePos = Input.mousePosition;
					mouseAreaCheck = 2;

				lastClickX = mousePos.x;
				lastClickY = mousePos.y;
			}
		}


		if (Input.GetMouseButton(0)) {
			
		

			Vector3 mousePos = Input.mousePosition;
			//Debug.Log (mousePos.x);
			if (mouseAreaCheck == 0 && mousePos.x > screenW_Low && mousePos.x < screenW_Hi) {
				mouseAreaCheck = 1;
			}
			if(mouseAreaCheck == 1 && mousePos.x > screenW_Low && mousePos.x < screenW_Hi) {
				Debug.Log ("jeden na dwa");
				lastClickX = mousePos.x;
				lastClickY = mousePos.y;
				mouseAreaCheck = 2;
			}
			if (mouseAreaCheck == 2) {
				toyRot = mousePos.x - lastClickX;
				cameraRot = mousePos.y - lastClickY;
			}
		//	MouseTrackingUpd ();
		
		}

		if (Input.GetMouseButtonUp (0)) {
		
			StartCoroutine ("ResetMouseRot");
			mouseAreaCheck = 0;
		}


		//napis.transform.localEulerAngles = new Vector3 (0, toyRot, 0);
		toyHolder[rotGear].transform.localEulerAngles = new Vector3 (0, -toyRot/1.5f, 0);
		cameraPivot.transform.localEulerAngles = new Vector3 (-cameraRot/5, 0, 0);




		if (Input.GetKeyDown ("b")) {

			BackArrow ();
		}
		if (Input.GetKeyDown ("n")) {
		
			NextArrow ();
		}
	}


	void MouseTrackingUpd(){
		
	}


	public void NextArrow(){
		if (!animationRun) {
			StartCoroutine ("RotationPlus");
				}
	}

	public void BackArrow(){
		if (!animationRun) {
			StartCoroutine ("RotationMinus");
		}
		}



	IEnumerator ResetMouseRot(){
		float oldToyRot = toyRot;
		float oldCameraRot = cameraRot;
		//float oldTableRotation = tableRotation;
		float iTime = 0;
		while (iTime < 1) {
			iTime += curveSpeed * Time.deltaTime;
			toyRot = Mathf.Lerp (oldToyRot, 0, curveToy.Evaluate (iTime));
			cameraRot = Mathf.Lerp (oldCameraRot, 0, curveToy.Evaluate (iTime));
			//	toyHolder[1].transform.localEulerAngles = new Vector3(0, toyRot, 0);
			yield return null;

	
		}
	}




	IEnumerator RotationPlus(){
		animationRun = true;
		rotGear++;
		toyGear++;

		if (rotGear >5) {
			rotGear = 0;
		}
		if (toyGear > toy.Length - 1) {
			toyGear = 0;
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
		NextToysChange ();
		yield return null;
		animationRun = false;
	}

	IEnumerator RotationMinus(){
		animationRun = true;
		rotGear--;
		toyGear--;
		if (rotGear < 0) {
			rotGear = 5;
		}

		if (toyGear <0 ) {
			toyGear = toy.Length - 1;
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
		BackToysChange ();
		//Destroy(toyPrefabControl[(rotGear -2)%6]);

		yield return null;
		animationRun = false;
	}

	public void NextToysChange ()
	{
		//toyPrefabControl [3].Destroy (Get);
		//		

		toyHPos = (rotGearLength + rotGear + rotPlaceOffset) % (rotGearLength); 



		toyGearNr = (toyGear + 2) % toy.Length;

		//if (rotGear < 2) {
		//	rg = rotGear + 4; 

		//	Debug.Log ("rotGear <2 +4 = " + rotGear + 4);
		Destroy (toyHolder [toyHPos].transform.GetChild (0).gameObject);
		Destroy (toyHolder [toyHPos].transform.GetChild (1).gameObject);
		//toyPrefabControl [rotGear + 4] = Instantiate(

		toyPrefabControl[toyHPos] = Instantiate(toy[toyGearNr],transform.position, transform.rotation,toyHolder[toyHPos])as GameObject;
		toyPrefabControl[toyHPos].transform.localPosition = new Vector3 (0, 0, 0);
		toyPrefabControl[toyHPos].transform.localEulerAngles = new Vector3 (0, 70+toyAngleAdd, 0);
		toyPrefabControl[toyHPos].transform.localScale = new Vector3 (1, 1, 1);
	//	toyPrefabControl[toyHPos].transform.GetComponentInChildren<Renderer> ().material = infoMat;

		toyBasePrefabControl[toyHPos]= Instantiate (toyBase, transform.position, transform.rotation, toyHolder [toyHPos].transform)as GameObject;
		toyBasePrefabControl [toyHPos].transform.localPosition = new Vector3 (0, 0, 0);
		toyBasePrefabControl [toyHPos].transform.localEulerAngles = new Vector3 (0, 70+ toyAngleAdd, 0);
		toyBasePrefabControl [toyHPos].transform.localScale = new Vector3 (1, 1, 1);




		/*
		} else {
			rg = rotGear - 1;

			Debug.Log ("else rotGear"+rotGear+ " "+ rg);
			Destroy (toyHolder [rg].transform.GetChild (0).gameObject);


	toyPrefabControl[rg] = Instantiate(toy[toyGear -1],transform.position, transform.rotation,toyHolder[rg])as GameObject;
			toyPrefabControl[ rg].transform.localPosition = new Vector3 (0, 0, 0);
			toyPrefabControl[ rg].transform.localEulerAngles = new Vector3 (0, 70, 0);
			toyPrefabControl[ rg].transform.localScale = new Vector3 (1, 1, 1);

		}*/


	}
	public void BackToysChange ()
	{
		//toyPrefabControl [3].Destroy (Get);
//		

		toyHPos = (rotGearLength + rotGear - rotPlaceOffset) % (rotGearLength); 

		toyGearNr = (toy.Length + toyGear - rotPlaceOffset) % (toy.Length);



		//if (rotGear < 2) {
		//	rg = rotGear + 4; 

		//	Debug.Log ("rotGear <2 +4 = " + rotGear + 4);
		Destroy (toyHolder [toyHPos].transform.GetChild(0).gameObject);
		Destroy (toyHolder [toyHPos].transform.GetChild(1).gameObject);

			//toyPrefabControl [rotGear + 4] = Instantiate(

		toyPrefabControl[toyHPos] = Instantiate(toy[toyGearNr],transform.position, transform.rotation,toyHolder[toyHPos])as GameObject;
		toyPrefabControl[toyHPos].transform.localPosition = new Vector3 (0, 0, 0);
		toyPrefabControl[toyHPos].transform.localEulerAngles = new Vector3 (0, 70+ toyAngleAdd, 0);
		toyPrefabControl[toyHPos].transform.localScale = new Vector3 (1, 1, 1);
		//toyPrefabControl[toyHPos].transform.GetComponentInChildren<Renderer> ().material = infoMat;


		toyBasePrefabControl[toyHPos]= Instantiate (toyBase, transform.position, transform.rotation, toyHolder [toyHPos].transform)as GameObject;
		toyBasePrefabControl [toyHPos].transform.localPosition = new Vector3 (0, 0, 0);
		toyBasePrefabControl [toyHPos].transform.localEulerAngles = new Vector3 (0, 70+ toyAngleAdd, 0);
		toyBasePrefabControl [toyHPos].transform.localScale = new Vector3 (1, 1, 1);
			
		
		/*
		} else {
			rg = rotGear - 1;

			Debug.Log ("else rotGear"+rotGear+ " "+ rg);
			Destroy (toyHolder [rg].transform.GetChild (0).gameObject);


	toyPrefabControl[rg] = Instantiate(toy[toyGear -1],transform.position, transform.rotation,toyHolder[rg])as GameObject;
			toyPrefabControl[ rg].transform.localPosition = new Vector3 (0, 0, 0);
			toyPrefabControl[ rg].transform.localEulerAngles = new Vector3 (0, 70, 0);
			toyPrefabControl[ rg].transform.localScale = new Vector3 (1, 1, 1);

		}*/


	}



}






