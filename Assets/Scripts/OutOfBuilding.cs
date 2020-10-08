using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBuilding : MonoBehaviour
{
    [SerializeField] private Transform Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("YOU WIN!!!");
            SceneManager.LoadScene("Menu");
        }
    }
}
