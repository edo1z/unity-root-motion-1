using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 0.5f;
    private Animator anim;

    private void Awake()
    {
        anim = transform.GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        anim.SetFloat("Speed", Speed);
    }
}
