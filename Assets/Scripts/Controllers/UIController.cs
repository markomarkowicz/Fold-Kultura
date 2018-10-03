using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
	public static UIController Instance;
	
	public GameObject play, next, back, rightArrow, leftArrow;

	void Awake()
	{
		if (Instance != null)
		{
			Instance = this;
		}
		else
		{
			Destroy(Instance);
		}
	}

	public void PlayButton()
	{
		
	}
	
	public void NextButton()
	{
		
	}
	
	public void BackButton()
	{
		
	}

	public void RightArrow()
	{
		
	}
	
	public void LeftArrow()
	{
		
	}
	
	
}
