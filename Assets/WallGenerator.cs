using UnityEngine;
using System.Collections;

public class WallGenerator : MonoBehaviour
{
    // 壁オブジェクト
    public GameObject wallPrefab;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    public void StartGeneration()
    {
        StartCoroutine("Generate");
    }

    public void StopGeneration()
    {
        StopCoroutine("Generate");
    }

    float y;
    IEnumerator Generate()
    {
        var pos = transform.position;
        while (true)
        {
            y += Random.Range(-3f, 3f);
            y = Mathf.Clamp(pos.y, -4f, 4f);
            pos.y = y;
            Instantiate(wallPrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }
}
