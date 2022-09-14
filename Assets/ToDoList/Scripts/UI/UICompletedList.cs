using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TodoList
{
	public class UICompletedListData : UIPanelData
	{
	}
	public partial class UICompletedList : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as UICompletedListData ?? new UICompletedListData();
			// please add init code here
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
