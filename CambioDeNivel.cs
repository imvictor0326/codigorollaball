using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeNivel : MonoBehaviour
{
	public float tiempoParaCambiarNivel = 2f; // Tiempo en segundos para cambiar al siguiente nivel
	private bool nivelGanado = false;

	// Método que se llamará cuando el jugador gane el nivel
	public void NivelGanado()
	{
		if (!nivelGanado)
		{
			nivelGanado = true; // Aseguramos que se ejecute solo una vez
			Invoke("CambiarNivel", tiempoParaCambiarNivel); // Invocar cambio de nivel después de X segundos
		}
	}

	// Cambiar al siguiente nivel o regresar al menú principal
	void CambiarNivel()
	{
		int escenaActual = SceneManager.GetActiveScene().buildIndex; // Obtener el índice de la escena actual
		int totalEscenas = SceneManager.sceneCountInBuildSettings; // Total de escenas en el build

		// Si estamos en la última escena (último nivel), ir al menú principal
		if (escenaActual == totalEscenas - 1)
		{
			SceneManager.LoadScene("MainMenu"); // Cambia "MenuPrincipal" por el nombre de tu escena de menú
		}
		else
		{
			// Avanzar al siguiente nivel
			SceneManager.LoadScene(escenaActual + 1);
		}
	}
}