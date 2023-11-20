using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));

        if ((gameObject.transform.position.z <= -140.0f || gameObject.transform.position.z >= 100.0f)
            || (gameObject.transform.position.x <= -150.0f || gameObject.transform.position.x >= 150.0f))
        {
            Destroy(gameObject);
        }
    }
    
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
