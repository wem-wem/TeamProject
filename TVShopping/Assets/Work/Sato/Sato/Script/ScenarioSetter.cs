using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ScenarioSetter : MonoBehaviour {


	public enum Route
	{
		Main,
		A,
		B,
		C,
		NULL,

	}

	public struct Scenariodate
	{

		public string _text_date;
		public float _time;
		public Route _next_route;
		//public bool _change_flag;


		public Scenariodate(string text_date,int time ,Route next_route = Route.Main)
		{
			this._text_date = text_date;
			//_change_flag = change_flag;
			this._next_route = next_route;
			this._time = time;
		}
	}




	//メインシナリオ
	[SerializeField]
	TextAsset _route_Main;
	//ルート分岐時のシナリオ　A B C
	[SerializeField]
	TextAsset _route_A;
	[SerializeField]
	TextAsset _route_B;
	[SerializeField]
	TextAsset _route_C;
	//テキスト格納用
	List<Scenariodate> _Main = new List<Scenariodate>();
	List<Scenariodate> _A = new List<Scenariodate>();
	List<Scenariodate> _B = new List<Scenariodate>();
	List<Scenariodate> _C = new List<Scenariodate>();

	string[] _main_route_text;
	string[] _A_route_text;
	string[] _B_route_text;
	string[] _C_route_text;

	Route _current_route;
	string _current_text;
	float _timer;
	int[,] _current_text_number = new int[3,1];
	//フォント用変数
    public GUISkin s_Skin;
	GUIStyle Style;
	GUIStyleState State;


	int _main_text_number;
	int _another_text_number;

	public float[] timer;

	int gameroot = 0;

	// Use this for initialization
	void Start () {


		Style = new GUIStyle();
		State = new GUIStyleState();

		_main_route_text = _route_Main.text.Split('/');
		for (int i = 0; i < _main_route_text.Length; i++) {

			if (i == 5) {

				_Main.Add (new Scenariodate (_main_route_text [i], 1,Route.NULL));
				continue;
			}
			_Main.Add (new Scenariodate (_main_route_text [i], 1));

		

		}

		//テキストデータから、シナリオを読み込む.
		// "/"スラッシュで次の配列に格納.
		_A_route_text = _route_A.text.Split('/');
		_B_route_text = _route_B.text.Split('/');
		_C_route_text = _route_C.text.Split('/');

		_timer = _Main [0]._time;
		_current_text = _Main [0]._text_date;
		_current_route = Route.Main;
		//StartCoroutine(WaitTimeAndGo());

	}


	// Update is called once per frame
	void Update () {


		//ルート定まっている場合のみ実行
		if (_current_route != Route.NULL) {
		
		
			if (_timer >= 0) {
			
				_timer -= Time.deltaTime;

			} 
			else {

				switch (_current_route) {
				case Route.Main:

					_current_text = _Main [_current_text_number [(int)Route.Main, 0]]._text_date;
					_timer = _Main [_current_text_number [(int)Route.Main, 0]]._time;
					_current_route = _Main [_current_text_number [(int)Route.Main, 0]]._next_route;
					_current_text_number [(int)Route.Main, 0]++;
					break;

				case Route.A:
					_current_text = _Main [_current_text_number[(int)Route.A,0]]._text_date;
					_timer = _Main [_current_text_number[(int)Route.A,0]]._time;
					_current_route = _Main [_current_text_number[(int)Route.A,0]]._next_route;
					_current_text_number [(int)Route.A, 0]++;

					break;

				case Route.B:
					_current_text = _Main [_current_text_number[(int)Route.B,0]]._text_date;
					_timer = _Main [_current_text_number[(int)Route.B,0]]._time;
					_current_route = _Main [_current_text_number[(int)Route.B,0]]._next_route;
					_current_text_number [(int)Route.B, 0]++;

					break;
				case Route.C:
					_current_text = _Main [_current_text_number [(int)Route.C, 0]]._text_date;
					_timer = _Main [_current_text_number [(int)Route.C, 0]]._time;
					_current_route = _Main [_current_text_number [(int)Route.C, 0]]._next_route;
					_current_text_number [(int)Route.C, 0]++;

					break;

				}

			}
		
		
		}


		if (_current_route == Route.NULL) {
		
		
			_current_text = "";
			if (Input.GetMouseButtonDown (0)) {
			
				_current_route = Route.Main;
			
			}
		
		}

		//if (Input.GetMouseButtonDown(0))
		//{
		//    text_number++;

		//}else
		//for (int i = 0; i < Input.touchCount; i++)
		//{

		//    Touch touch = Input.GetTouch(i);

		//    if (touch.phase == TouchPhase.Began)
		//    {
		//}
		//}
		/*
		if (text.Length-1 == text_number)
		{
			Application.LoadLevel(scene);
		}
*/



	}




	IEnumerator WaitTimeAndGo()
	{
		for (int i = 0; i < timer.Length;i++ )
		{
			Debug.Log(timer);
			yield return new WaitForSeconds(timer[i]);
			//text_number++;
		}
	}

	void OnGUI()
	{

		GUI.skin = s_Skin;

		Style.fontSize = Screen.height/22;
		Style.normal = State;

		State.textColor = Color.black;

		GUI.Label(new Rect(Screen.width/25, Screen.height / 2 + Screen.height / 4, 0, Screen.height / 10), _current_text, Style);

	}
}
