using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame() {
		SceneManager.LoadScene("scenes"); // Reemplaza "Level1" con el nombre de tu primera escena
	}

	public void OpenOptions() {
		SceneManager.LoadScene("OptionsMenu"); // Carga la escena de opciones
	}

	public void QuitGame() {
		Debug.Log("Quit");
		Application.Quit(); // Esto funciona cuando el juego está construido, no en el editor
	}
}
