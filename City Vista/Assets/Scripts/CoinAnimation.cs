using UnityEngine;

public class CoinAnimation : MonoBehaviour
{   

    public float posY; //posição inicial moeda
    public Rigidbody2D coinRb;
    private bool isKick;


    void Start()
    {
        coinRb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (transform.position.y < posY && isKick == false) {
            isKick = true;
            coinRb.velocity = Vector2.zero;
            coinRb.AddForce(new Vector2(35, 300));
            Destroy(this.gameObject, 1);
        }
    }
}
