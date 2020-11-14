using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    public static Image gameOverImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (KnightStats.GetCurrentHP() < 0) {
            gameOverImage.canvasRenderer.SetAlpha(1.0f);
        }
    }
    
    private void Awake()
    {
        gameOverImage = GetComponent<Image>();
    }
}

