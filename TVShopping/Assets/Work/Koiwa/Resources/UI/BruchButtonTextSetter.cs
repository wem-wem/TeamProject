using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BruchButtonTextSetter : MonoBehaviour
{
    Button_Reaction BR;

    //テキスト格納用
    List<string> _A_button_text;
    List<string> _B_button_text;
    ScenarioSetter _scenario_ref;
    //
    //リスト型を取得する時は　
    //"string current_text =_A_buuton_text[0];"
    //こんな感じでできます.
    //なお、今回は、配列番号０からが、分岐の１回目のてきすとになってます

    // ボタンの数
    private const int ButtonNum = 2;
    private GameObject[] _buttons = new GameObject[ButtonNum];

    // 生成する為のフラグ
    // (これをON/OFFしてtextの番号を進めていく)
    private bool _disp_flag = true;
    private int _disp_count = 0;

    // 何秒後に消すかを指定
    [SerializeField]
    private float _delete_time = 5;
    // 表示からカウントを始める消去用のタイマー
    private float _delete_timer = 0;

    // 複数個同じボタンが作られないように制御
    private bool _doCreate = false;

    // ボタンに表示するテキスト
    private string _textA = null;
    private string _textB = null;

    [SerializeField]
    private GameObject _button = null;
    public GameObject Button
    {
        get
        {
            if (_button != null) { return _button; }
            _button = Resources.Load<GameObject>("UI/Button");
            return _button;
        }
    }

    void Start()
    {

        //リスト初期化
        _A_button_text = new List<string>();
        _B_button_text = new List<string>();
        _scenario_ref = GameObject.FindObjectOfType<ScenarioSetter>();


        //CSVデータから、テキストデータ等を読み込む
        var MasterTable = new BrunchTextMasterTable();
        MasterTable.Load();

        foreach (var Master in MasterTable.All)
        {
            //CSVファイルのルートナンバーが０だったら
            if (Master.RouteNumber == 0)
            {
                //Arouteにテキストを格納
                _A_button_text.Add(Master.ButtonText);

            }
            else if (Master.RouteNumber == 1)
            {
                //Brouteにテキストを格納
                _B_button_text.Add(Master.ButtonText);
            }

            // Listに全て格納した後に、０番目の文書を
            // ボタン描画用の変数に取得させる
        }

        _textA = _A_button_text[0];
        _textB = _B_button_text[0];

        BR = GetComponent<Button_Reaction>();
    }

    // ボタン一個分の情報を収納する関数
    // origin...生成するGameObject
    // num   ...生成したボタンの番号(ルート分岐用の数値)
    // text  ...生成したボタンに表示するテキスト
    private GameObject CreateGameObject(GameObject origin, int num, string text)
    {
        var prefab = Instantiate(origin);
        Canvas canvas = GetComponent<Canvas>();

        prefab.name = origin.name + "(" + num + ")";
        prefab.transform.parent = base.gameObject.transform;

        // 受け取ったプレハブの持っているTextにアクセスする
        foreach (Transform child in canvas.transform)
        {
            // 子の要素をたどる
            if (child.name == prefab.name)
            {
                // 名前が一致
                foreach (Transform child2 in child.transform)
                {
                    // 孫要素をたどる
                    if (child2.name == "Text")
                    {
                        // テキストを見つけた
                        Text t = child2.GetComponent<Text>();
                        // テキスト変更
                        t.text = text;
                    }
                }
            }
        }
        return prefab;
    }

    // ボタンの番号に応じたポジションにTranslateして表示
    private GameObject Create_DuoButton(int num)
    {
        switch (num)
        {
            case 0:
                transform.Translate(new Vector3(-(Screen.width / 4), -(Screen.height / 2), 0));
                return CreateGameObject(Button, num, _textB);

            case 1:
                transform.Translate(new Vector3(-(Screen.width / 4) * 2, 0, 0));
                return CreateGameObject(Button, num, _textA);
        }
        return null;
    }

    void Update()
    {
        // 指定した時間に、一度だけ生成
        if (!_doCreate)
        {
            for (var b = 0; b < ButtonNum; b++)
            {
                _buttons[b] = Create_DuoButton(b);
            }
            _doCreate = true;
        }
        // 時間切れなら削除
        if (_doCreate)
        {
            _delete_timer += Time.deltaTime;
            if (_delete_timer >= _delete_time)
            {
                _disp_count++;
                for (var b = 0; b < ButtonNum; b++)
                {
                    Destroy(_buttons[b]);
                }
                _doCreate = false;
                _delete_timer = 0;
                _textA = _A_button_text[_disp_count];
                _textB = _B_button_text[_disp_count];
            }
        }

        ClickToDelete();
    }

    // クリックされたら削除
    void ClickToDelete()
    {
        if (_buttons[0].GetComponent<Button_Reaction>().isClick ||
            _buttons[1].GetComponent<Button_Reaction>().isClick)
        {
            for (int i = 0; i < ButtonNum; i++)
            {
                Destroy(_buttons[i]);
            }
        }
    }
}
