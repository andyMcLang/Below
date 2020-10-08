using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;
    public DeathMenu deathMenu;

    void OnTriggerEnter(Collider other)
    {
        /*
        Player.transform.position = respawnPoint.transform.position;
        Debug.Log("You die!!"); */

        if (other.gameObject.tag == "Player")
        {
            deathMenu.ToggleEndMenu();
            //Destroy(gameObject);
            Debug.Log("You die! Back to start place!");
            Player.transform.position = respawnPoint.transform.position;
        }
    }
}
