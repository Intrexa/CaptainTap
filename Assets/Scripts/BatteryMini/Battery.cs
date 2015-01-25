using UnityEngine;
using System.Collections;

namespace _Battery{
	public class Battery : MonoBehaviour {

		private float speed = 3f;

		public Vector3 wall1Pos;
		public Vector3 wall1Size;
		public Vector3 wall2Pos;
		public Vector3 wall2Size;
		public Vector3 wall3Pos;
		public Vector3 wall3Size;
		public Vector3 wall4Pos;
		public Vector3 wall4Size;
		public Vector3 wall5Pos;
		public Vector3 wall5Size;
		private BatteryStep curStep = BatteryStep.Wall1;
		public TouchPattern touchPattern;
		// Use this for initialization
		void Start () {

			GetComponent<TapHandler>().TapAction += tapEvent;
			GetComponent<SwipeHandler>().UpSwipeAction += upSwipeEvent;
			GetComponent<SwipeHandler>().DownSwipeAction += downSwipeEvent;
			GetComponent<SwipeHandler>().LeftSwipeAction += leftSwipeEvent;
			GetComponent<SwipeHandler>().RightSwipeAction += rightSwipeEvent;

		}

		private void handleTouch(TouchType touchType)
		{
			if (curStep == BatteryStep.Wall1 && touchType == TouchType.leftSwipeAction) {
						GameObject.Find ("BatteryScene").GetComponent<BatteryScene> ().handleGesture (Performance.perfect);
				} else if (curStep == BatteryStep.Wall2 && touchType == TouchType.tapAction) {
						GameObject.Find ("BatteryScene").GetComponent<BatteryScene> ().handleGesture (Performance.perfect);
			} else if (curStep == BatteryStep.Wall3 && touchType == TouchType.tapAction) {
						// No ActionGameObject.Find ("BatteryScene").GetComponent<BatteryScene> ().handleGesture (Performance.perfect);
			} else if (curStep == BatteryStep.Wall4 && touchType == TouchType.upSwipeAction) {
						GameObject.Find ("BatteryScene").GetComponent<BatteryScene> ().handleGesture (Performance.perfect);
				} else {
						GameObject.Find ("BatteryScene").GetComponent<BatteryScene> ().handleGesture (Performance.miss);
				}

		}

			



		public bool advanceStep()
		{
			switch (curStep) {
			case BatteryStep.Wall1:
				transform.position = wall2Pos;
				transform.localScale = wall2Size;
				curStep = BatteryStep.Wall2;
				return true;
				break;
			case BatteryStep.Wall2:
				transform.position = wall3Pos;
				transform.localScale = wall3Size;
				curStep = BatteryStep.Wall3;
				return true;
				break;
			case BatteryStep.Wall3:
				transform.position = wall4Pos;
				transform.localScale = wall4Size;
				curStep = BatteryStep.Wall4;
				return true;
				break;
			case BatteryStep.Wall4:
				transform.position = wall5Pos;
				transform.localScale = wall5Size;
				curStep = BatteryStep.Wall5;
				return true;
				break;
			case BatteryStep.Wall5:
				destroy();
				return true;
				break;
			}
			return false;
		}

		// Update is called once per frame
		void Update() {

			 
		}
		
		void destroy() {
			Destroy (transform.gameObject);
			//start destroy animation
			//remove itself
		}

		private void tapEvent()
		{
			handleTouch(TouchType.tapAction);
		}
	
		private void leftSwipeEvent()
		{
			handleTouch(TouchType.leftSwipeAction);
		}
		
		private void downSwipeEvent()
		{
			handleTouch(TouchType.downSwipeAction);
		}
		
		private void rightSwipeEvent()
		{
			handleTouch(TouchType.rightSwipeAction);
		}
		
		private void upSwipeEvent()
		{
			handleTouch(TouchType.upSwipeAction);
		}
	}
}

