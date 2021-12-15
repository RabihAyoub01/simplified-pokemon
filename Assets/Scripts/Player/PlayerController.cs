using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using SQLHelper;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;

    private bool isMoving;

    private Vector2 input;

    private Animator animator;

    private static SQLConnector db;

    public static string username;

    private void Awake()
    {
        animator = GetComponent<Animator>();  // animation stuff
    }

    private void Start()
    {
        Debug.Log("Started Game.");
    }

    private void Update()
    { 
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

        if (Input.GetKeyDown(KeyCode.Z))
            Interact();
    }
    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos=transform.position + facingDir;

        // Debug.DrawLine(transform.position, interactPos, Color.red, 0.5f);
        var collider= Physics2D.OverlapCircle(interactPos, 0.3f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
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

        if (transform.position.x == 9.5f && transform.position.y == 0.8f)
        {
            transform.position = new Vector3(17.5f, 23.8f, 0);
        }

        if (transform.position.x == 18.5f && transform.position.y == 22.8f)
        {
            transform.position = new Vector3(9.5f, 0.8f, 0);
        }
        
        if (transform.position.x > 16.5f && transform.position.x < 19.5f && transform.position.y > 26.8f && transform.position.y < 29.8f)
        {
            ShopWindow gameobject = GetComponent<ShopWindow>();
            gameobject.OnShopWindowPanel();
        }


        isMoving = false;
    }

    private void OnApplicationQuit()
    {
        SQLConnector.CloseConnection();
        Debug.Log("Connection Closed. Called From Player.");
    }

    private bool IsWalkable(Vector3 targetPos)  // whether or not the future position would be
                                                // in a collidable object.
    {
        return Physics2D.OverlapCircle(targetPos, 0.15f, solidObjectsLayer | interactableLayer) == null;
    }

    public static void SetInstanceUsername(string username)
    {
        PlayerController.username = username;
    }

    public static string GetInstanceUsername()
    {
        return PlayerController.username;
    }
}
