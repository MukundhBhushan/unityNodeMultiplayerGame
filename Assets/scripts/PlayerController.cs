using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject BulletPrefab;
    public Transform bulletSpawn;
    public bool isLocalPlayer = true; //TODO: change back to false in actual game

    Vector3 oldPos; 
    Vector3 currentPos;
    Quaternion oldRotation;
    Quaternion currentRotation;

	// Use this for initialization
	void Start () {
        oldPos = transform.position = currentPos;
        oldRotation = transform.rotation = currentRotation;

		
	}




    // Update is called once per frame
    void Update ()
    {

        if (!isLocalPlayer)
        {
            return; //check if the player is client or other player
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime*150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime*3.0f;

        transform.Translate(0,0,z); //actual movement here the gameObj is translated by 'x' amount
        transform.Rotate(0, x, 0); //rotation by x amount here

        currentPos = transform.position;
        currentRotation = transform.rotation;

        

        if(currentPos != oldPos)
        {
            //TODO: network suff

            oldPos = currentPos; 
        }
        
        if(currentRotation != oldRotation)
        {
            //TODO: network stuff
            oldRotation = currentRotation;
        }

        //shooting
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // TODO: networking stuff
            cmdFire();
            
        }

	}

    public void cmdFire()
    {
        var bullet = Instantiate(BulletPrefab,
                            bulletSpawn.position,
                            bulletSpawn.rotation) as GameObject;  //creating a bullet an the position and rotation of the bullet spawner 
                                                                    //casting the bullet as a gameObj as it is part of the game

        //var b = bullet.GetComponent<Bullet>();
        //b.playerFrom = this.gameObject;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.up * 6;
        Destroy(bullet, 2.0f);

    }
}


