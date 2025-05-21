using UnityEngine;
using Oculus.Interaction.Input; // Meta SDK Hand Reference

public class HandWaterController : MonoBehaviour
{
    [Header("Hand Tracking")]
    public Hand hand; // Assign LeftHand or RightHand (from OVR prefab)

    [Header("Water Particle Effect")]
    public ParticleSystem waterEffect; // Assign the prefab or in-hand particle

    [Header("Palm Open Detection Settings")]
    [Tooltip("Threshold below which the fingers are considered open (0 = fully pinched, 1 = open)")]
    [Range(0f, 1f)]
    public float openThreshold = 0.2f;

    void Update()
    {
        // Safety check
        if (hand == null || waterEffect == null) return;

        // Get how much fingers are pinching — 0 (pinched) to 1 (not pinching)
        float middlePinch = hand.GetFingerPinchStrength(HandFinger.Middle);
        float ringPinch   = hand.GetFingerPinchStrength(HandFinger.Ring);
        float pinkyPinch  = hand.GetFingerPinchStrength(HandFinger.Pinky);

        // Consider palm open if all three fingers are "not pinching"
        bool isPalmOpen = middlePinch < openThreshold && ringPinch < openThreshold && pinkyPinch < openThreshold;

        // Play or stop the water effect accordingly
        if (isPalmOpen)
        {
            if (!waterEffect.isPlaying)
                waterEffect.Play();
        }
        else
        {
            if (waterEffect.isPlaying)
                waterEffect.Stop();
        }
    }
}
