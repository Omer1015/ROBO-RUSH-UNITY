using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject RespawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.position = RespawnPoint.transform.position;
        }
    }
}
