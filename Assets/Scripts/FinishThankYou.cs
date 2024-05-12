using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishThankYou : MonoBehaviour
{
    public GameObject thank;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Thank();
        }
    }

    public void Thank()
    {

        thank.SetActive(true);

        Time.timeScale = 0;

    }
}
