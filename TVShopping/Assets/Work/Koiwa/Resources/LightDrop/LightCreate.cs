using UnityEngine;
using System.Collections;

public class LightCreate : MonoBehaviour
{
    // このフラグで演出を呼び出す
    public bool _doPlay_LightDrop = true;

    private const int _MAX = 10;
    // 【照明】の情報を呼び出し
    [SerializeField]
    private GameObject _light = null;
    private GameObject[] _lights = new GameObject[_MAX];

    // 照明の生成を行う
    private GameObject CreateLight(GameObject origin, int num)
    {
        _lights[num] = Instantiate(origin);
        _lights[num].transform.position = new Vector3(Random.Range(5.0f, -5.0f), Random.Range(10.0f, 20.0f), 0);
        _lights[num].transform.parent = base.gameObject.transform;
        _lights[num].name = origin.name + "(" + num + ")";
        return _lights[num];
    }


    void Start()
    {
        for (int i = 0; i < _MAX; i++)
        {
            _lights[i] = _light;
        }
    }

    // 生成フラグ
    bool _doCreate = false;

    void Update()
    {
        // 演出のフラグをオンにし…
        if (_doPlay_LightDrop)
        {
            // 一度も生成していなければ…
            if (!_doCreate)
            {
                // 照明を10個生成
                for (int i = 0; i < _MAX; i++)
                {
                    CreateLight(_light, i);
                }
                _doCreate = true;
            }
        }
    }
}
