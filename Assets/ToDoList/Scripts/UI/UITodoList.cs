using UnityEngine;
using UnityEngine.UI;
using QFramework;
using System.Text;
using System.Linq;

namespace QFramework.TodoList
{
	public class UITodoListData : UIPanelData
	{
		// TODO: Query Mgr's Data

		public TodoList Model;
	}

	public enum UITodoListEvent
	{
		start = QMgrID.UI,
		OnDataChange,
		End
	} 

	public partial class UITodoList : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UITodoListData ?? new UITodoListData();
			// please add init code here

			//Text.text = mData.Model.mTodoItems.Count.ToString();

			var contentText = new StringBuilder();

            OnDataChanged();

            RegisterEvent(UITodoListEvent.OnDataChange);

			//Text.text = contentText.ToString();

			InputField.onEndEdit.AddListener(content =>
			{
				mData.Model.mTodoItems.Add(new TodoItem()
				{
					Completed = false,
					Content = content
				});

				InputField.text = string.Empty;
				OnDataChanged();
			});

			BtnCompletedList.onClick.AddListener(() =>
			{
				CloseSelf();
				UIKit.OpenPanel<UICompletedList>();
			});
		}

        protected override void ProcessMsg(int eventId, QMsg msg)
		{
			//base.ProcessMsg(eventId, msg);
			if (eventId == (int)UITodoListEvent.OnDataChange)
			{
				OnDataChanged();
			}
		}

		void OnDataChanged()
		{
			Content.DestroyAllChild();

            mData.Model.mTodoItems.Where(item=> !item.Completed ).ForEach(item =>
            {
                //contentText.AppendLine(item.Content);
                UITodoItem.Instantiate()
                .Parent(Content)
                .LocalIdentity()
                .ApplySelfTo(self => self.Init(item))
                .Show();
            });
        }

		//protected override void RegisterUIEvent()
		//{
		//	InputField.onEndEdit.AddListener(content =>
		//	{
		//		mData.Model.mTodoItems.Add(new TodoItem()
		//		{
		//			Completed = false,
		//			Content = content
		//		});

		//		OnDataChanged();
		//	});
		//}

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
