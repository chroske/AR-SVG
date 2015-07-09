using UnityEngine;
using UnityEditor;
using System.Collections;

public class EditorExWindow : EditorWindow
{
	[MenuItem("Window/EditorEx")]
	static void Open()
	{
		EditorWindow.GetWindow<EditorExWindow>( "EditorEx" );
	}

	string textArea = "";

	void OnGUI()
	{
		if( GUILayout.Button("Find  Objects") )
		 	Find();
		GUILayout.Label( "TextArea" );
		textArea = GUILayout.TextArea( textArea );

	}

	private void Find (){
		// TextAreaクリア
		textArea = "";
		foreach (GameObject obj in UnityEngine.Resources.FindObjectsOfTypeAll(typeof(GameObject)))
		{
			// アセットからパスを取得.シーン上に存在するオブジェクトの場合,シーンファイル（.unity）のパスを取得.
			string path = AssetDatabase.GetAssetOrScenePath(obj);
			// シーン上に存在するオブジェクトかどうか文字列で判定.
			bool isScene = path.Contains(".unity");
			// シーン上に存在するオブジェクトならば処理.
			if (isScene)
			{
				// GameObjectの名前を表示.
				Debug.Log(obj.name);
				textArea += obj.name + "\n";
			}
		}
	}
}