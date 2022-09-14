using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TodoList
{
	// Generate Id:ebdfb094-5b16-4a93-a8d2-9c4b52ebaa4f
	public partial class UITodoList
	{
		public const string Name = "UITodoList";
		
		[SerializeField]
		public UITodoItem UITodoItem;
		[SerializeField]
		public RectTransform Content;
		[SerializeField]
		public UnityEngine.UI.InputField InputField;
		[SerializeField]
		public UnityEngine.UI.Button BtnCompletedList;
		
		private UITodoListData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			UITodoItem = null;
			Content = null;
			InputField = null;
			BtnCompletedList = null;
			
			mData = null;
		}
		
		public UITodoListData Data
		{
			get
			{
				return mData;
			}
		}
		
		UITodoListData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UITodoListData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
