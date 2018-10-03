using System.Collections;
using System.Collections.Generic;
using MenuViews;
using UnityEngine;

namespace Controllers
{
	public class MainController : MonoBehaviour
	{
		public static MainController Instance;
	
		private MenuViews _currentViewEnum = MenuViews.Start;
		private BaseMenuView _currentView;

		private Dictionary<MenuViews, BaseMenuView> _views;

		
		[SerializeField]private Camera _viewCamera;

		[SerializeField]private MainMenuView _mainMenuView;
	
	
		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				Destroy(gameObject);
			}
		}

		private void Start()
		{
			Init();
		}

		void Init()
		{
			Debug.Log("Init");
			_views = new Dictionary<MenuViews, BaseMenuView>()
			{
				{MenuViews.Start,_mainMenuView}
			};
			ShowView(MenuViews.Start);
		}
		
		public void ShowView(MenuViews view)
		{
			if (!_views.ContainsKey(view)) return;
			if (_currentView != null)
				_currentView.Hide();
			_currentView = _views[view];
			_currentView.Show();
			UiController.Instance.SetViewFor(_currentView);
		}
	
	}
	


	public enum MenuViews
	{
		Start,
		ChooseModel,
		ChooseTexture,
		ViewModel
	}
}