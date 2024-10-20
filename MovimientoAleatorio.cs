using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAleatorio : MonoBehaviour
{
	public float velocidad = 3.0f; // Velocidad del objeto
	public Vector2 limites;        // Límites en X y Z (tamaño del área de movimiento)
	private Vector3 direccion;     // Dirección hacia la que se moverá

	void Start()
	{
		// Asignar una dirección aleatoria al inicio
		CambiarDireccionAleatoria();
	}

	void Update()
	{
		// Mover el objeto en la dirección actual
		transform.Translate(direccion * velocidad * Time.deltaTime);

		// Verificar si está fuera de los límites y ajustar la dirección
		VerificarLimites();
	}

	// Cambia la dirección aleatoriamente
	void CambiarDireccionAleatoria()
	{
		// Generar un vector aleatorio en 2D (plano XZ)
		float randomX = Random.Range(-1f, 1f);
		float randomZ = Random.Range(-1f, 1f);

		direccion = new Vector3(randomX, 0, randomZ).normalized; // Normalizar para que siempre sea de longitud 1
	}

	// Verificar si el objeto se ha salido de los límites
	void VerificarLimites()
	{
		Vector3 posicion = transform.position;

		// Limitar en el eje X
		if (posicion.x < -limites.x || posicion.x > limites.x)
		{
			direccion.x = -direccion.x; // Cambiar la dirección en el eje X
			posicion.x = Mathf.Clamp(posicion.x, -limites.x, limites.x); // Asegurar que no salga del límite
		}

		// Limitar en el eje Z
		if (posicion.z < -limites.y || posicion.z > limites.y)
		{
			direccion.z = -direccion.z; // Cambiar la dirección en el eje Z
			posicion.z = Mathf.Clamp(posicion.z, -limites.y, limites.y); // Asegurar que no salga del límite
		}

		// Aplicar la nueva posición corregida
		transform.position = posicion;
	}

	// Detectar colisiones y rebotar excepto con el jugador
	private void OnCollisionEnter(Collision collision)
	{
		// Verificar si el objeto con el que chocamos no es el jugador
		if (collision.gameObject.tag != "Jugador")
		{
			// Rebota cambiando la dirección del movimiento
			direccion = Vector3.Reflect(direccion, collision.contacts[0].normal);
		}
	}
}