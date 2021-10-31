using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* NPC_Object is the base class inherited by all the NPC Objects that pertain in the world such as enemies or obstacles.
 * 
 */
public abstract class NPC_Object : MonoBehaviour
{
    // Class variables
    protected GameManager gameManager;
    [SerializeField] protected float speed;
    [SerializeField] protected int damageAmount = -1;

    // On awake find gameManager
    protected virtual void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Every frame check if out of bounds
    protected virtual void Update()
    {
        Move();
        DestroyObjectWhenOutbounds();
    }

    protected virtual void Move()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    protected virtual void DestroyObject()
    {
        Destroy(gameObject);
    }

    // Method to check if out of bounds. Game Boundary set by the GameManager. If out of bounds, object is destroyed.
    protected virtual void DestroyObjectWhenOutbounds()
    {
        // If an object goes past the game boundaries, remove that object
        if (transform.position.y > gameManager.BoundaryYUpper || transform.position.y < gameManager.BoundaryYLower || 
            transform.position.x > gameManager.BoundaryX || transform.position.x < -gameManager.BoundaryX)
        {
            DestroyObject();
        }
    }

    protected abstract void OnTriggerEnter(Collider other);
}
