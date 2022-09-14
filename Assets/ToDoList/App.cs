using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;


namespace QFramework.TodoList
{

    /// <summary>
    /// TodoApp:
    /// 1.  完成、未完成
    /// 2.  列表/待办事项
    /// 3.  增加、删除、更改代办事项
    /// 
    /// 有一个列表，列表里多个 待办事项， 待办事项能够完成未完成内容
    /// </summary>
    /// 


    public class App : MonoBehaviour
    {

        public TodoList Model = new TodoList();

        // Start is called before the first frame update
        void Start()
        {
            ResMgr.Init();

            UIKit.OpenPanel<UITodoList>(new UITodoListData() { Model = Model }) ;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

    public class TodoList
    {
        public List<TodoItem> mTodoItems = new List<TodoItem>()
        {
            new TodoItem() {Completed = false, Content = "要买菜" },
            new TodoItem() {Completed = false, Content = "换电脑" },
            new TodoItem() {Completed = false, Content = "学习" },
        };
    }

    public class TodoItem
    {
        public bool Completed;
        public string Content;
    }
}
