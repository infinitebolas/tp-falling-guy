using UnityEngine;

public class Ejection : MonoBehaviour
{
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boule"))
        {
            Vector3 forceDirection = collision.contacts[0].point - transform.position;
            forceDirection.y = 0; 
            forceDirection.z = 0;
            characterController.Move(forceDirection.normalized * 10f); 
        }
    }
}
