using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hitsLeft = 3;

    ScoreBoard scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        addBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void addBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        processHit();
        if (hitsLeft <= 1)
        {
            killEnemy();
        }
    }

    private void processHit()
    { 
        hitsLeft--;
    }

    private void killEnemy()
    {
        scoreBoard.scoreHit(scorePerHit);
        GameObject fx = Instantiate(deathFX, transform.position,
            Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
