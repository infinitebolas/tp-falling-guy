using UnityEngine;

public class wallbutton : MonoBehaviour
{
    public Animator anim; // Animation de la porte ou de l’action

    void OnMouseDown()
    { // Quand le bouton est cliqué
        anim.SetTrigger("openDoor"); // Déclenche une animation
    }
}
