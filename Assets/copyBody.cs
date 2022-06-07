using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Dient dazu den Oberkörper leicht zu drehen abhängig von der Kopfdrehung.
/// </summary>
public class copyBody : MonoBehaviour
{

        [SerializeField] private GameObject body;
        [SerializeField] private GameObject head;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.rotation = head.transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, body.transform.rotation, 0.75f);
        }
    }


