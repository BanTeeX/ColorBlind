using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float maxSpeed;
	[SerializeField] private float speedToleration;
	[SerializeField] private float time;
	[SerializeField] private float slowingTime;

	private Rigidbody2D Rb { get; set; }
	private float Direction { get; set; }

	private void Start()
	{
		Rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
    {
        Direction = Input.GetAxisRaw("Horizontal");
    }

	private void FixedUpdate()
	{
		if (Direction != 0)
		{
			Rb.AddForce(new Vector2(Rb.mass * (maxSpeed / time), 0) * Direction);
		}
		else
		{
			Rb.AddForce(new Vector2(-Rb.mass * (Rb.velocity.x / slowingTime), 0));
		}
		Rb.velocity = new Vector2(Mathf.Clamp(Rb.velocity.x, -maxSpeed, maxSpeed), Rb.velocity.y);
		if (Mathf.Abs(Rb.velocity.x) < speedToleration)
		{
			Rb.velocity = new Vector2(0, Rb.velocity.y);
		}
	}
}
