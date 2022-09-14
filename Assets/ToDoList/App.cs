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

        //public TodoList Model = new TodoList();
        TodoList mModel;

        // Start is called before the first frame update
        void Start()
        {
            mModel =  TodoList.Load();
            ResMgr.Init();

            UIKit.OpenPanel<UITodoList>(new UITodoListData() { Model = mModel }) ;
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnApplicationQuit()
        {
            mModel.Save();
        }
    }

    [System.Serializable]
    public class TodoList
    {
        public List<TodoItem> mTodoItems = new List<TodoItem>();

        public static TodoList Load()
        {
            var jsonContent = PlayerPrefs.GetString("TodoListData", string.Empty);

            if (jsonContent.IsNullOrEmpty())
            {
                return new TodoList();
            }
            else
            {
                return JsonUtility.FromJson<TodoList>(jsonContent);
            }
        }

        public void Save()
        {
            //JsonUtility.ToJson(this);
            PlayerPrefs.SetString("TodoListData", JsonUtility.ToJson(this));
        }
    }

    public class TodoItem
    {
        public bool Completed;
        public string Content;
    }
}
