using UnityEngine;

public class GameMaster : MonoBehaviour
{
	public Vector2 lastCheckPointPos;

	private static GameMaster instance;

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(instance);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
