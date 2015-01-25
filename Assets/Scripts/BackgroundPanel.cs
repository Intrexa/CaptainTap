using UnityEngine;
using System.Collections;

public class BackgroundPanel : MonoBehaviour {

	public Material background;

	// Use this for initialization
	void Start () {
		Vector3 point1 = Camera.main.ScreenToWorldPoint(new Vector3(0,0,Camera.main.farClipPlane-1));
		Vector3 point2 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.farClipPlane-1));
		Vector2 dimensions = new Vector2(point1.x -point2.x,point1.y-point2.y)*0.5f;
		
		//Create Background Plane
		Mesh m = new Mesh();
		m.name = "Background";
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

		transform.renderer.material = background;
		Vector3 pos = transform.position;
		pos.z = 600;
		transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
