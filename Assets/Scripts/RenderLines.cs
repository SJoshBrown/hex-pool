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
		line.SetVertexCount(3);
		//gameCamera = GameObject.FindObjectOfType<Camera> ();
		//Physics.sleepThreshold = 1000.0f;

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

		Ray mouseToWorldSpaceRay = gameCamera.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		RaycastHit sphereHit;
		RaycastHit bounceHit;
		Debug.DrawRay (mouseToWorldSpaceRay.origin, mouseToWorldSpaceRay.direction * 100, Color.yellow);
		if (Physics.Raycast (mouseToWorldSpaceRay, out hit)) {
			cueBallDirection = (gameObject.transform.position - new Vector3 (hit.point.x, this.gameObject.transform.position.y, hit.point.z)).normalized;
			cueBallDirection.y = 0.0f;
		}
		Physics.SphereCast (this.gameObject.transform.position, 0.25f, cueBallDirection, out sphereHit);
		//Ray bounceRay = 

		Physics.Raycast (sphereHit.point,sphereHit.normal, out bounceHit);
			
		line.SetPosition (0, this.gameObject.transform.position);
		line.SetPosition (1, new Vector3 (sphereHit.point.x, this.gameObject.transform.position.y, sphereHit.point.z));
		line.SetPosition (2, bounceHit.point);
		if (Input.GetMouseButtonDown (0)) {
			this.gameObject.GetComponent<Rigidbody> ().AddForce (cueBallDirection * 5000.0f);
			Debug.Log (cueBallDirection.y);
		}

	}	
}
