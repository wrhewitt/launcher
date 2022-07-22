using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCheats : MonoBehaviour
{
    CollisionHandler collisionHandler;
    [SerializeField] GameObject player;

    void Awake() {
        collisionHandler = player.GetComponent<CollisionHandler>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            collisionHandler.LoadNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Changing collision status to : " + collisionHandler.enableCollisions.ToString());
            collisionHandler.enableCollisions = !collisionHandler.enableCollisions;
        }
    }
}
