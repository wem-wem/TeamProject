using UnityEngine;
using System.Collections;

public class hakusixyutoumeivew : MonoBehaviour {

    public GameObject _prefab;


   

    void Start()
    {

        _prefab = Resources.Load("Prefabs/hakusixyutoumei") as GameObject;

        Instantiate(_prefab, transform.position, Quaternion.identity);

    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel("Nishimaki");
        }

    }


}
