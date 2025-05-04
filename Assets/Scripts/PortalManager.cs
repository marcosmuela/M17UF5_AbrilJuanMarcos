using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalManager : MonoBehaviour
{
    public GameObject dungeonPortal;  // Teletransporta a nivel1
    public GameObject desertPortal;   // Teletransporta a nivel2
    public GameObject stadiumPortal;  // Teletransporta a nivel3

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        dungeonPortal.SetActive(currentScene != "nivel1");
        desertPortal.SetActive(currentScene != "nivel2");
        stadiumPortal.SetActive(currentScene != "nivel3");
    }
}
