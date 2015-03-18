using UnityEngine;
using System.Collections;

public class RenderLines : MonoBehaviour {
	private LineRenderer line;
	private Vector3 mousePosition;
	private Vector3 mouseWorld;
	public Camera gameCamera;
	public GameObject sphereCastTestObject;
	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer> ();
		line.SetWidth(0.1f, 0.1f);
		line.SetVertexCount(2);
		//gameCamera = GameObject.FindObjectOfType<Camera> ();

	}
	
	// Update is called once per frame
	void Update () {
		//mousePosition = Input.mousePosition;
		//mousePosition.z = gameObject.transform.position.z;
		//mouseWorld = gameCamera.ScreenToWorldPoint(mousePosition);
		//mouseWorld.y = gameObject.transform.position.y;
		UpdateLine ();
	}


	//Modified code from http://answers.unity3d.com/questions/184442/drawing-lines-from-mouse-position.html
	void UpdateLine()
	{

		Ray mouseToWorldSpaceRay = gameCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		RaycastHit sphereHit;
		Debug.DrawRay(mouseToWorldSpaceRay.origin, mouseToWorldSpaceRay.direction * 100, Color.yellow);
		if (Physics.Raycast (mouseToWorldSpaceRay, out hit)) {
			Vector3 cueBallDirection = (new Vector3(hit.point.x, 0.594f, hit.point.z) - gameObject.transform.position);
			sphereCastTestObject.transform.position = new Vector3(hit.point.x, 0.594f, hit.point.z);
			if(Physics.SphereCast(this.gameObject.transform.position,0.5f, -cueBallDirection, out sphereHit))
			{
			
				line.SetPosition(0,this.gameObject.transform.position);
				line.SetPosition(1,sphereHit.point);
			}
		}

	}
}
