using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Das Skript dient dazu die Bewegung des Avatars anzupassen abhängig zur Bewegungsrichtung der MainCamera.
/// </summary>
namespace Microsoft.MixedReality.Toolkit.Utilities
{
    public class MovementPositionScript : MonoBehaviour
    {

        private GameObject camPos;
        [SerializeField]private float max = 2f;  // maximaler Abstand nach vorne
        [SerializeField]private float min = -2f; // maximaler Abstand nach hinten
        [SerializeField]private float steps = 0.2f; // Verschiebung per Button Druck
        private float current = 0f; // Start Verschiebung (direkt neben der Person)
        private Vector3 startOffset; // Relative Positionierung zur MainCamera
        private Vector3 updatedOffset;// Hilfsvariabel für Positionierung
        void Start()
        {
            camPos = GameObject.Find("MoveDirection");
            startOffset = transform.position;

        }
        /// <summary>
        /// Position des Avatars wird an die Bewegungsrichtung der MainCamera angepasst
        /// </summary>
        void Update()
        {
            transform.position = camPos.transform.TransformPoint(startOffset);
            transform.rotation = camPos.transform.rotation;
        }
        /// <summary>
        ///  Bei Buttondruck erhöht sich der Abstand des Avatars nach vorne bis zu dem festgelegten maximalen Abstand.
        ///  Diese Methode sollte jedoch in der fertigen Version nicht per Buttondruck sondern durch einen Geschwindigkeitsvergleich
        ///  aufgerufen werden.
        /// </summary>
        public void Faster()
        {
            current = current + steps;
            if (current > max)
            {
                current = max;
            }
            updatedOffset = new Vector3(startOffset.x, startOffset.y, current);
            startOffset = updatedOffset;

        }
        /// <summary>
        /// Bei Buttondruck erhöht sich der Abstand des Avatars nach hinten bis zu dem festgelegten maximalen Abstand.
        /// Diese Methode sollte jedoch in der fertigen Version nicht per Buttondruck sondern durch einen Geschwindigkeitsvergleich
        /// aufgerufen werden.
        /// </summary>
        public void Slower()
        {
            current = current - steps;
            if (current < min)
            {
                current = min;
            }
            updatedOffset = new Vector3(startOffset.x, startOffset.y, current);

            startOffset = updatedOffset;
        }
    }
}
