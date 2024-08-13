using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPlayerScript : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;
    public int _health = 3;
    public TextMeshProUGUI _healthText;
    private Vector3 _startPosition; // Store the starting position

    public PlayerData playerData; // Reference to your PlayerData Scriptable Object

    private Collider2D platformCollider;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        // Ensure the health text is updated at the start of the game
    UpdateHealthText();

        // Load player position if available
        if (playerData != null && playerData.playerPosition != Vector3.zero)
        {
            transform.position = playerData.playerPosition;
        }
        else
        {
            _startPosition = new Vector3(-10.47f, -3.16f, transform.position.z);
            transform.position = _startPosition; // Ensure the player starts at this position
        }
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        // Save the player's position when 'S' key is pressed
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavePlayerPosition();
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void UpdateHealthText()
    {
        _healthText.text = "Health: " + _health.ToString();
    }

    public void ResetPosition()
    {
        transform.position = _startPosition; // Reset the player to the starting position
    }

    // Method to save the player's current position
    public void SavePlayerPosition()
    {
        if (playerData != null)
        {
            playerData.SavePosition(transform);
            Debug.Log("Player position saved: " + playerData.playerPosition);
        }
    }
}
