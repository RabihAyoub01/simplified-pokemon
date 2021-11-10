using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using SQLHelper;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed;
    public LayerMask solidObjectsLayer;

    private bool isMoving;

    private Vector2 input;

    private Animator animator;

    private static SQLConnector db;

    private static Keyboard kb;


    private void Awake()
    {
        animator = GetComponent<Animator>();  // animation stuff
        db = new SQLConnector();
    }

    private void Start()
    {
        Debug.Log("Started Game.");
    }

    private void Update()
    {
        kb = InputSystem.GetDevice<Keyboard>();  // initialization of Keyboard input
        System.Random r = new System.Random();

        if (kb.spaceKey.wasPressedThisFrame)
        {
            SQLConnector.onPokemonCaught("Rabou3i", r.Next(50), 121, "ghassy");
            Debug.Log("Wrote to DB.");
        }

        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }
        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
             transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
             yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)  // whether or not the future position would be
        // in a collidable object.
    {
        return Physics2D.OverlapCircle(targetPos, 0.15f, solidObjectsLayer) == null;
    }
}
