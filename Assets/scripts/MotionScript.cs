using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionScript : MonoBehaviour
{
    public float Thrust = 5f * Time.deltaTime;
    Rigidbody Rigidbody;
    public Animator camAnimator;
    public Collider ShakeCollider;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private GameObject ShakeCollison;
    [SerializeField] private GameObject CubeCollison;
    



    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Thrust = 8f;
        }
        else
        {
            Thrust = 5f;
        }

        Rigidbody.velocity = new Vector3(xMove, zMove, Rigidbody.velocity.z) * Thrust;

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ShakeCollider")
        {


            camAnimator.SetTrigger("Shake");
            Destroy(ShakeCollison);
        }

        if (other.gameObject.name == "Cube trigger")
        {
            Debug.Log(other + " was triggered");
            Destroy(other);
            Instantiate(prefab, spawnPosition.position, Quaternion.identity);
            
            
        }
        if (other.gameObject.name == "CubeEater")
        {
            Debug.Log(prefab + "was deleted");
            Destroy(prefab);
        }
        
    }

}
