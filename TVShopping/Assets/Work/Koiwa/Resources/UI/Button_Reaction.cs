using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button_Reaction : MonoBehaviour
{
    private int _route = 0;
    public bool isClick = false;
    ScenarioSetter.Route _scenario_ref;
    // ルート取得用変数
    private int getRoute()
    {
        return _route;
    }

    void Update()
    {
        if (this.name == "Button(0)")
        {
            _route = 0;
            _scenario_ref = ScenarioSetter.Route.A;
        }

        if (this.name == "Button(1)")
        {
            _route = 1;
            _scenario_ref = ScenarioSetter.Route.B;

        }

        if (this.name == "Button(2)")
        {
            _route = 2;
            _scenario_ref = ScenarioSetter.Route.C;

        }
    }

    public void OnClick()
    {
        isClick = true;
        Debug.Log(_route);
    }

    void Start()
    {
        


    }
}
