using UnityEngine;
using System.Collections;

namespace _Battery{
	public class Battery : MonoBehaviour {

		private float speed = 3f;

		private Vector3 curPos;
		public Vector3 midPos;
		public Vector3 endPos;
		private BatteryStep curStep = BatteryStep.start;
		public TouchType touch;
		// Use this for initialization
		void Start () {

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
	}
}