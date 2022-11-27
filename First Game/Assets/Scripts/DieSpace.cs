using UnityEngine;

public class DieSpace : MonoBehaviour
{
    private Player player;
    public int damage;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void OnCollisionEnter2D(Collision2D ñollision)
    {
        if (ñollision.gameObject.tag == "Player")
        {
            TakeDamage();

        }
    }

    public void TakeDamage()
    {
        player.health -= damage;
    }

}
