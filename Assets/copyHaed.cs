using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// D�ent dazu die Kopfdrehung anzupassen, damit diese nicht von den Animationen �berschrieben wird.
/// </summary>
public class copyHaed : MonoBehaviour
{
    [SerializeField] private GameObject head;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {       
        transform.rotation = head.transform.rotation;
       
    }

}
