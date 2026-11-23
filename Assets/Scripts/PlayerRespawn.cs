using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRespawn : MonoBehaviour
{
    private Vector3 checkpoint;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        checkpoint = transform.position;   // перша «контрольна точка» — старт рівня
    }

    public void SetCheckpoint(Vector3 position) => checkpoint = position;

    public void Respawn()
    {
        // Ставимо і тіло, і трансформ: з Interpolate тіло інакше «повернуло» б
        // персонажа на місце смерті в наступному фізичному кроці
        body.position = checkpoint;
        transform.position = checkpoint;

        // Обов'язково: інакше персонаж з'явиться на точці з накопиченою
        // швидкістю падіння й одразу полетить униз
        body.linearVelocity = Vector2.zero;
    }
}
