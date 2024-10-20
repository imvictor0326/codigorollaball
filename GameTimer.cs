using UnityEngine;
using UnityEngine.UI; // Necesario para usar UI en Unity
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class GameTimer : MonoBehaviour
{
	public float timeRemaining = 60f; // Tiempo de 60 segundos
	public Text timerText; // Referencia al texto en la UI que mostrará el temporizador
	private bool gameEnded = false; // Controla si el juego ha terminado

	void Update()
	{
		if (!gameEnded)
		{
			// Restar el tiempo y actualizar el texto en pantalla
			timeRemaining -= Time.deltaTime;
			timerText.text = "Tiempo restante: " + Mathf.Floor(timeRemaining).ToString() + " s";

			// Verificar si el tiempo ha llegado a cero
			if (timeRemaining <= 0)
			{
				timeRemaining = 0; // Asegurarse de que no sea negativo
				EndGame(); // Llamar a la función que termina el juego
			}
		}
	}

	void EndGame()
	{
		gameEnded = true;
		timerText.text = "¡Perdiste!"; // Cambia el texto para indicar la derrota

		// Esperar unos segundos antes de cambiar de escena (opcional)
		Invoke("LoadGameOverScene", 2f); // Cambia a la escena de "GameOver" después de 2 segundos
	}

	void LoadGameOverScene()
	{
		// Carga la escena de derrota
		SceneManager.LoadScene("GameOverScene"); // Asegúrate de tener una escena llamada GameOverScene
	}
}