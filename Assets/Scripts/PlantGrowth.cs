using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    [Header("Growth Settings")]
    public float growDuration = 3f;
    public float maxScale = 4f;

    private bool isGrowing = false;
    private bool hasFullyGrown = false; // ✅ Nuevo: para evitar crecimiento infinito
    private float timer = 0f;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (isGrowing && !hasFullyGrown)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / growDuration);
            float scale = Mathf.Lerp(originalScale.x, maxScale, t);
            transform.localScale = new Vector3(scale, scale, scale);

            // ✅ Marca como completado cuando alcanza el tamaño máximo
            if (Mathf.Approximately(scale, maxScale))
            {
                isGrowing = false;
                hasFullyGrown = true;
            }
        }
    }

    public void StartWatering()
    {
        if (hasFullyGrown) return; // ✅ Evita reiniciar si ya creció
        isGrowing = true;
    }

    public void StopWatering()
    {
        isGrowing = false;
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Water"))
        {
            StartWatering();
        }
    }
}
