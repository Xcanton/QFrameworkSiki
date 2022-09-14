using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TodoList
{
	// Generate Id:f264aa12-44bc-4372-bff9-5cf8d5522691
	public partial class UICompletedList
	{
		public const string Name = "UICompletedList";
		
		
		private UICompletedListData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
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
