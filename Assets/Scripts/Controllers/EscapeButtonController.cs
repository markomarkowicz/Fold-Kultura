using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Controllers
{
	public class EscapeButtonController : MonoBehaviour
	{

		public static EscapeButtonController Instance;
	
		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
				escapableStack = new ItsAlmostAStack<IEscapableView>();
			}
			else
			{
				Destroy(gameObject);
			}
		}

		private static ItsAlmostAStack<IEscapableView> escapableStack;

		public static void Register(IEscapableView view)
		{
			escapableStack.Push(view);
		}
	
		public static void Deregister(IEscapableView view)
		{
			escapableStack.Remove(view);
		}

		private static void EscapeAction()
		{
			if (escapableStack.Lenght > 0)
			{
				escapableStack.Pop().EscapeAction();
			}
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
				EscapeAction();
		}
	}

	public class ItsAlmostAStack<T>
	{
		private List<T> items = new List<T>();

		public int Lenght
		{
			get { return items.Count; }
		}
		public void Push(T item)
		{
			items.Add(item);
		}
		public T Pop()
		{
			if (items.Count > 0)
			{
				T temp = items[items.Count - 1];
				items.RemoveAt(items.Count - 1);
				return temp;
			}
			else
				return default(T);
		}
		public void Remove(int itemAtPosition)
		{
			items.RemoveAt(itemAtPosition);
		}
	
		public void Remove(T item)
		{
			items.Remove(item);
		}
	}
}