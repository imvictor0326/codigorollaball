using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JugadorController : MonoBehaviour {
	public CambioDeNivel cambioDeNivel;

	private Rigidbody rb;

	private int contador;

	public Text textocontador, TextoGanar;

	public float velocidad;

	void Start () {
		
		rb = GetComponent<Rigidbody>();

		contador = 0;

		settextocontador();

		TextoGanar.text = "";
	}

	void FixedUpdate () {
		

		float movimientoH = Input.GetAxis("Horizontal");
		float movimientoV = Input.GetAxis("Vertical");


		Vector3 movimiento = new Vector3(movimientoH, 0.0f,
			movimientoV);
		

		rb.AddForce(movimiento * velocidad);
	}

	void OnTriggerEnter(Collider other)

	{
		if (other.gameObject.CompareTag ("coleccionable"))
		{
			
			other.gameObject.SetActive (false);

			contador = contador + 1;

			settextocontador();
		}
	}


	void settextocontador(){
		textocontador.text = "Contador: " + contador.ToString();
		if (contador >= 12){
			TextoGanar.text = "Ganaste";

			Invoke("GanarNivel", 2f);
		}
	}

	void GanarNivel()
	{
		// Llamar al método del script CambioDeNivel para avanzar de nivel
		cambioDeNivel.NivelGanado();
	}


}