using System.Collections;
using UnityEngine;

namespace Assets.Script.general {
    public class bin: MonoBehaviour {
        inventory hand;

        // Use this for initialization
        void Start() {
            hand = GameObject.FindGameObjectWithTag("Inventory").GetComponent<inventory>();
        }

        void OnMouseDown() {
            hand.clearItem();
        }
    }
}