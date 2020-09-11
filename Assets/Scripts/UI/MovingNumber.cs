using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingNumber : MonoBehaviour
{
    [SerializeField]
    public Vector3 Direction {get; set; }



    [SerializeField]
    float velocity = 120.0f;
    [SerializeField]
    float lifeTime =5;
    public float Velocity { get { return velocity; } }
    

    void Start()
    {
        Invoke("DestroyIndicator", lifeTime);
    }


    private void Update()
    {
        Quaternion lookDirection = Quaternion.LookRotation(-Direction,Vector3.up);

        transform.rotation = lookDirection;
        transform.localPosition += Direction * velocity * Time.deltaTime;
    }

    void DestroyIndicator() {
        Destroy(this.gameObject);
    }
}
