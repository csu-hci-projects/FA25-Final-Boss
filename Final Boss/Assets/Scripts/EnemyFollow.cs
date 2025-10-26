using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
public class EnemyFollow : MonoBehaviour {

    private Transform player;
    public float speed;
    GameEnding gameEnding;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            gameEnding.CaughtPlayer();
        }
    }

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        transform.LookAt(2 * transform.position - player.position);
    }
}
