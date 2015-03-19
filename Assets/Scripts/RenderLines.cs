using UnityEngine;
using System.Collections;

public class RenderLines : MonoBehaviour {
	private LineRenderer line;
	private Vector3 mousePosition;
	private Vector3 mouseWorld;
	public Camera gameCamera;
	public GameObject sphereCastTestObject;
	private Vector3 cueBallDirection;
	private bool allAsleep;
	private float now;
	private float lastHit;
	// Use this for initialization
	void Start () {
		line = gameObject.GetComponent<LineRenderer> ();
		line.SetWidth(0.1f, 0.1f);
		line.SetVertexCount(3);
		//gameCamera = GameObject.FindObjectOfType<Camera> ();
		//Physics.sleepThreshold = 1000.0f;
		allAsleep = true;

	}
	
	// Update is called once per frame
	void Update () {
		//mousePosition = Input.mousePosition;
		//mousePosition.z = gameObject.transform.position.z;
		//mouseWorld = gameCamera.ScreenToWorldPoint(mousePosition);
		//mouseWorld.y = gameObject.transform.position.y;
		if (allAsleep) {
			UpdateLine ();
		} else {
			CheckObjectsHaveStopped ();
		} 
		now = Time.realtimeSinceStartup;
		if (now - lastHit >= 5.0f)
		{
			StopAllObjects();
			//allAsleep = true;
		}

	}

	
	void UpdateLine()
	{


			line.SetVertexCount(3);
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
			Vector3 newDirection = new Vector3 (sphereHit.normal.x, 0.0f, sphereHit.normal.z);
			Physics.Raycast (sphereHit.point, newDirection, out bounceHit);
			
			line.SetPosition (0, this.gameObject.transform.position);
			line.SetPosition (1, new Vector3 (sphereHit.point.x, this.gameObject.transform.position.y, sphereHit.point.z));
			line.SetPosition (2, bounceHit.point);
			if (Input.GetMouseButtonDown (0)) {
				this.gameObject.GetComponent<Rigidbody> ().AddForce (cueBallDirection * 30000.0f);
				allAsleep = false;
				line.SetVertexCount(0);
				lastHit = Time.realtimeSinceStartup;
			}
	} 


	void CheckObjectsHaveStopped()
	{

		Rigidbody[] GOS = FindObjectsOfType(typeof(Rigidbody)) as Rigidbody[];
		bool allObjectsAsleep = true;
			foreach (Rigidbody GO in GOS) 
			{
				if(!GO.IsSleeping())
				{
					print ("asleep");
					allObjectsAsleep = false;
				}
			}
		print ("assigning");
		allAsleep = allObjectsAsleep;
			
	}

	void StopAllObjects()
	{
		Rigidbody[] GOS = FindObjectsOfType (typeof(Rigidbody)) as Rigidbody[];
		foreach (Rigidbody GO in GOS) {
			GO.Sleep ();

		}
	}

		
}