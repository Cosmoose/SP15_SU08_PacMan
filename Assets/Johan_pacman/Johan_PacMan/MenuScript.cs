using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	GUIStyle guiStyle = new GUIStyle();
	public Texture Play;
	public Texture Exit;
	public Texture SpaceMan;

	void OnGUI () {
		if (GUI.Button (new Rect (Screen.width * 0.0015f, Screen.height * 85 / 100f, 250f, 60f), Play, guiStyle)){
			Application.LoadLevel ("s_PAC_e_MAN");
		}
		if (GUI.Button (new Rect (Screen.width * 0, Screen.height * 95 / 100, 300, 50), Exit, guiStyle)){
			Application.Quit();
		}
		GUI.Label (new Rect (Screen.width / 2.8f, Screen.height * 2 /100f, 400f, 400f), SpaceMan);
	}
}
