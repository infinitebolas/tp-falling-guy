using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class CharacterControllerCollision : MonoBehaviour
{
    public Animator bouleAnimator;
    public Animator porteAnimator;
    public Animator piegesAnimator;
    public int compteur = 0;
    public KeyCode keyToDetect = KeyCode.E;
    public bool isNearButton;
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI textFin;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (hit.gameObject.name == "zone" && compteur == 0)
        {
            bouleAnimator.SetTrigger("chute");
            compteur += 1;
        }

        if (hit.gameObject.name == "Terrain" || hit.gameObject.name == "pique")
        {
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }


        if (hit.gameObject.name == "trappe")
        {
            piegesAnimator.SetTrigger("sol");
        }

        if (hit.gameObject.name == "plateforme_fin")
        {
            textFin.text = "Partie terminée ! Ou pas...";
            textFin.gameObject.SetActive(true);
            StartCoroutine(Attendre());

        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "bouton")
        {
            messageText.text = "Appuyez sur E pour ouvrir la porte !";
            messageText.gameObject.SetActive(true);
            isNearButton = true;
            Debug.Log("Le joueur est près du bouton");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "bouton")
        {
            messageText.gameObject.SetActive(false); 
            isNearButton = false;
        }
    }

    private IEnumerator Attendre()
    {
        yield return new WaitForSeconds(3f);
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
    private void Update()
    {
        if (isNearButton && Input.GetKeyDown(keyToDetect))
        {
            porteAnimator.SetTrigger("ouverture");
            messageText.gameObject.SetActive(false); 
        }
    }
}