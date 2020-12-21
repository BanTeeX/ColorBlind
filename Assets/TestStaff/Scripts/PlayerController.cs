using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float maxSpeed;
	[SerializeField] private float speedToleration;
	[SerializeField] private float accelerationTime;
	[SerializeField] private float slowingTime;
	[SerializeField] private float maxJumpTime;
	[SerializeField] private float groundCheckRadius;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private Rigidbody2D rb;

	private float Direction { get; set; }
	private bool Jump { get; set; }
	private bool JumpFirstFrame { get; set; } = true;
	private bool IsGrounded { get; set; }

	private void Update()
    {
        Direction = Input.GetAxisRaw("Horizontal");
		if (IsGrounded || Jump)
		{
			Jump = Input.GetButton("Jump");
		}
    }

	private void FixedUpdate()
	{
		IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, LayerMask.GetMask("Black", "White"));

		if (IsGrounded)
		{
			JumpFirstFrame = true;
		}

		rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y);
		if (Mathf.Abs(rb.velocity.x) < speedToleration)
		{
			rb.velocity = new Vector2(0, rb.velocity.y);
		}
		if (Direction != 0)
		{
			rb.AddForce(new Vector2(rb.mass * (maxSpeed / accelerationTime), 0) * Direction);
		}
		else
		{
			rb.AddForce(new Vector2(-rb.mass * (rb.velocity.x / slowingTime), 0));
		}

		if (Jump)
		{
			if (JumpFirstFrame)
			{
				rb.AddForce(new Vector2(0, 500));
				JumpFirstFrame = false;
			}
			else
			{
				rb.AddForce(new Vector2(0, -Physics2D.gravity.y * rb.mass * rb.gravityScale));
			}
		}
	}
}
