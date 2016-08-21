using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    //array for heart sprites
    public Sprite[] Hearts;

    public Image heartUI;
    private player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
	}
	
	// Update is called once per frame
	void Update () {

        heartUI.sprite = Hearts[player.currHealth];
	}
}
