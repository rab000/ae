
//using UnityEngine;
//using UnityEditor;
//public class EditorUI : EditorWindow 
//{

//	[MenuItem ("Fuck/window")]
//	static void AddWindow ()
//	{       
//		//创建窗口
//
//		EditorUI window = (EditorUI)EditorWindow.GetWindow (typeof (EditorUI));	
//		window.Show();
//
//	}
//
//	//输入文字的内容
//	private string text;
//	//选择贴图的对象
//	private Texture texture;
//
//	public void Awake () 
//	{
//		//在资源中读取一张贴图
//		texture = Resources.Load("1") as Texture;
//	}
//
//	//绘制窗口时调用
//	void OnGUI () 
//	{
//		//输入框控件
////		text = EditorGUILayout.TextField("输入文字:",text);
////
////		if(GUILayout.Button("打开通知",GUILayout.Width(200)))
////		{
////			//打开一个通知栏
////			this.ShowNotification(new GUIContent("This is a Notification"));
////		}
////
////		if(GUILayout.Button("关闭通知",GUILayout.Width(200)))
////		{
////			//关闭通知栏
////			this.RemoveNotification();
////		}
////			
////
////
////
////		//文本框显示鼠标在窗口的位置
////		EditorGUILayout.LabelField ("鼠标在窗口的位置", Event.current.mousePosition.ToString ());
////
////
////
////		//选择贴图
////		texture =  EditorGUILayout.ObjectField("添加贴图",texture,typeof(Texture),true) as Texture;
////
////		if(GUILayout.Button("关闭窗口",GUILayout.Width(200)))
////		{
////			//关闭窗口
////			this.Close();
////		}
//		Rect windowRect = new Rect(100,100,400,400);
//		BeginWindows();//标记开始区域所有弹出式窗口
//		windowRect = GUILayout.Window(1, windowRect, DoWindow, "fuckWin");//创建内联窗口,参数分别为id,大小位置，创建子窗口的组件的函数，标题
//
//		EndWindows();//标记结束
//
//		//GUILayout.BeginHorizontal();
//		{
//
//
//
//
//
//			//			GUILayout.BeginVertical(EditorStyles.textArea, GUILayout.Width(500));
//			//			{
//			//				GUILayout.Label("Vertical Layout 1");
//			//			}
//			//			GUILayout.EndVertical();
//
////			GUILayout.BeginVertical(EditorStyles.textArea);
////			{
////				GUILayout.Label("Vertical Layout 1");
////			}
////			GUILayout.EndVertical();
////
////
////
////			GUILayout.BeginVertical(EditorStyles.textArea);
////			{
////				GUILayout.Label("VerticalLayout GUILayout.Label");
////				GUILayout.Space(10);
////				EditorGUILayout.LabelField("Vertical Layout 2", EditorStyles.textArea);
////				GUI.Label(new Rect(0, 50, 150, 50), "VerticalLayout GUI.Label", EditorStyles.textArea);
////			}
////			GUILayout.EndVertical();
////			/////////////////////////////////////////////////////////////////////////////////////////
////
////			GUILayout.BeginArea(new Rect(0, 200, 500, 300), EditorStyles.textArea);
////			{
////				GUILayout.Label("AreaLayout GUILayout.Label");
////				GUILayout.Space(10);
////				EditorGUILayout.LabelField("AreaLayout EditorGUILayout.LabelField", EditorStyles.textArea);
////				GUI.Label(new Rect(0, 80, 200, 20), "AreaLayout GUI.Label", EditorStyles.textArea);
////			}
////			GUILayout.EndArea();
//		}
//		//GUILayout.EndHorizontal();
//	}
//
//	void DoWindow(int unusedWindowID){
//		GUILayout.Button ("fuck");
//		GUI.DragWindow();
//	}
//
//	//更新
//	void Update()
//	{
//
//	}
//
//	void OnFocus()
//	{
//		Debug.Log("当窗口获得焦点时调用一次");
//	}
//
//	void OnLostFocus()
//	{
//		Debug.Log("当窗口丢失焦点时调用一次");
//	}
//
//	void OnHierarchyChange()
//	{
//		Debug.Log("当Hierarchy视图中的任何对象发生改变时调用一次");
//	}
//
//	void OnProjectChange()
//	{
//		Debug.Log("当Project视图中的资源发生改变时调用一次");
//	}
//
//	void OnInspectorUpdate()
//	{
//		//Debug.Log("窗口面板的更新");
//		//这里开启窗口的重绘，不然窗口信息不会刷新
//		this.Repaint();
//	}
//
//	void OnSelectionChange()
//	{
//		//当窗口出去开启状态，并且在Hierarchy视图中选择某游戏对象时调用
//		foreach(Transform t in Selection.transforms)
//		{
//			//有可能是多选，这里开启一个循环打印选中游戏对象的名称
//			Debug.Log("OnSelectionChange" + t.name);
//		}
//	}
//
//	void OnDestroy()
//	{
//		Debug.Log("当窗口关闭时调用");
//	}
//}