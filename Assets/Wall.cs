using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update ()
    {

	}

    void FixedUpdate()
    {
        rigidbody.velocity = Vector3.left * 7f;
    }

    void OnTriggerEnter(Collider col)
    {
        var donuts = col.gameObject.GetComponent<Donuts>();
        if (donuts != null)
        {
            var manger = FindObjectOfType<GameManager>();
            manger.AddScore();
        }
    }
}
