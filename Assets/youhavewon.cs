using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class youhavewon : MonoBehaviour
{
    public Text textObject;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            textObject.text = "YOU WON";
            StartCoroutine(L());
        }
    }
    IEnumerator L()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("menu");
    }
}