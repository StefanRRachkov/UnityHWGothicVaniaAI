using System;
using UnityEngine;
using static UnityEngine.Mathf;
using Random = UnityEngine.Random;

public class Health : MonoBehaviour {

	[SerializeField]
	private int health = 100;

	private Animator animator;
	public GameObject cross;

	void Start() {
		animator = GetComponent<Animator>();
	}

	public void SpawnCross() {
		Vector2 spawnPosition = new Vector2 {
			x = transform.position.x,
			y = -0.1f
		};
		Instantiate(cross, spawnPosition, Quaternion.identity);
	}

	public void Die() {
		Destroy(gameObject);
	}

	public void TakeDamage() {
		if (animator.GetBool("IsCrouching"))
		{
			float rand = Random.value;
			if (rand <= 0.6)
			{
				Debug.Log("Dodged");
				return;
			}
			Debug.Log("Couldn't dodge");
		}
		
		int damage = 10;
		health = Max(health - damage, 0);
		animator.SetInteger("Health", health);
		animator.SetTrigger("TookDamage");
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.transform.parent != transform
			&& collision.gameObject.CompareTag("Hitbox")) {

			TakeDamage();
		}
	}
}
