using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
using System;
using System.IO;
//public class TRoleLoad : MonoBehaviour {
//
//	static string ABOutputPath{
//
//		get{ return Path.GetDirectoryName(Application.dataPath)+"/data/res/role/";}
//
//	}
//
//	void Start () 
//	{
//		
//	}
//	
//
//	void Update () 
//	{
//		if (Input.GetKeyUp (KeyCode.A))
//		{
//			Debug.Log("T0");
//			StartCoroutine(SLoad());
//		}
//
//	}
//
//	IEnumerator SLoad()
//	{
//		Debug.Log("outputPath------>start load!!!");
//
//		string path = "file:///"+ABOutputPath + "/female_basebone.n";
//
//		WWW www = new WWW(path);
//
//		yield return www;
//
//		if (null != www.error) 
//		{
//			Debug.Log ("加载 www error:" + www.error);
//		}
//		else
//		{
//			Debug.Log ("加载 www ok:");
//		}
//
//		string[] names  =www.assetBundle.GetAllAssetNames();
//
//		for (int i = 0; i < names.Length; i++) 
//		{
//			Debug.Log("assetName-"+i+"->"+names[i]);
//		}
//
//		GameObject go = www.assetBundle.LoadAsset<GameObject>("basebone");
//
//		var g = Instantiate(go);
//
//		g.name = "bone";
//	}
//}
