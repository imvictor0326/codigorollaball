using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTimer : MonoBehaviour
{
	public float timeToWait = 5f; // Tiempo en segundos para esperar antes de volver al menú

	void Start()
	{
		// Iniciar el temporizador para cambiar a la escena del menú después de 5 segundos
		Invoke("ReturnToMainMenu", timeToWait);
	}

	void ReturnToMainMenu()
	{
		// Cambiar a la escena del menú principal
		SceneManager.LoadScene("MainMenu"); // Asegúrate de que "MainMenu" es el nombre exacto de tu escena
	}
}