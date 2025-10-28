using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadTurnel : MonoBehaviour
{
    public void EnterTurnel()
    {
        SceneManager.LoadScene("Turnel");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Turnel"))
        {
            EnterTurnel();
        }
    }
}
