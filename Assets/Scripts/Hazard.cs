using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Той самий принцип: реагуємо на компонент, а не на тег
        if (other.TryGetComponent<PlayerRespawn>(out var respawn))
            respawn.Respawn();
    }
}
