using UnityEngine;
using System.Collections;

namespace _Battery{
public class BatteryScene : MonoBehaviour {

 
	private SceneStep currentStep = SceneStep.start;
		public Battery oldBattery;
		public Battery newBattery;
	


	public Transform foreground, background;
	private int[] rhythm;
	
	void Spawn(Vector3 position, float endposition, int rhythmIndex) {
//		GameObject asteroid = GameObject.Instantiate (Resources.Load("Prefabs/Asteroid")) as GameObject;

	}
	
	// Use this for initialization
	void Start () {
			name = "BatteryScene";
			GetComponent<TapHandler>().TapAction += handleGesture;
			GetComponent<SwipeHandler>().UpSwipeAction += handleGesture;
			GetComponent<SwipeHandler>().DownSwipeAction += handleGesture;
			GetComponent<SwipeHandler>().LeftSwipeAction += handleGesture;
			GetComponent<SwipeHandler>().RightSwipeAction += handleGesture;
			//foreground.position = new Vector3(foreground.position.x,foreground.position.y,Camera.main.nearClipPlane);
		
		if (background)
			background.position = new Vector3(background.position.x,background.position.y,Camera.main.farClipPlane-100);
	}
	private void handleGesture()
		{
			handleGesture(Performance.miss);
		}

		/// <summary>
		/// Grades the gesture and triggers the next step
		/// </summary>
		/// <returns>Returns how well you did</returns>
		/// <param name="result">Entering function is the highest level the result of the gesture can be</param>
	public Performance handleGesture(Performance result)
	{
			//TODO:
			//We got a touch event, see it's within time span
			//If it is, call the method to be 'graded'*/

		if (object.ReferenceEquals(null,result) || result == Performance.miss) {
				//call failure code
				return Performance.miss;
						}
		//TODO: Check time vs when we should have hit
		switch (currentStep) {
		case SceneStep.start:
				oldBattery.advanceStep();
				currentStep = SceneStep.removeOld;
				return result;
			break;
		case SceneStep.removeOld:
				if(oldBattery.advanceStep()){
					currentStep = SceneStep.grabNew;
				}
				return result;
			break;
		case SceneStep.grabNew:
				newBattery.advanceStep();
					currentStep = SceneStep.insertNew;
				return result;
			break;
		case SceneStep.insertNew:
				if(newBattery.advanceStep()){
					currentStep = SceneStep.end;
				}
				return result;
			break;
		case SceneStep.end:
				return result;
			break;
		}
			return result;
	}
	
	
	// Update is called once per frame
	void Update () {
			//handleGesture (null);

	}
}

}