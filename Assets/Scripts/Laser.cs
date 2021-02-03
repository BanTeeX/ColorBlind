using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Block))]
public class Laser : MonoBehaviour
{
	[SerializeField] private float distance = 100f;

	private LineRenderer LineRenderer { get; set; }
	private RaycastHit2D Hit { get; set; }
	private Block Block { get; set; }

	private void Awake()
	{
		LineRenderer = GetComponent<LineRenderer>();
		Block = GetComponent<Block>();
	}

	private void FixedUpdate()
	{
		LineRenderer.enabled = Block.IsActivated;
		if (Block.IsActivated)
		{
			Hit = Physics2D.Raycast(transform.position, -transform.right);
			if (Hit.collider == null)
			{
				LineRenderer.SetPosition(0, transform.position);
				LineRenderer.SetPosition(1, transform.position - transform.right * distance);
			}
			else if (Hit.collider.CompareTag("Player"))
			{
				Hit.collider.GetComponent<PlayerController>().Die();
			}
			else
			{
				LineRenderer.SetPosition(0, transform.position);
				LineRenderer.SetPosition(1, Hit.point);
			}
		}
	}
}
