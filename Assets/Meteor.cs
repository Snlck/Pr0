using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public Transform meteorPos;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;
    public GameObject meteorPrefab;
    
    // Update is called once per frame
    void Update()
    {
        SpawnMeteor();
        meteorPos.position = new Vector3(Random.Range(-9F,9F),7F,0F);
    }

    void SpawnMeteor()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            MeteorErzeugen().GetComponent<Rigidbody2D>().AddForce(Vector2.up);
        }
    }
    public GameObject MeteorErzeugen()
    {
        GameObject schuss = (GameObject)Instantiate(meteorPrefab, meteorPos.position, Quaternion.identity);
        return schuss;
    }
}
