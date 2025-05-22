using UnityEngine;

public class LookAtPlayerOnce : MonoBehaviour
{
    [Header("Optional target (leave empty to auto-find player)")]
    [SerializeField] private Transform targetToLookAt;

    [Header("Offset visual  -Z (e.g. 180°)")]
    [SerializeField] private float yRotationOffset = 180f;

    void Start()
    {
        
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


        Vector3 lookPos = targetToLookAt.position;
        lookPos.y = transform.position.y; 

        transform.LookAt(lookPos); 
        transform.Rotate(0f, yRotationOffset, 0f); 
    }
}
