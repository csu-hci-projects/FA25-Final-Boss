using UnityEngine;

public class EnemyCatch : MonoBehaviour
{
    public GameEnding gameEnding;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameEnding.CaughtPlayer();
        }
    }
}
