using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public const int maxHealth = 100;
    public bool destroyOnDeath;
    public int currentHealth = maxHealth;
    public bool isEnemy=false;

    public RectTransform healthbar;

    private bool isLocalPlayer;

	// Use this for initialization
	void Start () {
        PlayerController pc = GetComponent<PlayerController>();
        isLocalPlayer = pc.isLocalPlayer;


    }
    public void TakeDamage( GameObject playerFrom, int amount )
    {
        currentHealth -= amount;
        //TODO networking stuff
    }

    public void OnChangeHealth()
    {                                     //x value      //y vlaue
        healthbar.sizeDelta = new Vector2(currentHealth, healthbar.sizeDelta.y);  //sizeDelta.y gets the value of the y position specified in the editor
                                                                                  //used as this value is not being change but only needs to be accessed

        if(currentHealth <= 0)
        {
            if(destroyOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                currentHealth = maxHealth;
                healthbar.sizeDelta = new Vector2(currentHealth,healthbar.sizeDelta.y);
                Respawn();
            }
        }
    }
    // Update is called once per frame
    void Respawn ()
    {
	    if(isLocalPlayer)
        {
            Vector3 spawnPoint = Vector3.zero;
            Quaternion spawnRotation = Quaternion.Euler(0, 180, 0);
            transform.position = spawnPoint;
            transform.rotation = spawnRotation;
        }
	}
}
