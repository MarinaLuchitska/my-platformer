using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField, Range(1f, 20f)] private float speed = 7f;
    [SerializeField, Range(0.5f, 10f)] private float lifetime = 3f;
    [SerializeField] private LayerMask targetLayers;

    public Action<Projectile> OnFinished; // повернення в пул

    private int damage;
    private float dieAt;

    public void Launch(Vector2 direction, int dmg)
    {
        damage = dmg;
        dieAt = Time.time + lifetime;
        transform.right = direction;
        GetComponent<Rigidbody2D>().linearVelocity = direction.normalized * speed;
    }

    private void Update()
    {
        if (Time.time >= dieAt) OnFinished?.Invoke(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Реагуємо ТІЛЬКИ на шари з маски: снаряд народжується поряд зі стрільцем
        // і всередині тригера меж рівня LevelBounds
        if ((targetLayers.value & (1 << other.gameObject.layer)) == 0) return;

        if (other.TryGetComponent(out IDamageable target))
            target.TakeDamage(damage, transform.position);

        OnFinished?.Invoke(this);
    }
}
