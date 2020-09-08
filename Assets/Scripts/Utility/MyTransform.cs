using UnityEngine;

struct MyTransform
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 localScale;


    public MyTransform(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        this.position = position;
        this.rotation = rotation;
        this.localScale = scale;
    }

    public MyTransform(Transform tranform)
    {
        this.position = tranform.position;
        this.rotation = tranform.rotation;
        this.localScale = tranform.localScale;
    }
}


