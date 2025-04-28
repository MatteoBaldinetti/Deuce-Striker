using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Important pour utiliser le nouveau système d'input XR

public class Pause : MonoBehaviour
{
    public string sceneName = "NomDeTaScene"; // Mets ici ta scène
    public InputActionReference menuButton; // Référence vers ton action "Menu"

    private void OnEnable()
    {
        if (menuButton != null)
            menuButton.action.performed += OnMenuPressed;
    }

    private void OnDisable()
    {
        if (menuButton != null)
            menuButton.action.performed -= OnMenuPressed;
    }

    private void OnMenuPressed(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(sceneName);
    }
}
