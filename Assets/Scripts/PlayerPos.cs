using UnityEngine;

public class PlayerPos : MonoBehaviour
{
<<<<<<< HEAD
    
    private GameMaster gm;
    [SerializeField] GameObject player = null;
    [SerializeField] GameObject master = null;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>();
        transform.position = gm.lastCheckPointPos;
    }
=======
	[SerializeField] private GameObject player = null;
	[SerializeField] private GameObject master = null;
	
	private GameMaster gm;
>>>>>>> main

	private void Start()
	{
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		transform.position = gm.lastCheckPointPos;
	}

    // Służy do specjalnego zabijania się, żeby testować/ Można wyjebać
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            Instantiate(player, new Vector2(master.transform.position.x, master.transform.position.y), Quaternion.identity);
            Destroy(gameObject);
        }
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            transform.parent = collision.transform;
            Debug.Log("We are on a moving platform");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            transform.parent = null;
            Debug.Log("We are not on a moving platform");
        }
    }
}
