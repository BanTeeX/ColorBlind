using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float maxSpeed;
	[SerializeField] private float speed;

	private Rigidbody2D Rb { get; set; }
	private float Direction { get; set; }

	private void Start()
	{
		Rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
    {
        Direction = Input.GetAxis("Horizontal");
    }

	private void FixedUpdate()
	{
		Rb.velocity = new Vector2(Direction * speed, 0);
		Rb.velocity = Vector2.ClampMagnitude(Rb.velocity, maxSpeed);
	}
}
