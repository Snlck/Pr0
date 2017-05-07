using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //Steuerung
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    public float velocity = 0;
    public float speed = 0;

    //Spieler Leben etc.
    public float health = 3;


    //Waffe
    public AudioClip schussSound;
    public Transform waffePosition;
    public GameObject schussPrefab;
    public float schussSpeed;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        Invoke("Schiessen", 2);

    }
	
	// Update is called once per frame
	void Update () {
        InputCheck();
        Move();
        Schiessen();
	}
    void Schaden(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health == 0)
            {
                RestartScene();
            }
        }
    }

    void RestartScene()
    {
        Application.LoadLevel(Application.loadedLevel); 
    }

    void Schiessen()
    {
        if (Input.GetButton("Fire1")&& Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            SchussErzeugen().GetComponent<Rigidbody2D>().AddForce(Vector2.up * schussSpeed);
            AudioSource.PlayClipAtPoint(schussSound,transform.position,1);
        }
    }
    void InputCheck()
    {
        velocity = Input.GetAxis("Horizontal") * speed;
    }
    void Move()
    {
        if (transform.position.x<9 && transform.position.x>-9)
        {
            moveDirection.x = velocity;
            characterController.Move(moveDirection * Time.deltaTime);
        }
        else
        {
            if (transform.position.x > 9 && velocity<0)
            {
                moveDirection.x = velocity;
                characterController.Move(moveDirection * Time.deltaTime);
            }
            else if (transform.position.x <-9 && velocity > 0)
            {
                moveDirection.x = velocity;
                characterController.Move(moveDirection * Time.deltaTime);
            }

        }

    }
    public GameObject SchussErzeugen()
    {
        GameObject schuss = (GameObject)Instantiate(schussPrefab,waffePosition.position,Quaternion.identity);
        return schuss;
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
    }
}
