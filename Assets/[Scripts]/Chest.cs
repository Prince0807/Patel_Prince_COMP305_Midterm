using System.Collections;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] Sprite openChestSprite;
    [SerializeField] GameObject starPrefab;

    private void OnTriggerStay2D(Collider2D collision)
    {
        // If player is in Trigger of Chest and press E, open the chest & start shooting Stars...
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GetComponent<SpriteRenderer>().sprite = openChestSprite;
                StartCoroutine(shootStar());
            }
        }
    }

    IEnumerator shootStar()
    {
        Instantiate(starPrefab, transform);
        yield return new WaitForSeconds(0.12f);
        StartCoroutine(shootStar());
    }
}
