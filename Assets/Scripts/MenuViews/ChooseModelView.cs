using Controllers;
using DG.Tweening;
using Interfaces;
using UnityEngine;

namespace MenuViews
{
	public class ChooseModelView : BaseMenuView,IArrowButtons,IEscapableView {

		// Use this for initialization
		void Start () {
		
		}

		public override void Show()
		{
			base.Show();
			Vector3 rotation = MainController.Instance._viewCamera.transform.eulerAngles;
			rotation.y += 90f;
			MainController.Instance._viewCamera.transform.DORotate(rotation, 1f).SetEase(Ease.InOutCubic);
			
		}

		public override void Hide()
		{
			Vector3 rotation = MainController.Instance._viewCamera.transform.eulerAngles;
			rotation.y += 90f;
			MainController.Instance._viewCamera.transform.DORotate(rotation, 1f).SetEase(Ease.InOutCubic);
			EscapeButtonController.Deregister(this);
		}


		public void RightArrow()
		{
		
		}

		public void LeftArrow()
		{
		
		}

	}
}
