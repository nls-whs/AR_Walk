using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Dient dazu periodisch die Position des Aatares zu überprüfen und je nach Unteschied die Animationsgeschwindigkeit anpasst.
/// </summary>
public class WalkingSpeed : MonoBehaviour
{
    Animator anim;
    float animSpeedControl = 1f;
    private Vector3 oldPosition;
    private float speed;
    private float timer = 1f;
    // Start is called before the first frame update
    void Start()
    {
        oldPosition = transform.position;
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


        if (timer >= 1f)
        {
            animSpeedControl = (transform.position - oldPosition).magnitude;
            anim.SetFloat("animSpeed", animSpeedControl * 1.5f);
            oldPosition = transform.position;

        }
        timer = timer - Time.deltaTime;
        if (timer <= 0f)
        {
            timer = 1f;
        }
    }

}
