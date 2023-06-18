using UnityEngine;

public class TargetX : MonoBehaviour
{
    private GameManagerX gameManagerX;
    public int pointValue;
    public GameObject explosionFx;

    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
    }

    // When target is clicked, destroy it, update score, and generate explosion if object is bad - GameOver
    private void OnMouseDown()
    {
        if (gameManagerX.isGameActive)
        {
            gameManagerX.UpdateScore(pointValue);
            Explode();

            if (gameObject.tag.Equals("Bad"))
            {
                gameManagerX.GameOver();
            }

            Destroy(gameObject);
        }
    }

    void Explode()
    {
        Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);
    }
}
