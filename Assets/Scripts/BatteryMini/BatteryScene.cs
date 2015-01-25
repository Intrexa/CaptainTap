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
			handleGesture(null);
		}

	private void handleGesture(Event touchEvent)
	{
		switch (currentStep) {
		case SceneStep.start:
				oldBattery.advanceStep();
				currentStep = SceneStep.removeOld;
			break;
		case SceneStep.removeOld:
				if(oldBattery.advanceStep()){
					currentStep = SceneStep.grabNew;
				};
			break;
		case SceneStep.grabNew:
				newBattery.advanceStep();
					currentStep = SceneStep.insertNew;
			break;
		case SceneStep.insertNew:
				if(newBattery.advanceStep()){
					currentStep = SceneStep.end;
				}

			break;
		case SceneStep.end:
			break;
		}
	}
	
	
	// Update is called once per frame
	void Update () {
			//handleGesture (null);

	}
}

}