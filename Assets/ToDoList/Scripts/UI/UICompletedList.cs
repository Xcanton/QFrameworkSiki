using UnityEngine;
using UnityEngine.UI;
using QFramework;
using System.Linq;

namespace QFramework.TodoList
{
	public class UICompletedListData : UIPanelData
	{
		public TodoList Model = new TodoList();
	}
	public partial class UICompletedList : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UICompletedListData ?? new UICompletedListData();
			// please add init code here

			OnDataChanged();

			RegisterEvent(UICompletedListEvent.onDataChanged);

			BtnBack.onClick.AddListener(() =>
			{
				CloseSelf();
				UIKit.OpenPanel<UITodoList>(new UITodoListData()
				{
					Model = mData.Model,
				});
			});
        }

		public enum UICompletedListEvent
		{
			Start = UITodoListEvent.End,
			onDataChanged,
			End,
		}

		void OnDataChanged()
		{
			Debug.Log(Content);

            Content.DestroyAllChild();

			mData.Model.mTodoItems.Where(item => item.Completed).ForEach(item =>
			{
				//contentText.AppendLine(item.Content);
				UICompletedTodoItem.Instantiate()
				.Parent(Content)
				.LocalIdentity()
				.ApplySelfTo(self => self.Init(item))
				.Show();
			});
		}

		protected override void ProcessMsg(int eventId, QMsg msg)
		{
			if (eventId == (int)UICompletedListEvent.onDataChanged)
			{
				OnDataChanged();
			}
		}

		protected override void OnOpen(IUIData uiData = null)
		{
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}
	}
}
