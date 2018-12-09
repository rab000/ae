using UnityEngine;
using System.Collections;

public class TGui : MonoBehaviour {

	Rect win = new Rect(0,0,200,200);

	void Start () {
	
	}
	

	void Update () {
	
	}

	void OnGUI(){
		win = GUI.Window (0,win,DoWin,"fuckWin");
	}

	void DoWin(int winID){
		GUI.DragWindow (new Rect(0, 0, 100, 100));
	}
}
