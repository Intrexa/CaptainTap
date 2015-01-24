
using UnityEngine;
using System.Collections;

public class MinigameOLD : MonoBehaviour {

	public int quad;
	public float width, height;

	void Start()
	{	
		float panelZDistance = transform.parent.GetComponent<GamePanel>().panelZDistance;
		Vector3 point1 = Camera.main.ScreenToWorldPoint(new Vector3(0,0,Camera.main.nearClipPlane + panelZDistance));
		Vector3 point2 = Camera.main.ScreenToWorldPoint(new Vector3(width,height,Camera.main.nearClipPlane + panelZDistance));
		Vector2 dimensions = new Vector2(point1.x -point2.x,point1.y-point2.y)*0.5f;
		
		//Create Background Plane
		Mesh m = new Mesh();
		m.name = "Minigame " + quad;
		m.vertices = new Vector3[] {
			new Vector3(-dimensions.x,0,-dimensions.y),
			new Vector3(-dimensions.x,0,dimensions.y),
			new Vector3(dimensions.x,0,dimensions.y),
			new Vector3(dimensions.x,0,-dimensions.y)
		};
		m.uv = new Vector2[] {
		new Vector2 (0, 0),
			new Vector2 (0, 1),
			new Vector2(1, 1),
			new Vector2 (1, 0)
		};
		m.triangles = new int[] { 0, 1, 2, 0, 2, 3};
		m.RecalculateNormals();

		GetComponent<MeshFilter>().mesh = m;
	}

	void OnEnable()
	{
	    // subscribe to gesture's Pan event
	    GetComponent<TapHandler>().TapAction += TappedTest;
	    GetComponent<SwipeHandler>().UpSwipeAction += UpSwipeTest;
	    GetComponent<SwipeHandler>().DownSwipeAction += DownSwipeTest;
	    GetComponent<SwipeHandler>().LeftSwipeAction += LeftSwipeTest;
	    GetComponent<SwipeHandler>().RightSwipeAction += RightSwipeTest;
	}

	void OnDisable()
	{
	    // subscribe to gesture's Pan event
	    GetComponent<TapHandler>().TapAction -= TappedTest;
	    GetComponent<SwipeHandler>().UpSwipeAction -= UpSwipeTest;
	    GetComponent<SwipeHandler>().DownSwipeAction -= DownSwipeTest;
	    GetComponent<SwipeHandler>().LeftSwipeAction -= LeftSwipeTest;
	    GetComponent<SwipeHandler>().RightSwipeAction -= RightSwipeTest;
	}

	private void TappedTest()
	{
		Debug.Log("TAPPED TEST EVENT");
	}

	private void DownSwipeTest()
	{
		Debug.Log("DOWN SWIPE TEST EVENT");
	}

	private void UpSwipeTest()
	{
		Debug.Log("UP SWIPE TEST EVENT");
	}

	private void LeftSwipeTest()
	{
		Debug.Log("LEFT SWIPE TEST EVENT");
	}

	private void RightSwipeTest()
	{
		Debug.Log("RIGHT SWIPE TEST EVENT");
	}
}
