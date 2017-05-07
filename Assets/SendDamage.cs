using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDamage : MonoBehaviour {

    public int damage = 1;
    public string tag = "Player";

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag)
        {
            other.gameObject.SendMessage("Schaden", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject, 0);
        }
        
    }
}
