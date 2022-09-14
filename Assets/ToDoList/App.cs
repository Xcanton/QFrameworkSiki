using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;


namespace QFramework.TodoList
{

    /// <summary>
    /// TodoApp:
    /// 1.  ��ɡ�δ���
    /// 2.  �б�/��������
    /// 3.  ���ӡ�ɾ�������Ĵ�������
    /// 
    /// ��һ���б��б����� ������� ���������ܹ����δ�������
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
            new TodoItem() {Completed = false, Content = "Ҫ���" },
            new TodoItem() {Completed = false, Content = "������" },
            new TodoItem() {Completed = false, Content = "ѧϰ" },
        };
    }

    public class TodoItem
    {
        public bool Completed;
        public string Content;
    }
}
