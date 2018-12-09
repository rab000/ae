using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Nafio 场景编辑器
/// 使用流程
/// 1 制作场景
/// 1.1 打开编辑器Window NEditor/SceneEditor/Open_SceneEditor_Window
/// 1.2 手动在场景中添加ani场景中动画物件,dlight场景中光照,obj场景中动态物体npc等,partical场景中粒子特效,scene场景中静态物件,terrain地表,tree树这些节点
/// 1.3 手动填写场景编辑器Window中的参数(用于生成data中的场景数据配表)
/// 1.4 点击保存场景，保存当前场景id数据到data目录，并将新创建的节点保存到SceneEditor/Resource/Scenes/Prefabs/Scenes/scnx 目录中
/// 1.5 点击
/// 
/// 2 导入场景修改
/// 
/// </summary>
public class SceneEditor : EditorWindow {

	#region 场景编辑器Window功能
	[MenuItem ("NEditor/SceneEditor/Open_SceneEditor_Window")]
	static void AddWindow (){       
		SceneEditor saveWindow = (SceneEditor)EditorWindow.GetWindow (typeof (SceneEditor));
		saveWindow.Show();
	}

	string sceneIdStr = "1";
	string sceneNameStr = "测试1";
	string mapWidthStr = "10";
	string mapHeightStr = "10";
	bool bShowGrid = true;

	void OnGUI () {
		//输入框控件
		sceneIdStr = EditorGUILayout.TextField("场景ID:",sceneIdStr);
		sceneNameStr = EditorGUILayout.TextField("场景名:",sceneNameStr);
		mapWidthStr = EditorGUILayout.TextField("场景宽:",mapWidthStr);
		mapHeightStr = EditorGUILayout.TextField("场景高:",mapHeightStr);

		//导入已经存在的场景 1数据存在data中 2 prefab存在于Resources中
		if(GUILayout.Button("导入场景",GUILayout.Width(100))){
			int id = Convert.ToByte(sceneIdStr);
			LoadScene(id);
		}
		
		bShowGrid = EditorGUILayout.Toggle("显示阻挡:",bShowGrid);

		if(GUILayout.Button("保存场景",GUILayout.Width(100))){
			int id = Convert.ToByte(sceneIdStr);
			ExportScene(id);
		}
			

		if(GUILayout.Button("清理节点",GUILayout.Width(100))){
			CleanScene();
		}

		if(GUILayout.Button("创建模板节点",GUILayout.Width(100))){
			CreateTempleteGo();
		}

		if(GUILayout.Button("当前场景生成bundle",GUILayout.Width(120))){

		}

		if(GUILayout.Button("全部场景生成bundle",GUILayout.Width(120))){

		}
	}
	#endregion

	/// <summary>
	/// 导入已经存在的场景
	/// 先导入data/bin/文件夹下的场景数据文件
	/// 然后根据这个数据文件的id依次加载  "Prefabs/Scenes/scn"+sceneIdStr  这个路径下的各个场景文件
	/// </summary>
	/// <param name="id">Identifier.</param>
	void LoadScene(int id){

		Debug.Log(string.Format("开始导入场景{0}数据",id));
		string sceneInfoPath = Path.GetDirectoryName(Application.dataPath)+"/data/bin/";
		StringBuilder _path = new StringBuilder();
		_path.Append(sceneInfoPath);
		_path.Append("scn");
		_path.Append(id);
		byte[] bytes = FileHelper.ReadBytesFromFile(_path.ToString());
		//Debug.Log("导入时buffer长度:" + bytes.Length);
		if(null == bytes){
			Debug.LogError(string.Format("error！！ 获取地图:{0}失败",_path.ToString() ));
			return;
		}
		
		IoBuffer buffer = new IoBuffer();
		buffer.PutBytes(bytes);

		//场景ID
		byte sceneId = buffer.GetByte();
		sceneIdStr = sceneId.ToString();

		//场景名
		sceneNameStr = buffer.GetString();


		//场景宽
		int mapWidth = buffer.GetInt();
		mapWidthStr = mapWidth.ToString();


		//场景高
		int mapHeight = buffer.GetInt();
		mapHeightStr = mapHeight.ToString();

		_path = null;

		Debug.Log(string.Format("导入场景{0}信息成功",sceneId));

		CleanScene();

		//scnPrefab路径,导出时需要，载入不需要
		//string scnPrefabPath = Application.dataPath+"/Resources/Prefabs/Scenes/scn"+sceneIdStr;

		Debug.Log("开始载入场景"+sceneIdStr+"资源");
		//创建新地图
		GameObject goScene  = Instantiate(Resources.Load("Prefabs/Scenes/scn"+sceneIdStr+"/scene")) as GameObject;
		if (null == goScene) {
			Debug.LogError("找不到"+"Prefabs/Scenes/scn"+sceneIdStr+"/scene文件 停止终止！！");
			return;
		}
		goScene.name = "scene";

		GameObject goTerrain  = Instantiate(Resources.Load("Prefabs/Scenes/scn"+sceneIdStr+"/terrain")) as GameObject;
		if (null == goTerrain) {
			Debug.LogError("找不到"+"Prefabs/Scenes/scn"+sceneIdStr+"/terrain文件 停止终止！！");
			return;
		}
		goTerrain.name = "terrain";

		GameObject goLight  = Instantiate(Resources.Load("Prefabs/Scenes/scn"+sceneIdStr+"/dlight")) as GameObject;
		if (null == goLight) {
			Debug.LogError("找不到"+"Prefabs/Scenes/scn"+sceneIdStr+"/dlight文件 停止终止！！");
			return;
		}
		goLight.name = "dlight";

		GameObject goTree  = Instantiate(Resources.Load("Prefabs/Scenes/scn"+sceneIdStr+"/tree")) as GameObject;
		if (null == goTree) {
			Debug.LogError("找不到"+"Prefabs/Scenes/scn"+sceneIdStr+"/tree文件 停止终止！！");
			return;
		}
		goTree.name = "tree";

		GameObject goObj  = Instantiate(Resources.Load("Prefabs/Scenes/scn"+sceneIdStr+"/obj")) as GameObject;
		if (null == goObj) {
			Debug.LogError("找不到"+"Prefabs/Scenes/scn"+sceneIdStr+"/obj文件 停止终止！！");
			return;
		}
		goObj.name = "obj";

		GameObject goAni  = Instantiate(Resources.Load("Prefabs/Scenes/scn"+sceneIdStr+"/ani")) as GameObject;
		if (null == goAni) {
			Debug.LogError("找不到"+"Prefabs/Scenes/scn"+sceneIdStr+"/ani文件 停止终止！！");
			return;
		}
		goAni.name = "ani";

		GameObject goPartical  = Instantiate(Resources.Load("Prefabs/Scenes/scn"+sceneIdStr+"/partical")) as GameObject;
		if (null == goPartical) {
			Debug.LogError("找不到"+"Prefabs/Scenes/scn"+sceneIdStr+"/partical文件 停止终止！！");
			return;
		}
		goAni.name = "ani";
		goPartical.name = "partical";


		//info = "导入地图"+sceneIdStr+"成功";
		Debug.Log(string.Format("导入场景{0}成功",sceneId));
	}

	/// <summary>
	/// 导出场景
	/// </summary>
	/// <param name="id">Identifier.</param>
	void ExportScene(int id){

		Debug.Log(string.Format("step1--->开始导出场景{0}信息",id));
		byte sceneId = Convert.ToByte(sceneIdStr);
		int mapWidth = Convert.ToInt32(mapWidthStr);
		int mapHeight = Convert.ToInt32(mapHeightStr);

		string path = Path.GetDirectoryName(Application.dataPath)+"/data/bin/";

		if (!Directory.Exists(path))
			Directory.CreateDirectory(path);

		IoBuffer buffer = new IoBuffer();
		buffer.PutByte(sceneId);
		buffer.PutString(sceneNameStr);
		buffer.PutInt(mapWidth);
		buffer.PutInt(mapHeight);

		//Debug.Log("导出时buffer长度:"+buffer.ToArray().Length);
		string filename = path+"scn"+id;

		FileHelper.WriteBytes2File(filename,buffer.ToArray());
		
		buffer.Clear();
		buffer = null;

		Debug.Log(string.Format("导出场景{0}信息成功",filename));



		//保存场景中go到prefab
		string saveScenePrefabPath = Application.dataPath+"/Resources/Prefabs/Scenes/scn"+sceneId+"/";

		Debug.Log("step2--->开始将场景中的prefab导入到"+saveScenePrefabPath);

		//找到所有场景中Go,并保存当前场景的prefab
		foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject))){
			switch(obj.name){
			case "terrain":
			case "scene":
			case "dlight":
			case "obj":
			case "partical":
			case "ani":
			case "tree":

				string prefabPath = saveScenePrefabPath+obj.name+".prefab";
				
				if(File.Exists(prefabPath)){
					Debug.Log(string.Format(prefabPath+"存在，删除重建"));
					File.Delete(prefabPath);
				}
				PrefabUtility.CreatePrefab(prefabPath,obj);

				break;
			default:
				Debug.LogError("ExportScene()存在场景以外其他物体:"+obj.name);
				break;
			}
		}
		Debug.Log(string.Format("保存场景{0}prefab成功",filename));


		//Debug.Log("step2--->开始将Resourse中的prefab导出成Assetbundle");
		//1 导出路径

	}

	/// <summary>
	/// 清理场景中节点
	/// </summary>
	public static void CleanScene(){
		Debug.Log("清理场景中无用资源，非Main Camera节点");
		foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject))){
			if(!obj.name.Equals("Main Camera"))DestroyImmediate(obj);
		}
	}

	/// <summary>
	/// 创建
	/// </summary>
	public static void CreateTempleteGo(){
		Debug.Log("创建模板节点");
		GameObject go1 = new GameObject("ani");
		GameObject go2 = new GameObject("dlight");
		GameObject go3 = new GameObject("partical");
		GameObject go4 = new GameObject("scene");
		GameObject go5 = new GameObject("terrain");
		GameObject go6 = new GameObject("obj");
		GameObject go7 = new GameObject("tree");
	}

	/// <summary>
	/// 创建当前场景bundle
	/// </summary>
	public static void CreateCurentScnBundle(){
		//碰到些编辑器结构问题,
		//问题描述，每个scn打包最后命名和存放位置问题，是否是这样terrian0，terrian1，或者同名放在不同的scn0文件夹中，另外mapInfo中存放的资源信息现在还是用一个int来存很多byte这个有点乱不宜理解

		//.0
		//确定生成路径
		//生成bundle
	}


	//NTODO 这个方法有缺欠，只要选中文件夹就会把所有objet类型的东西导出成ab，不合理，容易导出多余资源
	//这个方法是老的选择prefab然后将单独一个prefab打包的方法，先临时生成下地形，以后scnEditor要独立出来
	//NINFO 2018.5.3导出的Terrain0是个临时方案，scnEditor面临大调整
	//现在生成scn和map配表的代码在TestTable中，而地图资源是从下面的ExportSelectedScene2AssetBundle导出的，可以说是非常不合理，但目前情况没办法用更多时间处理地图
	//所以还是保持配表资源不做变更，现在要做地图动态加载寻路功能，还是直接使用下面的方法导出加入寻路功能的地图
	[MenuItem("NEditor/SceneEditor/BuildSelectedScene to AssetBundle")]
	public static void ExportSelectedScene2AssetBundle(){

		List<AssetBundleBuild> BundleBuildList = new List<AssetBundleBuild> ();

		string path = Path.GetDirectoryName(Application.dataPath) +"/data/res/";
		string rootPath = "Assets/NEditor/SceneEditor/Resources/Scenes/Prefabs/";

		UnityEngine.Object[] selection = Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.DeepAssets);
		foreach (UnityEngine.Object obj in selection){
			if (obj is GameObject){
				string objPath = AssetDatabase.GetAssetPath(obj);
				string objDirectory = Path.GetDirectoryName(objPath);
				string objName = Path.GetFileNameWithoutExtension(objPath);
				string saveDirectory = path + objDirectory.Substring(rootPath.Length);

				if (!Directory.Exists(saveDirectory))
					Directory.CreateDirectory(saveDirectory);

				string savePath = saveDirectory + "/" + objName + ".unity3d";
				//bool ret=  BuildPipeline.BuildAssetBundle(obj,null, savePath,BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets,BuildTarget.StandaloneWindows);

				AssetBundleBuild ab = new AssetBundleBuild();
				ab.assetBundleName = objName+".n";
				Debug.Log ("objPath---->"+objPath+" bundle.name:"+objName);
				ab.assetNames = new string[]{objPath};
				BundleBuildList.Add (ab);
				string outUrl = path+"map";
				BuildPipeline.BuildAssetBundles (outUrl, BundleBuildList.ToArray(), BuildAssetBundleOptions.CollectDependencies, BuildTarget.StandaloneWindows);

				//if(ret==false)
				//	Debug.LogError("编译错误"+savePath);
				//else{
				//	string newPath = saveDirectory + "/" + objName + ".tresource";
					//EncodeFile(savePath, newPath);
				//}
			}
		}
	}



//	#region 保留方法
//	//更新
//	void Update(){
//		
//	}
//	
//	void OnFocus(){
//		//Debug.Log("当窗口获得焦点时调用一次");
//	}
//	
//	void OnLostFocus(){
//		//Debug.Log("当窗口丢失焦点时调用一次");
//	}
//	
//	void OnHierarchyChange(){
//		//Debug.Log("当Hierarchy视图中的任何对象发生改变时调用一次");
//	}
//	
//	void OnProjectChange(){
//		//Debug.Log("当Project视图中的资源发生改变时调用一次");
//	}
//	
//	void OnInspectorUpdate(){
//		//Debug.Log("窗口面板的更新");
//		//这里开启窗口的重绘，不然窗口信息不会刷新
//		this.Repaint();
//	}
//	
//	void OnSelectionChange(){
//		
//		foreach(Transform t in Selection.transforms){
//			//有可能是多选，这里开启一个循环打印选中游戏对象的名称
//			Debug.Log("OnSelectionChange" + t.name);
//		}
//	}
//	
//	void OnDestroy(){
//		//Debug.Log("当窗口关闭时调用");
//	}
//	#endregion
}
