using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
	public static MainController Instance;
	
	private MenuStates state = MenuStates.Start;
	[SerializeField]private Camera viewCamera;
	
	

	private void Awake()
	{
		if (Instance != null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
	
}

public enum MenuStates
{
	Start,
	ChooseModel,
	ChooseTexture,
	ViewModel
}
