using UnityEngine;

public class wallbutton : MonoBehaviour
{
    public Animator anim; // Animation de la porte ou de l�action

    void OnMouseDown()
    { // Quand le bouton est cliqu�
        anim.SetTrigger("openDoor"); // D�clenche une animation
    }
}
