using UnityEngine;
using System.Collections;

public class Thorn : MonoBehaviour {

    //variables
    private player player;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
	}

    void OnTriggerEnter2D(Collider2D coll) {

        if (coll.CompareTag("Player")) { 
            player.Damage(1);

            StartCoroutine(player.KnockBack(0.02f, 100, player.transform.position));
        }

	}
}
