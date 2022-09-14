/****************************************************************************
 * 2022.9 DESKTOP-Q8U2JSO
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using static QFramework.TodoList.UITodoList;

namespace QFramework.TodoList
{
	public partial class UITodoItem : UIElement
	{
		TodoItem mModel;

		public  void Init(TodoItem model)
		{
			mModel = model;

			Content.text = model.Content;
			Completed.isOn = model.Completed;

			Completed.onValueChanged.AddListener(on =>
			{
				mModel.Completed = on;
				SendEvent(UITodoListEvent.OnDataChange);
			});

			Button.onClick.AddListener(() =>
			{
				SendMsg(new OnTodoItemSelectedMsg(mModel));
			});
		}

		private void Awake()
		{
		}

		protected override void OnBeforeDestroy()
		{
		}
	}
}