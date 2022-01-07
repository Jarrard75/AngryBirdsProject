using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    private Vector3 _initialPosition;
    private bool _birdWasLaunched = false;
    private float _birdRespawnTimer = 0;

    [SerializeField] private float _launchPower = 250;
    


    private void Awake()
    {
        _initialPosition = transform.position;
    }

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1f)
        {
            _birdRespawnTimer += Time.deltaTime;
        }

        if (transform.position.y > 10 ||
            transform.position.y < -10 ||
            transform.position.x < -10 ||
            transform.position.x > 10 ||
            _birdRespawnTimer > 2)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        // GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp()
    {
        // GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _initialPosition - transform.position;

        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y);
    }

}
