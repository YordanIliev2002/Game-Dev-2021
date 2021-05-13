using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private GameObject objectToFollow;
    [SerializeField] private float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        if(!objectToFollow)
        {
            objectToFollow = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(objectToFollow != null)
        {
            Vector2 dir = objectToFollow.transform.position - transform.position;
            Vector2 dirScaled = dir * Time.deltaTime * speed;
            transform.Translate(dirScaled);
        }
    }

    public void FollowObject(GameObject go)
    {
        objectToFollow = go;
    }
}
