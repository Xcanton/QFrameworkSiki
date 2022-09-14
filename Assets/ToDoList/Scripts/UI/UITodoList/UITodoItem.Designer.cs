/****************************************************************************
 * 2022.9 DESKTOP-Q8U2JSO
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.TodoList
{
	public partial class UITodoItem
	{
		[SerializeField] public UnityEngine.UI.Text Content;
		[SerializeField] public UnityEngine.UI.Toggle Completed;

		public void Clear()
		{
			Content = null;
			Completed = null;
		}

		public override string ComponentName
		{
			get { return "UITodoItem";}
		}
	}
}
