using UnityEngine;
using System.Collections;

public class RenderLines : MonoBehaviour {
	private LineRenderer line;
	private Vector3 mousePosition;
	private Vector3 mouseWorld;
	public Camera gameCamera;

	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer> ();
		line.SetWidth(0.1f, 0.1f);
		line.SetVertexCount(2);
		gameCamera = GameObject.FindObjectOfType<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = Input.mousePosition;
		mousePosition.z = gameObject.transform.position.z;
		mouseWorld = gameCamera.ScreenToWorldPoint(mousePosition);

		UpdateLine ();
	}


	//Modified code from http://answers.unity3d.com/questions/184442/drawing-lines-from-mouse-position.html
	void UpdateLine()
	{


		line.SetPosition(0, gameObject.transform.position);
		line.SetPosition (1, mouseWorld);

	}
}
