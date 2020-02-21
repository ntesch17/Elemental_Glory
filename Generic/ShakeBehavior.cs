using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehavior : MonoBehaviour
{

    // Transform of the GameObject you want to shake
    private Transform transform;

    // Desired duration of the shake effect
    public float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.7f;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;

    public float actualShakeDuration;

    // Start is called before the first frame update
    void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent<Transform>();
        }
    }

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    void FixedUpdate()
    {
        if (shakeDuration > 0)
        {
            //transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            var shakeVector = Random.insideUnitSphere;
            this.GetComponent<FollowPlayer>().shakeX = shakeVector.x * shakeMagnitude;
            this.GetComponent<FollowPlayer>().shakeY = shakeVector.y * shakeMagnitude;
            shakeDuration -= Time.fixedDeltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            this.GetComponent<FollowPlayer>().shakeX = 0f;
            this.GetComponent<FollowPlayer>().shakeY = 0f;
            //transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake()
    {
        shakeDuration = actualShakeDuration;
    }
}
