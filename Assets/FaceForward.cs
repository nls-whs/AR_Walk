using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Dient dazu die Bewegungsrichtung der MainCamera zu definieren und zu vermeiden das bei kleineren Kopfdrehung
/// diese als neue Bewegungsrichtung anerkannt werden.
/// </summary>
public class FaceForward : MonoBehaviour
{
    private Vector3 curPos; // Position vor dem Zeitabstand
    private float timer = 0.3f; // Zeitabstand an dem Bewegungsunterschied berechnet wird
    private float startXPosition; // Hilfsvariabel um Anpassung der Position von x zu berechnen
    private float startZPosition; // Hilfsvariabel um Anpassung der Position von z zu berechnen
    private float xDistance; // Distanz zwischen alter und neuer x Position
    private float zDistance; // Distanz zwischen alter und neuer x Position
    void Awake()
    {
        curPos = transform.position;
    }

    /// <summary>
    /// Passt die Rotation an, wenn eine bestimmte Bewegungdistanz überschritten wurde. Sonst bleibt die alte Rotation erhalt.
    /// Postion wird der MainCamera gleichgesetzt.
    /// </summary>
    void Update()
    {
        if (timer >= 0.3f)
        {
            startXPosition = transform.position.x;
            startZPosition = transform.position.z;
        }
        timer = timer - Time.deltaTime;
        if (timer <= 0f)
        {
            calculateDistance();
            if (xDistance > 0.1f || zDistance > 0.1f)
            {
                transform.rotation = Quaternion.LookRotation(transform.position - curPos);
                curPos = transform.position;
            }
            timer = 0.3f;
        }
        transform.position = Camera.main.transform.position;
        
    }
    void calculateDistance()
    {
        xDistance = Mathf.Abs(Mathf.Abs(startXPosition) - Mathf.Abs(transform.position.x));
        zDistance = Mathf.Abs(Mathf.Abs(startZPosition) - Mathf.Abs(transform.position.z));
    }
}