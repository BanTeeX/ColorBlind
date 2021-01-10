using UnityEngine;

public class BlockCheck : MonoBehaviour
{
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<ThemeChange>().Blocked = true;
		}
	}
}
