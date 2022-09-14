using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TodoList
{
	// Generate Id:e37fb90f-d0b3-4432-af08-ca1cfb3d8aad
	public partial class UICompletedList
	{
		public const string Name = "UICompletedList";
		
		[SerializeField]
		public UICompletedTodoItem UICompletedTodoItem;
		[SerializeField]
		public RectTransform Content;
		[SerializeField]
		public UnityEngine.UI.Button BtnBack;
		
		private UICompletedListData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			UICompletedTodoItem = null;
			Content = null;
			BtnBack = null;
			
			mData = null;
		}
		
		public UICompletedListData Data
		{
			get
			{
				return mData;
			}
		}
		
		UICompletedListData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new UICompletedListData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
