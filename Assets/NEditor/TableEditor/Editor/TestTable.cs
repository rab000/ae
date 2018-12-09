using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Collections.Generic;
/// <summary>
/// 为了测试resMgr
/// 模拟出一份最基础的配表包括，目的是模拟编辑器数据，优先完成引擎功能
/// 
/// apkVer.bytes 版本信息表
/// apkRes.bytes 
/// </summary>
public class TestTable{

	static IoBuffer buf = new IoBuffer(102400);

	static byte[] b;



	[MenuItem ("NEditor/TableEditor/Test")]
	static void Test(){

		int id_anim_group = 0;
		id_anim_group = ResEnum.GetResIDByTypeAndID(id_anim_group,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_ANIMGROUP,0);//暂定无类型id为0
		Debug.Log("[nafio]--->id_anim_group:"+id_anim_group);
	}

	[MenuItem ("NEditor/TableEditor/CreateTempTable")]
	static void CreateTempTable(){

		//CreateVerTable();//版本表

		//CreateAPKResTable();//包内资源表

		CreateResInfoTable();//资源总表

		CreateScnInfo();//场景信息表

		CreatMapInfo();//地图信息表

		//关于角色，目前先不提供装备，套装内容数据，只把模型资源数据填入总表和包内资源表即可
		CreateRoleHandsBundle();//模拟生成角色手
	}

	/// <summary>
	/// 版本信息表
	/// </summary>
//	static void CreateVerTable(){
//
//		//[创建版本信息表]----apkVer.bytes---------------------------------------------------------
//		buf.Clear();
//		buf = new IoBuffer();
//		buf.PutInt(1);//apkVer版本号
//		buf.PutBool(true);//是否有apkRes
//		buf.PutBool(false);//是否有apkUpdate
//		buf.PutBool(false);//是否有apkDynamic
//		//buf.PutBool(false);//是否有
//		b = buf.ToArray();
//		FileHelper.WriteBytes2File(EditorHelper.OUTPUT_TABLE_SYSTEM_PATH+"/apkver.bytes",b);
//
//	}
	
	/// <summary>
	/// 包内资源表
	/// </summary>
//	static void CreateAPKResTable(){
//
//		//配表资源scnInfo0.bytes 
//		int id_scnInfo =0;
//		id_scnInfo = ResEnum.GetResIDByTypeAndID(id_scnInfo,ResEnum.RES_TYPE0_BYTES,ResEnum.RES_TYPE1_SCENE,ResEnum.RES_TYPE2_NULL,0);//暂定无类型id为0
//		Debug.Log("id_scnInfo:"+id_scnInfo);
//		
//		
//		//配表资源mapInfo0.bytes
//		int id_mapInfo =0;
//		id_mapInfo = ResEnum.GetResIDByTypeAndID(id_mapInfo,ResEnum.RES_TYPE0_BYTES,ResEnum.RES_TYPE1_MAP,ResEnum.RES_TYPE2_MAP_INFO,0);//暂定无类型id为0
//		Debug.Log("id_mapInfo:"+id_mapInfo);
//		
//		//测试terrain0.n
//		int id_terrain=0;
//		id_terrain = ResEnum.GetResIDByTypeAndID(id_terrain,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_MAP,ResEnum.RES_TYPE2_MAP_TERRAIN,0);//暂定无类型id为0
//
//		//骨骼
//		int id_bone = 0;
//		id_bone = ResEnum.GetResIDByTypeAndID(id_bone,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_BONE,0);//暂定无类型id为0
//
//		int id_eye = 0;
//		id_eye = ResEnum.GetResIDByTypeAndID(id_eye,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_EYES,0);//暂定无类型id为0
//
//		int id_face = 0;
//		id_face = ResEnum.GetResIDByTypeAndID(id_face,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_FACE,0);//暂定无类型id为0
//
//		int id_head = 0;
//		id_head = ResEnum.GetResIDByTypeAndID(id_head,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_HEAD,0);//暂定无类型id为0
//
//		int id_top = 0;
//		id_top = ResEnum.GetResIDByTypeAndID(id_top,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_TOP,0);//暂定无类型id为0
//
//		int id_hands = 0;
//		id_hands = ResEnum.GetResIDByTypeAndID(id_hands,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_HANDS,0);//暂定无类型id为0
//
//		int id_pants = 0;
//		id_pants = ResEnum.GetResIDByTypeAndID(id_pants,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_PANTS,0);//暂定无类型id为0
//
//		int id_shoes = 0;
//		id_shoes = ResEnum.GetResIDByTypeAndID(id_shoes,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_SHOES,0);//暂定无类型id为0
//
//		//材质资源
//		int id_eye_mat = 0;
//		id_eye_mat = ResEnum.GetResIDByTypeAndID(id_eye_mat,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_EYES_MAT,0);//暂定无类型id为0
//		
//		int id_face_mat = 0;
//		id_face_mat = ResEnum.GetResIDByTypeAndID(id_face_mat,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_FACE_MAT,0);//暂定无类型id为0
//		
//		int id_head_mat = 0;
//		id_head_mat = ResEnum.GetResIDByTypeAndID(id_head_mat,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_HEAD_MAT,0);//暂定无类型id为0
//		
//		int id_top_mat = 0;
//		id_top_mat = ResEnum.GetResIDByTypeAndID(id_top_mat,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_TOP_MAT,0);//暂定无类型id为0
//		
//		int id_hands_mat = 0;
//		id_hands_mat = ResEnum.GetResIDByTypeAndID(id_hands_mat,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_HANDS_MAT,0);//暂定无类型id为0
//		
//		int id_pants_mat = 0;
//		id_pants_mat = ResEnum.GetResIDByTypeAndID(id_pants_mat,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_PANTS_MAT,0);//暂定无类型id为0
//		
//		int id_shoes_mat = 0;
//		id_shoes_mat = ResEnum.GetResIDByTypeAndID(id_shoes_mat,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_SHOES_MAT,0);//暂定无类型id为0
//
//		int id_anim_group = 0;
//		id_anim_group = ResEnum.GetResIDByTypeAndID(id_anim_group,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_ANIMGROUP,0);//暂定无类型id为0
//
//		Debug.Log("bone:"+id_bone +
//		          "eyes:"+id_eye+
//		          "face:"+id_face+
//		          "head:"+id_head+
//		          "top:"+id_top+
//		          "hand:"+id_hands+
//		          "pants:"+id_pants+
//		          "shoes:"+id_shoes+
//		          "eyesM:"+id_eye_mat+
//		          "faceM:"+id_face_mat+
//		          "headM:"+id_head_mat+
//		          "topM:"+id_top_mat+
//		          "handM:"+id_hands_mat+
//		          "pantsM:"+id_pants_mat+
//		          "shoeM:"+id_shoes_mat+
//		          "anim_group"+id_anim_group);
//
//
//		//创建包内资源表apkRes.bytes(apk中包含的res)---------------------------------------------------------
//		buf.Clear();
//		buf.PutInt(19);//apkRes中的资源数
//		//加入scnid配表资源
//		//buf.PutInt(id_scnID);//apkRes中存的资源ID
//		buf.PutInt(id_scnInfo);//加入scnInfo配表资源
//		buf.PutInt(id_mapInfo);//加入mapInfo配表资源
//		buf.PutInt(id_terrain);//加入terrain资源
//
//		buf.PutInt(id_bone);
//		buf.PutInt(id_eye);
//		buf.PutInt(id_face);
//		buf.PutInt(id_head);
//		buf.PutInt(id_top);
//		buf.PutInt(id_hands);
//		buf.PutInt(id_pants);
//		buf.PutInt(id_shoes);
//
//		buf.PutInt(id_eye_mat);
//		buf.PutInt(id_face_mat);
//		buf.PutInt(id_head_mat);
//		buf.PutInt(id_top_mat);
//		buf.PutInt(id_hands_mat);
//		buf.PutInt(id_pants_mat);
//		buf.PutInt(id_shoes_mat);
//
//		buf.PutInt(id_anim_group);
//
//		b = buf.ToArray();
//		FileHelper.WriteBytes2File(EditorHelper.OUTPUT_TABLE_SYSTEM_PATH+"/apkres.bytes",b);
//
//	}

	/// <summary>
	/// 资源总表
	/// </summary>
	static void CreateResInfoTable(){

//		//配表资源scnInfo0.bytes 
//		int id_scnInfo =0;
//		id_scnInfo = ResEnum.GetResIDByTypeAndID(id_scnInfo,ResEnum.RES_TYPE0_BYTES,ResEnum.RES_TYPE1_SCENE,ResEnum.RES_TYPE2_NULL,0);//暂定无类型id为0
//		Debug.Log("id_scnInfo:"+id_scnInfo);
//		
//		
//		//配表资源mapInfo0.bytes
//		int id_mapInfo =0;
//		id_mapInfo = ResEnum.GetResIDByTypeAndID(id_mapInfo,ResEnum.RES_TYPE0_BYTES,ResEnum.RES_TYPE1_MAP,ResEnum.RES_TYPE2_MAP_INFO,0);//暂定无类型id为0
//		Debug.Log("id_mapInfo:"+id_mapInfo);
//		
//		//测试terrain0.n
//		int id_terrain=0;
//		id_terrain = ResEnum.GetResIDByTypeAndID(id_terrain,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_MAP,ResEnum.RES_TYPE2_MAP_TERRAIN,0);//暂定无类型id为0
//		
//
//		//骨骼
//		int id_bone = 0;
//		id_bone = ResEnum.GetResIDByTypeAndID(id_bone,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_BONE,0);//暂定无类型id为0
//		
//		int id_eye = 0;
//		id_eye = ResEnum.GetResIDByTypeAndID(id_eye,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_EYES,0);//暂定无类型id为0
//		
//		int id_face = 0;
//		id_face = ResEnum.GetResIDByTypeAndID(id_face,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_FACE,0);//暂定无类型id为0
//		
//		int id_head = 0;
//		id_head = ResEnum.GetResIDByTypeAndID(id_head,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_HEAD,0);//暂定无类型id为0
//		
//		int id_top = 0;
//		id_top = ResEnum.GetResIDByTypeAndID(id_top,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_TOP,0);//暂定无类型id为0
//		
//		int id_hands = 0;
//		id_hands = ResEnum.GetResIDByTypeAndID(id_hands,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_HANDS,0);//暂定无类型id为0
//		
//		int id_pants = 0;
//		id_pants = ResEnum.GetResIDByTypeAndID(id_pants,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_PANTS,0);//暂定无类型id为0
//		
//		int id_shoes = 0;
//		id_shoes = ResEnum.GetResIDByTypeAndID(id_shoes,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_SHOES,0);//暂定无类型id为0
//		
//		//材质资源
//		int id_eye_mat = 0;
//		id_eye_mat = ResEnum.GetResIDByTypeAndID(id_eye_mat,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_EYES_MAT,0);//暂定无类型id为0
//		
//		int id_face_mat = 0;
//		id_face_mat = ResEnum.GetResIDByTypeAndID(id_face_mat,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_FACE_MAT,0);//暂定无类型id为0
//		
//		int id_head_mat = 0;
//		id_head_mat = ResEnum.GetResIDByTypeAndID(id_head_mat,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_HEAD_MAT,0);//暂定无类型id为0
//		
//		int id_top_mat = 0;
//		id_top_mat = ResEnum.GetResIDByTypeAndID(id_top_mat,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_TOP_MAT,0);//暂定无类型id为0
//		
//		int id_hands_mat = 0;
//		id_hands_mat = ResEnum.GetResIDByTypeAndID(id_hands_mat,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_HANDS_MAT,0);//暂定无类型id为0
//		
//		int id_pants_mat = 0;
//		id_pants_mat = ResEnum.GetResIDByTypeAndID(id_pants_mat,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_PANTS_MAT,0);//暂定无类型id为0
//		
//		int id_shoes_mat = 0;
//		id_shoes_mat = ResEnum.GetResIDByTypeAndID(id_shoes_mat,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_SHOES_MAT,0);//暂定无类型id为0
//
//
//		int id_anim_group = 0;
//		id_anim_group = ResEnum.GetResIDByTypeAndID(id_anim_group,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_ROLE,ResEnum.RES_TYPE2_ROLE_ANIMGROUP,0);//暂定无类型id为0
//


		//[创建资源总表]---apkresinfo.bytes------------------------------------------------------------------
		buf.Clear();
		buf.PutInt(19);//资源条数
		
		//加入scnid配表资源
		//buf.PutInt(id_scnID);//资源ID
		//buf.PutByte((byte)0);//卸载类型
		//buf.PutString("scnid");//资源名
		//buf.PutInt(0);//依赖资源数
		
		//加入scnInfo配表资源
		buf.PutString("table/scene/scninfo0.bytes");//资源ID
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)0);//打包类型，单独打包  //TODO bytes资源是否是单独打包没什么区别，这个参数对于bytes类型是多余的，bytes和bundle加载走的不同逻辑，加或不加都不会出错
		buf.PutString("scninfo0");//资源名
		buf.PutInt(0);//依赖资源数   //TODO 需要考虑下还要不要这个依赖资源数
		
		//加入mapInfo配表资源
		buf.PutString("table/map/mapinfo0.bytes");//资源ID
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)0);//打包类型，单独打包
		buf.PutString("mapinfo0");//资源名
		buf.PutInt(0);//依赖资源数
		
		//加入terrain资源
		buf.PutString("res/map/terrain0.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)0);//打包类型，单独打包
		buf.PutString("terrain0");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/female_basebone.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)0);//打包类型，单独打包
		buf.PutString("female_basebone");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/female_eyes.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)1);//打包类型，多资源打包
		buf.PutString("female_eyes");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/female_face-1.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)1);//打包类型，多资源打包
		buf.PutString("female_face-1");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/female_hair-1.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)1);//打包类型，多资源打包
		buf.PutString("female_hair-1");//资源名
		buf.PutInt(0);//依赖资源数


		buf.PutString("res/role/female_top-1.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)1);//打包类型，多资源打包
		buf.PutString("female_top-1");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/female_hands-1.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)1);//打包类型，多资源打包
		buf.PutString("female_hands-1");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/female_pants-1.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)1);//打包类型，多资源打包
		buf.PutString("female_pants-1");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/female_shoes-1.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)1);//打包类型，多资源打包
		buf.PutString("female_shoes-1");//资源名
		buf.PutInt(0);//依赖资源数



		buf.PutString("res/role/female_eyes_blue.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)0);//打包类型，单独打包
		buf.PutString("female_eyes_blue");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/female_face-colorA.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)0);//打包类型，单独打包
		buf.PutString("female_face-colorA");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/female_hair-1_brown.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)0);//打包类型，单独打包
		buf.PutString("female_hair-1_brown");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/female_top-1_blue.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)0);//打包类型，单独打包
		buf.PutString("female_top-1_blue");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/female_hands_blue.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)0);//打包类型，单独打包
		buf.PutString("female_hands_blue");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/female_pants-1_blue.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)0);//打包类型，单独打包
		buf.PutString("female_pants-1_blue");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/female_shoes-1_blue.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)0);//打包类型，单独打包
		buf.PutString("female_shoes-1_blue");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/female_anim_common.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)1);//打包类型，多资源打包
		buf.PutString("female_anim_common");//资源名
		buf.PutInt(0);//依赖资源数


		b = buf.ToArray();
		FileHelper.WriteBytes2File(EditorHelper.OUTPUT_TABLE_SYSTEM_PATH+"/apkresinfo.bytes",b);
	}

	static void CreateScnInfo(){
		//创建scnInfo配表---------------------------------------------------------
		buf.Clear();
		int MapID = 0;
		buf.PutInt(MapID);
		//TODO 这里以后向下补充副本相关信息
		b = buf.ToArray();
		FileHelper.WriteBytes2File(EditorHelper.OUTPUT_TABLE_SCENE_PATH+"/scninfo0.bytes",b);
	}

	static void CreatMapInfo(){
		//创建mapInfo配表---------------------------------------------------------
		buf.Clear();
		//buf.PutByte(0);//MapID
		buf.PutShort(200);//XWidth
		buf.PutShort(200);//ZWidth
		buf.PutString("TestMap");//MapName
		//int MapInfoTableResID =0;
		//MapInfoTableResID =	ResEnum.GetResIDByTypeAndID(MapInfoTableResID,ResEnum.RES_TYPE0_BYTES,ResEnum.RES_TYPE1_MAP,ResEnum.RES_TYPE2_MAP_INFO,0);
//		int MapBlockTableResID = 0;
//		MapBlockTableResID = ResEnum.GetResIDByTypeAndID(MapBlockTableResID,ResEnum.RES_TYPE0_BYTES,ResEnum.RES_TYPE1_MAP,ResEnum.RES_TYPE2_MAP_BLOCK,0);
//		int MapEventTableResID = 0;
//		MapEventTableResID =	ResEnum.GetResIDByTypeAndID(MapEventTableResID,ResEnum.RES_TYPE0_BYTES,ResEnum.RES_TYPE1_MAP,ResEnum.RES_TYPE2_MAP_BLOCK,0);
//		int MapTerrainResID = 0;
//		MapTerrainResID =	ResEnum.GetResIDByTypeAndID(MapTerrainResID,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_MAP,ResEnum.RES_TYPE2_MAP_TERRAIN,0);
//		int MapLightResID = 0;
//		MapLightResID =	ResEnum.GetResIDByTypeAndID(MapLightResID,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_MAP,ResEnum.RES_TYPE2_MAP_LIGHT,0);
//		int MapObjResID = 0;
//		MapObjResID =	ResEnum.GetResIDByTypeAndID(MapObjResID,ResEnum.RES_TYPE0_PREFAB,ResEnum.RES_TYPE1_MAP,ResEnum.RES_TYPE2_MAP_OBJ,0);
		
		//buf.PutInt(MapInfoTableResID);
		buf.PutString("MapBlockTableResID");
		buf.PutString("MapEventTableResID");
		buf.PutString("res/map/terrain0.n");//就这一个有效数据，其他数据读取时都掠过了
		buf.PutString("MapLightResID");
		buf.PutString("MapObjResID");
		
		b = buf.ToArray();
		
		//Debug.Log("生成size:"+b.Length);
		
		FileHelper.WriteBytes2File(EditorHelper.OUTPUT_TABLE_MAP_PATH+"/mapinfo0.bytes",b);

	}

	static string[] boneNames ={
		"a","b","c"
	};

	//因为没模型，目前引用的模型少个手，临时创建一个手
	static void CreateRoleHandsBundle(){
		//---模拟创建手部mat，里面用单独打包放入一个空材质
		string path = Path.GetDirectoryName(Application.dataPath)+"/data/res/role/";
		string matPath = path+"female_hands_blue.n";
		Material matHand = (Material)AssetDatabase.LoadAssetAtPath("Assets/NEditor/RoleEditor/Res/Female/Materials/female_hands_blue.mat", typeof(Material));

		if(null==matHand)Debug.Log("mat==null!!!!!!!!!!!!!!!!!!");

		if(File.Exists(matPath)){ File.Delete(matPath); }
		//BuildPipeline.BuildAssetBundle(matHand, null, matPath, BuildAssetBundleOptions.CollectDependencies);

		//---模拟创建手部模型
		List<Object> toinclude = new List<Object>();

		GameObject handGo = new GameObject();
		handGo.name="female_hands-1";
		handGo.AddComponent<SkinnedMeshRenderer>();
		Object rendererPrefab = EditorHelper.GeneratePrefab(handGo, "mesh");
		toinclude.Add(rendererPrefab);

		StringHolder sb = ScriptableObject.CreateInstance<StringHolder> ();//StringHolder类继承自ScriptableObject，可以被以asset形式打入bundle包，stringHolder中有string[] 存储boneNames
		sb.content = boneNames;
		string stringholderpath = "Assets/bonenames.asset";
		AssetDatabase.CreateAsset(sb, stringholderpath);
		toinclude.Add(AssetDatabase.LoadAssetAtPath(stringholderpath, typeof (StringHolder)));

		string modlePath = path + "female_hands-1.n";
		if(File.Exists(path)){File.Delete(path);}
		//BuildPipeline.BuildAssetBundle(null, toinclude.ToArray(), modlePath, BuildAssetBundleOptions.CollectDependencies);

		GameObject.DestroyImmediate(handGo);

		AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(rendererPrefab));//清理临时mesh.asset
		AssetDatabase.DeleteAsset(stringholderpath);//已经打包结束，删除临时创建的bonenames.asset
	

	}

}
