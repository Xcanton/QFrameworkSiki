/****************************************************************************
 * 2022.9 DESKTOP-Q8U2JSO
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TodoList
{
	public partial class UICompletedTodoItem
	{
		[SerializeField] public UnityEngine.UI.Text Content;
		[SerializeField] public UnityEngine.UI.Button BtnRestore;

		public void Clear()
		{
			Content = null;
			BtnRestore = null;
		}

		public override string ComponentName
		{
			get { return "UICompletedTodoItem";}
		}
	}
}
