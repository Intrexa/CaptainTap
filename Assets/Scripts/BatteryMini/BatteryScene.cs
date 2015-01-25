using UnityEngine;
using System.Collections;

namespace _Battery{
public class BatteryScene : MonoBehaviour {

 
	private SceneStep currentStep = SceneStep.Wall1;
		public Battery newBattery;
		public Material Wall2;
		public Material Wall3;
		public Material Wall4;
		public Material Wall5;


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
			handleGesture(Performance.perfect);
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

			//Debug.Log (currentStep);
		//TODO: Check time vs when we should have hit
			newBattery.advanceStep();
			switch (currentStep) {
			case SceneStep.Wall1:
				renderer.material = Wall2;
				currentStep = SceneStep.Wall2;
				return result;
				break;
			case SceneStep.Wall2:
				renderer.material = Wall3;
				currentStep = SceneStep.Wall3;
				return result;
				break;
			case SceneStep.Wall3:
				renderer.material = Wall4;
				currentStep = SceneStep.Wall4;
				return result;
				break;
			case SceneStep.Wall4:
				renderer.material = Wall5;
				currentStep = SceneStep.Wall5;
				return result;
				break;
			case SceneStep.Wall5:
				//Finish this scene
				return result;
				break;
			default:
			
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