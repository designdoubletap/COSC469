using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject consumable;

    int spawnNum;

	// Use this for initialization
	void Start () {

        spawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void spawn()
    {
        for(int i = 0; i < spawnNum; i++)
        {
            Vector3 consumeablePos = new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f),
                                                 this.transform.position.y + Random.Range(0.0f, 2.0f),
                                                 this.transform.position.z + Random.Range(-1.0f, 1.0f));
            Instantiate(consumable, consumeablePos, Quaternion.identity);
        }
    }
}
