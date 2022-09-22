using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
  [SerializeField] private LayerMask groundLayer;
  [SerializeField] private Rigidbody2D rgb2D;
  [SerializeField] private Collider2D mainCollider;
  [SerializeField] private TextMeshPro text;

  private bool inJump;
  private ContactFilter2D contactFilter2D;

  void Update() {
    ProcessJumpInput();
  }

  private void ProcessJumpInput() {
    if (inJump)
    {
      if (Keyboard.current.spaceKey.wasReleasedThisFrame)
      {
        jumpStepsRemaining = 0;
      }

      return;
    }

    if (!mainCollider.IsTouching(contactFilter2D))
    {
      return;
    }

    if (Keyboard.current.spaceKey.wasPressedThisFrame)
    {
      jumpStepsRemaining = TotalJumpSteps;
      inJump = true;
    }
  }

  private const int TotalJumpSteps = 10;
  private const float JumpSpeed = 36;
  private const float MoveSpeed = 20;

  private int jumpStepsRemaining;

  void FixedUpdate() {
    Vector2 currVelocity = rgb2D.velocity;
    currVelocity.x = GetDirection() * MoveSpeed;
    if (inJump)
    {
      currVelocity.y = JumpSpeed;
      jumpStepsRemaining--;
      if (jumpStepsRemaining <= 0)
      {
        inJump = false;
      }
    }

    rgb2D.velocity = currVelocity;
    text.text = mainCollider.IsTouching(contactFilter2D) ? "Ground" : "Air";
  }



  private int GetDirection() {
    if (Keyboard.current.aKey.isPressed)
    {
      return -1;
    }

    if (Keyboard.current.dKey.isPressed)
    {
      return 1;
    }

    return 0;
  }
  
  public void Awake() {
    contactFilter2D = new ContactFilter2D
      { layerMask = groundLayer, useLayerMask = true, minNormalAngle = 89, maxNormalAngle = 91, useNormalAngle = true};
  }

  public void ChangePosition(Vector2 destination) {
    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, int.MaxValue, groundLayer);
    rgb2D.position = new Vector2(destination.x, destination.y + hit.distance);
  }
}
