using UnityEngine;

public class GamePlayState : MonoBehaviour
{
	public static Inventory inventory;
	
	private void Awake()
	{
		inventory = new Inventory(16);
	}
	private void Start()
	{
		
	}
}
