using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPrototypeScript : MonoBehaviour {
	/*

PIVOTY!
Canvas nie jest responsywny	
Inne rozdzielczości/ proporcje a znikanie toysów
FONT
	



	*/
	public Text textRadi;

	public Transform toysGround;
	Animator anim;
	public GameObject[] toyPlaceHolders;
	Transform[] toyHolder;
	[Range(8f,18f)]
	public float toyRadiusWheel = 12f;
	private float setToyRadiusWheel;
	public Transform radiusCenter;
	public AnimationCurve animCurve;
	// Use this for initialization
	void Start () {

		anim = gameObject.GetComponent<Animator> ();
		toyHolder = new Transform[toyPlaceHolders.Length];
		for (int i = 0; i < toyPlaceHolders.Length; i++) {
			toyHolder [i] = toyPlaceHolders [i].transform.Find ("ToyPlaceHolder");
		}
			setToyRadiusWheel = toyRadiusWheel;

		textRadi.text = "radius = 14.0";
	}
	
	// Update is called once per frame
	void Update () {
		if (toyRadiusWheel != setToyRadiusWheel) {
		
			RadiusChange ();
			setToyRadiusWheel = toyRadiusWheel;

		}
	
			}


	public void NextBtn(){
		anim.SetTrigger ("Next");
		Debug.Log ("Next Button");
	}

	public void BackBtn(){
		Debug.Log ("Back Button");
	}

	public void LeftArrowBtn(){
		Debug.Log ("Left Arrow Button");
	}

	public void RightArrowBtn(){
		Debug.Log ("Right Arrow Button");
	}

	public void RadiusChange(){
		Debug.Log ("RadiusChange");
		for (int j = 0; j < toyPlaceHolders.Length; j++) {
			toyHolder [j].localPosition = new Vector3 (0, 0, setToyRadiusWheel);
			textRadi.text = "radius = "+((Mathf.Round(setToyRadiusWheel*10f))/10f).ToString();	
			toysGround.localScale = new Vector3 ((setToyRadiusWheel * 2 + 2), 0.02f, (setToyRadiusWheel * 2 + 2));
		
		}
		radiusCenter.localPosition = new Vector3 (0, 0, setToyRadiusWheel);
	}
	public void RadiusSlider(float newRadius){
		setToyRadiusWheel = newRadius;
	}

}
