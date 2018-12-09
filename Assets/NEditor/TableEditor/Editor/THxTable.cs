using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class THxTable : MonoBehaviour {

	static IoBuffer buf = new IoBuffer(102400);

	static byte[] b;


	[MenuItem ("NEditor/TableEditor/CreateTempHxTable")]
	static void CreateTempTable(){

		CreateResInfoTable();//资源总表

		CreateScnInfo();//场景信息表

		CreatMapInfo();//地图信息表


	}


	/// <summary>
	/// 资源总表
	/// </summary>
	static void CreateResInfoTable(){

		//[创建资源总表]---apkresinfo.bytes------------------------------------------------------------------
		buf.Clear();
		buf.PutInt(14);//资源条数

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

		buf.PutString("res/role/hx_basebone.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)0);//打包类型，单独打包
		buf.PutString("hx_basebone");//资源名
		buf.PutInt(0);//依赖资源数

//		buf.PutString("res/role/female_eyes.n");
//		buf.PutByte((byte)0);//卸载类型
//		buf.PutByte((byte)1);//打包类型，多资源打包
//		buf.PutString("female_eyes");//资源名
//		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/hx_face.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)1);//打包类型，多资源打包
		buf.PutString("hx_face-1");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/hx_head.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)1);//打包类型，多资源打包
		buf.PutString("hx_head");//资源名
		buf.PutInt(0);//依赖资源数


		buf.PutString("res/role/hx_top.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)1);//打包类型，多资源打包
		buf.PutString("hx_top");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/hx_hand.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)1);//打包类型，多资源打包
		buf.PutString("hx_hand");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/hx_down.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)1);//打包类型，多资源打包
		buf.PutString("hx_down");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/hx_shoes.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)1);//打包类型，多资源打包
		buf.PutString("hx_shoes");//资源名
		buf.PutInt(0);//依赖资源数



		buf.PutString("res/role/hanxin.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)0);//打包类型，单独打包
		buf.PutString("hanxin");//资源名
		buf.PutInt(0);//依赖资源数

//		buf.PutString("res/role/female_face-colorA.n");
//		buf.PutByte((byte)0);//卸载类型
//		buf.PutByte((byte)0);//打包类型，单独打包
//		buf.PutString("female_face-colorA");//资源名
//		buf.PutInt(0);//依赖资源数
//
//		buf.PutString("res/role/female_hair-1_brown.n");
//		buf.PutByte((byte)0);//卸载类型
//		buf.PutByte((byte)0);//打包类型，单独打包
//		buf.PutString("female_hair-1_brown");//资源名
//		buf.PutInt(0);//依赖资源数
//
//		buf.PutString("res/role/female_top-1_blue.n");
//		buf.PutByte((byte)0);//卸载类型
//		buf.PutByte((byte)0);//打包类型，单独打包
//		buf.PutString("female_top-1_blue");//资源名
//		buf.PutInt(0);//依赖资源数
//
//		buf.PutString("res/role/female_hands_blue.n");
//		buf.PutByte((byte)0);//卸载类型
//		buf.PutByte((byte)0);//打包类型，单独打包
//		buf.PutString("female_hands_blue");//资源名
//		buf.PutInt(0);//依赖资源数
//
//		buf.PutString("res/role/female_pants-1_blue.n");
//		buf.PutByte((byte)0);//卸载类型
//		buf.PutByte((byte)0);//打包类型，单独打包
//		buf.PutString("female_pants-1_blue");//资源名
//		buf.PutInt(0);//依赖资源数
//
//		buf.PutString("res/role/female_shoes-1_blue.n");
//		buf.PutByte((byte)0);//卸载类型
//		buf.PutByte((byte)0);//打包类型，单独打包
//		buf.PutString("female_shoes-1_blue");//资源名
//		buf.PutInt(0);//依赖资源数
//
		buf.PutString("res/role/hx_anim_common.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)1);//打包类型，多资源打包
		buf.PutString("hx_anim_common");//资源名
		buf.PutInt(0);//依赖资源数

		buf.PutString("res/role/hx_anim_sk1.n");
		buf.PutByte((byte)0);//卸载类型
		buf.PutByte((byte)1);//打包类型，多资源打包
		buf.PutString("hx_anim_sk1");//资源名
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
}
