using UnityEngine;
using System.Collections;

public class Donuts : MonoBehaviour {
    [SerializeField]
    int test;

    [SerializeField]
    GameObject explosionPrefab;

    bool clicked;
	void Start () {

	}

	// Update is called once per frame
	void Update ()
    {
        clicked = Input.GetMouseButtonDown(0);
        if (Mathf.Abs(transform.position.y) > 4f)
        {
            GameOver();
        }
    }

    void FixedUpdate()
    {
        if (clicked)
        {
            rigidbody.velocity = Vector3.up * 5f;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        GameOver();
    }

    void GameOver()
    {
        var pos = transform.position;
        Instantiate(explosionPrefab, pos, Quaternion.identity);
        var manager = FindObjectOfType<GameManager>();
        manager.GameOver();
        Destroy(gameObject);
    }
}
