using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    //public instance variable
    public GameController gameController;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Collision");
            //this._enemySound.Play();
            this.gameController.LivesValue -= 1;

        }
    }

}
