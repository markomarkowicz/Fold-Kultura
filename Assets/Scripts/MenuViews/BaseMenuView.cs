using System.Collections;
using System.Collections.Generic;
using Controllers;
using DG.Tweening;
using Interfaces;
using UnityEngine;

public class BaseMenuView : MonoBehaviour,IEscapableView{


    public virtual void Show()
    {
        EscapeButtonController.Register(this);
    }
    
    public virtual void Hide()
    {
        EscapeButtonController.Deregister(this);
    }

    public void EscapeAction()
    {
        Hide();
    }
}
