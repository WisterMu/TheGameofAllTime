using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    public RawImage[] imageArray;   // array of images to manipulate
    public Texture2D[] imageLibrary;    // complete collection of images to swap between
    RawImage test;
    int imageIndex = 0;
    int libraryIndex = 0;
    int frameCounter = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frameCounter++;
        if (frameCounter % 60 == 0)     // every 60 frames
        {
            imageArray[imageIndex].texture = imageLibrary[libraryIndex];
            libraryIndex = (libraryIndex + 1) % imageLibrary.Count();
        }
    }
}
