using UnityEngine;
using System.Collections;

public class RenderLines : MonoBehaviour {
	private LineRenderer line;
	private Vector3 mousePosition;
	private Vector3 mouseWorld;
	public Camera gameCamera;
	public GameObject sphereCastTestObject;
	private Vector3 cueBallDirection;
	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer> ();
		line.SetWidth(0.1f, 0.1f);
		line.SetVertexCount(2);
		//gameCamera = GameObject.FindObjectOfType<Camera> ();
		Physics.sleepThreshold = 1000.0f;

	}
	
	// Update is called once per frame
	void Update () {
		//mousePosition = Input.mousePosition;
		//mousePosition.z = gameObject.transform.position.z;
		//mouseWorld = gameCamera.ScreenToWorldPoint(mousePosition);
		//mouseWorld.y = gameObject.transform.position.y;
		UpdateLine ();
	}

	
	void UpdateLine()
	{

		Ray mouseToWorldSpaceRay = gameCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		RaycastHit sphereHit;
		Debug.DrawRay(mouseToWorldSpaceRay.origin, mouseToWorldSpaceRay.direction * 100, Color.yellow);
		if (Physics.Raycast (mouseToWorldSpaceRay, out hit)) {
			cueBallDirection = (new Vector3(hit.point.x, this.gameObject.transform.position.y, hit.point.z) - gameObject.transform.position).normalized;
			if(Physics.SphereCast(this.gameObject.transform.position,0.25f, -cueBallDirection, out sphereHit))
			{			
				line.SetPosition(0,this.gameObject.transform.position);
				line.SetPosition(1,sphereHit.point);
			}
		}
		if (Input.GetMouseButtonDown(0)) {
			this.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3(-cueBallDirection.x,0,-cueBallDirection.z) * 5000.0f);
			Debug.Log (cueBallDirection.y);
		}

	}
}
