using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject target;          // платформа, двері, міст
    [SerializeField] private SpriteRenderer handle;       // необов'язково: розворот ручки

    private bool isOn;

    public void Interact()
    {
        isOn = !isOn;
        target.SetActive(isOn);

        // Візуальний відгук самого важеля — гравця це не стосується
        if (handle != null) handle.flipX = isOn;
    }
}
