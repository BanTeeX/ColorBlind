using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
	private SpriteRenderer SpriteRenderer { get; set; }

	private void Awake()
	{
		SpriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void ChangeActive(bool activated)
	{
		GetComponent<Collider2D>().isTrigger = !activated;
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
