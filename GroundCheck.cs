using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

    private player player;
	
    void Start() {
        player = gameObject.GetComponentInParent<player>();
    }

    void OnTriggerEnter2D(Collider2D coll){

        player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D coll){

        player.grounded = false;


    }

    void OnTriggerStay2D(Collider2D coll)
    {

        player.grounded = true;


    }

}
