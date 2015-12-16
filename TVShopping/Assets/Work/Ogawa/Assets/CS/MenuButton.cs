using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MenuButton : MonoBehaviour
{
    //スコア加算
    private IEnumerator _itarator;

    //売り上げスコア
    [SerializeField]
    private Text _E_scoreText;
    [SerializeField]
    private int _moneyScore = 0;

    //視聴率
    [SerializeField]
    private Text _A_r_scoreText;

    //最大1000 = 100.0%計算(端数加算のため)
    [SerializeField]
    private int _TVScore = 0;
    //1の位から
    private int _Score_plus = 0;
    //端数用
    private int _Score_index = 0;

    //メニューへ戻るボタンの設定
    [SerializeField]
    private Button _menuButton;

    //もう一度遊ぶボタンの設定
    [SerializeField]
    private Button _gameButton;

    //ボタンの入力可能ボタン
    [SerializeField]
    private bool _OnButton = false;


    private IEnumerator ScorePlus()
    {
        yield return null;
        while (true)
        {
            //売り上げを表示
            yield return StartCoroutine(GetScore());

            //間隔
            yield return new WaitForSeconds(1);

            //視聴率を表示
            yield return StartCoroutine(GetScorePlus());
        }
    }

    // Use this for initialization
    private void Start()
    {

        //ボタン入力
        _menuButton.onClick.AddListener(MainMenu);
        _gameButton.onClick.AddListener(MainGame);

        //スコア加算
        StartCoroutine(ScorePlus());
    }

    private IEnumerator GetScore()
    {
        _E_scoreText.text = _moneyScore.ToString() + "$";
        yield return null;
    }

    private IEnumerator GetScorePlus()
    {
        //スコア加算が終わっていなければ
        if (_Score_plus != _TVScore / 10)
        {
            for (var i = 0; i < (_TVScore / 10) + 1; i ++)
            {

                

                //スコア加算が終わったら
                if (i == _TVScore / 10)
                {
                    //端数を固定
                    _Score_index = _TVScore % 10;

                    //スコアを加算
                    _Score_plus = i;
                    //テキストに反映
                    _A_r_scoreText.text = _Score_plus.ToString() + "." + _Score_index.ToString() + "％";

                    break;
                }

                //端数をランダムで表示
                _Score_index = Random.Range(0, 9);

                //スコアを加算
                _Score_plus = i;
                
                //テキストに反映
                _A_r_scoreText.text = _Score_plus.ToString() +"."+ _Score_index.ToString() +"％";

                yield return null;
            }
        }
        //スコア加算が終わっていたら
        else
        {
            //ボタン入力を許可
            _OnButton = true;
            yield return null;
        }
    }

    private void MainGame()
    {
        //ボタン入力が可能なら
        if (_OnButton) Application.LoadLevel("Sato");
    }
    private void MainMenu()
    {
        //ボタン入力が可能なら
        if (_OnButton) Application.LoadLevel("Nishimaki");
    }
}
