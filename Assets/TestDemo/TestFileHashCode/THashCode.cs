using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
/// <summary>
/// 测试结果是两次生成同一文件hashcode不同
/// </summary>
public class THashCode : MonoBehaviour {


	void Start ()
	{
		string path = Path.GetDirectoryName(Application.dataPath)+"/data/res/role/hx_top.n";
		//File f = File.Create(path);

		FileInfo fi = new FileInfo (path);

		int hashCode = fi.GetHashCode();
		Debug.Log("---->hashCode:" + hashCode);
	}

	void Update ()
	{
		
	}
}
