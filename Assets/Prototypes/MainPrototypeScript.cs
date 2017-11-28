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

	private int page = 0;
	public GameObject nextOnBtn, nextOffBtn, BackOnBtn, BackOffBtn;
	public GameObject[] pageOnBtn;
	public GameObject[] pageOffBtn;


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
		nextPage();
		PageCase ();

	}







	public void BackBtn(){
		Debug.Log ("Back Button");
		prevPage ();
		PageCase ();
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

	public void nextPage(){
		if (page < 3) {
			page++;
		}

		Debug.Log (page);
	}

	public void prevPage(){
		if (page > 0) {
			page--;
		}
		Debug.Log (page);


	}

	void PageCase(){
	
		switch (page) {
		case 0:
			nextOnBtn.SetActive (true);
			nextOffBtn.SetActive (false);

			BackOnBtn.SetActive (false);
			BackOffBtn.SetActive (true);

			pageOnBtn [0].SetActive (true);
			pageOnBtn [1].SetActive (false);
			pageOnBtn [2].SetActive (false);
			pageOnBtn [3].SetActive (false);
			pageOffBtn [0].SetActive (false);
			pageOffBtn [1].SetActive (true);
			pageOffBtn [2].SetActive (true);
			pageOffBtn [3].SetActive (true);

			break;
		case 1:
			nextOnBtn.SetActive (true);
			nextOffBtn.SetActive (false);

			BackOnBtn.SetActive (true);
			BackOffBtn.SetActive (false);
			pageOnBtn [0].SetActive (false);
			pageOnBtn [1].SetActive (true);
			pageOnBtn [2].SetActive (false);
			pageOnBtn [3].SetActive (false);

			pageOffBtn [0].SetActive (true);
			pageOffBtn [1].SetActive (false);
			pageOffBtn [2].SetActive (true);
			pageOffBtn [3].SetActive (true);
			break;
		case 2:
			nextOnBtn.SetActive (true);
			nextOffBtn.SetActive (false);


			BackOnBtn.SetActive (true);
			BackOffBtn.SetActive (false);

			pageOnBtn [0].SetActive (false);
			pageOnBtn [1].SetActive (false);
			pageOnBtn [2].SetActive (true);
			pageOnBtn [3].SetActive (false);
			pageOffBtn [0].SetActive (true);
			pageOffBtn [1].SetActive (true);
			pageOffBtn [2].SetActive (false);
			pageOffBtn [3].SetActive (true);
			break;
		case 3:
			
			nextOnBtn.SetActive (false);
			nextOffBtn.SetActive (true);


			BackOnBtn.SetActive (true);
			BackOffBtn.SetActive (false);

			pageOnBtn [0].SetActive (false);
			pageOnBtn [1].SetActive (false);
			pageOnBtn [2].SetActive (false);
			pageOnBtn [3].SetActive (true);
			pageOffBtn [0].SetActive (true);
			pageOffBtn [1].SetActive (true);
			pageOffBtn [2].SetActive (true);
			pageOffBtn [3].SetActive (false);
			break;

		default:
			Debug.Log ("default");
			break;
		}
	}




}
