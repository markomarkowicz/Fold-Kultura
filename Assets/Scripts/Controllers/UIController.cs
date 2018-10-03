using Interfaces;
using UnityEngine;

namespace Controllers
{
	public class UiController : MonoBehaviour
	{
		public static UiController Instance;
	
		[SerializeField] private GameObject _play, _next, _back, _rightArrow, _leftArrow; 

		void Awake()
		{
			if (Instance == null)
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

		public void SetViewFor(object view)
		{
			Debug.Log("SetViewFor");
			_rightArrow.SetActive(view is IArrowButtons);
			_leftArrow.SetActive(view is IArrowButtons);
			_next.SetActive(view is INavigateButtons);
			_back.SetActive(view is INavigateButtons);
			_play.SetActive(view is IPlayButton);
		}
	
	}
}
