using UnityEngine;
using System.Collections;

namespace _Battery{
	public class Battery : MonoBehaviour {

		private float speed = 3f;

		private Vector3 curPos;
		public Vector3 midPos;
		public Vector3 endPos;
		private BatteryStep curStep = BatteryStep.start;
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
			if (curStep == BatteryStep.start && touchType == TouchType.leftSwipeAction && touchPattern == TouchPattern.swipe_swipe) {
						GameObject.Find ("BatteryScene").GetComponent<BatteryScene> ().handleGesture (Performance.perfect);
				} else if (curStep == BatteryStep.moveMid && touchType == TouchType.downSwipeAction && touchPattern == TouchPattern.swipe_swipe
						&& transform.position == midPos) {
						GameObject.Find ("BatteryScene").GetComponent<BatteryScene> ().handleGesture (Performance.perfect);
				} else if (curStep == BatteryStep.start && touchType == TouchType.tapAction && touchPattern == TouchPattern.touch_swipe) {
						GameObject.Find ("BatteryScene").GetComponent<BatteryScene> ().handleGesture (Performance.perfect);
				} else if (curStep == BatteryStep.moveMid && touchType == TouchType.downSwipeAction && touchPattern == TouchPattern.touch_swipe
						&& transform.position == midPos) {
						GameObject.Find ("BatteryScene").GetComponent<BatteryScene> ().handleGesture (Performance.perfect);
				} else {
						GameObject.Find ("BatteryScene").GetComponent<BatteryScene> ().handleGesture (Performance.perfect);
				}

		}

			



		public bool advanceStep()
		{
			switch (curStep) {
			case BatteryStep.start:
				curStep = BatteryStep.moveMid;
				return true;
				break;
			case BatteryStep.moveMid:
				if (transform.position == midPos){
					curStep = BatteryStep.moveEnd;
					return true;
				}
				return false;
				break;
			case BatteryStep.moveEnd:
				if (transform.position == endPos){
					curStep = BatteryStep.end;
					return true;
				}
				return false;
				break;
			case BatteryStep.end:
				destroy();
				return true;
				break;
			}
			return false;
		}

		// Update is called once per frame
		void Update() {

		switch (curStep) {
			case BatteryStep.start:
				//curStep = BatteryStep.moveMid;
				break;
			case BatteryStep.moveMid:
				transform.position = Vector3.MoveTowards(transform.position, midPos, speed * Time.deltaTime);
				if (transform.position == midPos){
					//curStep = BatteryStep.moveEnd;
				}
				break;
			case BatteryStep.moveEnd:
				transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
				if (transform.position == endPos){
					//curStep = BatteryStep.end;
				}
				break;
			case BatteryStep.end:
				destroy();
				break;
				}

			 
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

