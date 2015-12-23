using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button_Reaction : MonoBehaviour
{
    public bool isClick = false;
    ScenarioSetter.Route _scenario_ref;

    public void OnClick()
    {
        isClick = true;

        if (this.name == "Button(0)")
        {
            _scenario_ref = ScenarioSetter.Route.A;
            Debug.Log(_scenario_ref);
        }

        if (this.name == "Button(1)")
        {
            _scenario_ref = ScenarioSetter.Route.B;
            Debug.Log(_scenario_ref);
        }

        if (this.name == "Button(2)")
        {
            _scenario_ref = ScenarioSetter.Route.C;
            Debug.Log(_scenario_ref);
        }
    }

    void Start()
    {
        // _scenario_ref の初期化方法を聞く必要あり
        //_scenario_ref = GameObject.FindObjectOfType<ScenarioSetter>().SetRoute;
    }
}
