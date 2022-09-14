using UnityEngine;
using UnityEngine.UI;
using QFramework;
using System.Text;
using System.Linq;
using static QFramework.TodoList.UITodoList;

namespace QFramework.TodoList
{
	public class UITodoListData : UIPanelData
	{
		// TODO: Query Mgr's Data

		public TodoList Model;

		public UITodoListState State = UITodoListState.Create;
	}

	public enum UITodoListEvent
	{
		start = QMgrID.UI,
		OnDataChange,
		OnTodoItemSelected,
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
			RegisterEvent(UITodoListEvent.OnTodoItemSelected);

			//Text.text = contentText.ToString();

			InputField.onEndEdit.AddListener(content =>
			{
				if (Input.GetKeyDown(KeyCode.Return))
				{
					mData.Model.mTodoItems.Add(new TodoItem()
					{
						Completed = false,
						Content = content
					});
				}
				

				InputField.text = string.Empty;
				OnDataChanged();
			});

			BtnCompletedList.onClick.AddListener(() =>
			{
				CloseSelf();
				UIKit.OpenPanel<UICompletedList>(new UICompletedListData()
				{
					Model = mData.Model,
				});
			});
		}

		public enum UITodoListState
		{
			Create,
			Modify,
		}

		public class OnTodoItemSelectedMsg : QMsg
		{
			public TodoItem ItemData;

			public OnTodoItemSelectedMsg(TodoItem itemData): base((int)UITodoListEvent.OnTodoItemSelected)
			{
                ItemData = itemData;
			}
		}
        protected override void ProcessMsg(int eventId, QMsg msg)
		{
			//base.ProcessMsg(eventId, msg);
			if (eventId == (int)UITodoListEvent.OnDataChange)
			{
				OnDataChanged();
			}
			else if (eventId == (int)UITodoListEvent.OnTodoItemSelected)
			{
				var selectMsg = msg as OnTodoItemSelectedMsg;

				//Debug.Log(selectMsg.ItemData.Content);
				InputField.text = selectMsg.ItemData.Content;
				mData.State = UITodoListState.Modify;

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
