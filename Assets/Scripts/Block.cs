using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
	public bool IsActivated { get; private set; } = true;

	private SpriteRenderer SpriteRenderer { get; set; }
	private Collider2D Collider2D { get; set; }

	private void Awake()
	{
		SpriteRenderer = GetComponent<SpriteRenderer>();
		Collider2D = GetComponent<Collider2D>();
	}

	public void ChangeActive(bool activated)
	{
		IsActivated = activated;
		if (Collider2D != null)
		{
			Collider2D.isTrigger = !activated;
		}
		SpriteRenderer.enabled = activated;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<ThemeChange>().Blocked = true;
		}
	}
}
