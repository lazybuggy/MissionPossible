using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

    private Vector2 velocity;
    public float smoothTimeX;
    public float smoothTimeY;

    public GameObject player;

    public bool bounds;
    public Vector3 minCamPos;
    public Vector3 maxCamPos;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
	}
	

	void FixedUpdate () {

        //move from A to B smooth
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        //if we do have boundries, make boundries for camera
        if (bounds) {

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x),
                    Mathf.Clamp(transform.position.y, minCamPos.y, maxCamPos.y),
                    Mathf.Clamp(transform.position.z, minCamPos.z, maxCamPos.z));

        }
    }

    public void SetMinCamPos(){
        //sets min camera position to the current camera position
        minCamPos = gameObject.transform.position;
    }

    public void SetMaxCamPos()
    {
        //sets max camera position to the current camera position
        maxCamPos = gameObject.transform.position;
    }
}
