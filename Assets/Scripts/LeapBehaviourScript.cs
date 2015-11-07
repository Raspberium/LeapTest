using UnityEngine;
using System.Collections;
using Leap;

public class LeapBehaviourScript : MonoBehaviour {

    //LeapMotionのコントローラー
    Controller controller = new Controller();

	void Start () {	
	}
	

	void Update () {
	//LeapMotionの更新情報を取得する
        var frame = controller.Frame();

        //一番前にある指を取得する
        var finger = frame.Fingers.Frontmost;

        //座標変換のためのオブジェク
        var iBox = frame.InteractionBox;

        //認識した指が有効である場合
        if (finger.IsValid) {
            //unityで扱いやすい座標に変換する
            var position = iBox.NormalizePoint(finger.TipPosition);

            //座標を調整する
            position *= 10;
            //position.x -= 5;
            //position.z = (-position.z) + 5;

            //unityの座標クラスに変換する
            transform.localPosition = new Vector3(0, position.y, 0);
            //transform.localPosition = new Vector3(position.x, position.y, position.z);
        }
	}
}
