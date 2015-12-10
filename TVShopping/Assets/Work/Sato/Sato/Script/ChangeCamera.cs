using UnityEngine;
using System.Collections;

public class ChangeCamera : MonoBehaviour {


	[SerializeField]//カメラ管理用格納庫
	Camera[] SubCamera;
	//現在の表示されてるカメラの配列番号
	int _camera_number;
	private int _set_number;
	public int _SetNumber {

		get{ return _set_number; }

		set {
			if (value != -1 && value  != _camera_number) {
				Debug.Log (Time.time + "SetCamera");
			    SubCamera [_set_number].enabled = false;
				_set_number = value;
				SubCamera [_set_number].enabled = true;
				CurrentCamera = SubCamera [_set_number];
			}
		}
	}

	public Camera CurrentCamera{ get; set;}

	// Use this for initialization
	void Start () {
		_set_number = 0;
		_camera_number = 0;
		CurrentCamera = SubCamera [0];
		SubCamera [0].enabled = true;//MainCameraからスタート
		SubCamera [1].enabled = false;
		SubCamera [2].enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		//Debug用
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
		
			//写してるカメラをオフ
			SubCamera [_camera_number].enabled = false;
			if (_camera_number < SubCamera.Length - 1) {
				_camera_number++;
			} else {
				_camera_number = 0;
			}
			SubCamera [_camera_number].enabled = true;
			CurrentCamera = SubCamera [_camera_number];
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			CameraTarget ();
		}


	}
	//デバッグ用カメラをチェンジ
	void SetCamera(int set_camera_number = 0){

		SubCamera [_camera_number].enabled = false;
		SubCamera [set_camera_number].enabled = true;

	}
	//Target
	void CameraTarget(){
		//Debug.用
		SubCamera [_camera_number].transform.LookAt(GameObject.FindGameObjectWithTag("MainGoods").transform);

	}


}
