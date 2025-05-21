using UnityEngine;

public class LookAtPlayerOnce : MonoBehaviour
{
    [Header("Optional target (leave empty to auto-find player)")]
    [SerializeField] private Transform targetToLookAt;

    [Header("Offset visual si tu modelo mira hacia -Z (e.g. 180°)")]
    [SerializeField] private float yRotationOffset = 180f;

    void Start()
    {
        // Buscar al jugador si no está asignado
        if (targetToLookAt == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
                targetToLookAt = player.transform;
        }

        if (targetToLookAt == null)
        {
            Debug.LogWarning($"{gameObject.name} no tiene targetToLookAt.");
            return;
        }

        // Rotar solo este objeto (el padre)
        Vector3 lookPos = targetToLookAt.position;
        lookPos.y = transform.position.y; // solo rotación en Y

        transform.LookAt(lookPos); // gira hacia el jugador
        transform.Rotate(0f, yRotationOffset, 0f); // corrige visual si mira a -Z
    }
}
