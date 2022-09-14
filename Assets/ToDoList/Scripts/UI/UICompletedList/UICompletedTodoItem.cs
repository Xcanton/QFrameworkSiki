/****************************************************************************
 * 2022.9 DESKTOP-Q8U2JSO
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using static QFramework.TodoList.UICompletedList;

namespace QFramework.TodoList
{
	public partial class UICompletedTodoItem : UIElement
	{
		private void Awake()
		{
		}

		protected override void OnBeforeDestroy()
		{
		}

		TodoItem mModel;
		public void Init(TodoItem model)
		{
			mModel = model;

			Content.text = mModel.Content;

			BtnRestore.onClick.AddListener(() =>
			{
				mModel.Completed = false;
				SendEvent(UICompletedListEvent.onDataChanged);
			});
		}
	}
}