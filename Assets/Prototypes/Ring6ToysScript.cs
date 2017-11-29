using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring6ToysScript : MonoBehaviour {
	public GameObject[] toy;
	public Transform[] toyHolder;
	GameObject[] toyPrefabControl;
	public float curveSpeed = 1f;
	public AnimationCurve curveToy;
	// Use this for initialization
	int j;
	float backAngle = -60f;
	float nextAngle = 60f;
	bool animationRun = false;
	float tableRotation;


	void Start () {
		Debug.Log ("chuj");	
		toyPrefabControl = new GameObject[toyHolder.Length];
		tableRotation = 0;
		gameObject.transform.localEulerAngles = new Vector3(0, tableRotation, 0);

		for (int i = 0; i < toyHolder.Length; i++) {
		//	Debug.Log ("j jest kurwa" + j);
			j = i % toy.Length;
		//	Debug.Log ("j jest rowne" + j);

			toyPrefabControl [i] = Instantiate (toy [j], transform.position, transform.rotation,toyHolder[i].transform)as GameObject;
			toyPrefabControl [i].transform.localPosition = new Vector3 (0, 0, 0);
			toyPrefabControl [i].transform.localEulerAngles = new Vector3 (0, 70, 0);
			toyPrefabControl [i].transform.localScale = new Vector3 (1, 1, 1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("dupa");	

		if (Input.GetKeyDown ("b")) {

			StartCoroutine ("RotationMinus");
		}
		if (Input.GetKeyDown ("n")) {
		
			StartCoroutine ("RotationPlus");
		}
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



	IEnumerator RotationPlus(){
		animationRun = true;
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
		float oldTableRotation = tableRotation;
		float iTime = 0;
		while (iTime < 1) {
			iTime += curveSpeed*Time.deltaTime;
			tableRotation = Mathf.Lerp(oldTableRotation,oldTableRotation-60, curveToy.Evaluate(iTime));
			gameObject.transform.localEulerAngles = new Vector3(0, tableRotation, 0);
			yield return null;
		
		}
		tableRotation = oldTableRotation - 60;
		yield return null;
		animationRun = false;
	}



}
