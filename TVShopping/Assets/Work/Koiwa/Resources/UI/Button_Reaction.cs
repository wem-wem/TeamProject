using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button_Reaction : MonoBehaviour
{
    Create_Button CButton;

    private int _route = 0;
    bool isClick = false;

    // ルート取得用変数
    private int getRoute()
    {
        return _route;
    }

    void Start()
    {
        CButton = GetComponent<Create_Button>();
    }

    void Update()
    {
        if (this.name == "Button(0)")
        {
            _route = 0;
        }

        if (this.name == "Button(1)")
        {
            _route = 1;
        }

        if (this.name == "Button(2)")
        {
            _route = 2;
        }
    }

    public void OnClick()
    {
        Debug.Log(_route);
    }
}
