using Interfaces;
using Controllers;
using DG.Tweening;
using UnityEngine;

namespace MenuViews
{
	public class MainMenuView : BaseMenuView,IPlayButton {


		public void PlayButton()
		{
			MainController.Instance.ShowView(Controllers.MenuViews.ChooseModel);
		}
	}
}
