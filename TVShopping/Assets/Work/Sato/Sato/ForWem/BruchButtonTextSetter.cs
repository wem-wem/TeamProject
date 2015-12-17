using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BruchButtonTextSetter : MonoBehaviour {

	//テキスト格納用
	List<string> _A_button_text;
	List<string> _B_button_text;
	//
	//リスト型を取得する時は　
	//"string current_text =_A_buuton_text[0];"
	//こんな感じでできます.
	//なお、今回は、配列番号０からが、分岐の１回目のてきすとになってます


	// Use this for initialization
	void Start () {

		//リスト初期化
		_A_button_text = new List<string> ();
		_B_button_text = new List<string> ();

		//CSVデータから、テキストデータ等を読み込む
		var MasterTable = new BrunchTextMasterTable();
		MasterTable.Load();
		foreach (var Master in MasterTable.All)
		{
			//CSVファイルのルートナンバーが０だったら
			if (Master.RouteNumber == 0) {
				//Arouteにテキストを格納
				_A_button_text.Add(Master.ButtonText);
			
			} else if (Master.RouteNumber == 1) {
				//Brouteにテキストを格納
				_B_button_text.Add(Master.ButtonText);

			}

		}
		//Debug用
		foreach (var Atext in _A_button_text) {
			Debug.Log (Atext);
		}
		foreach (var Btext in _B_button_text) {
			Debug.Log (Btext);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
