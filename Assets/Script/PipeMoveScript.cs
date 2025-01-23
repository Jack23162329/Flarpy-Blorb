using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour {
    // Start is called before the first frame update
    public float MoveSpeed = 5;
    public float deadZone = -60;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.position = transform.position + (Vector3.left * MoveSpeed) * Time.deltaTime;

        if (transform.position.x <= deadZone) {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }
}
