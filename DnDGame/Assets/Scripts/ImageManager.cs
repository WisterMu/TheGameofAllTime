using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.WSA;

public class ImageManager : MonoBehaviour
{
    public RawImage[] objectArray;   // array of images to manipulate (separate objects)
    private List<Texture2D[]> imageLibrary = new List<Texture2D[]>();    // Array of all images to swap between
    public Texture2D[] manLibrary;
    // ideally we have a 2D array which contains all images, and related images are grouped by column
    // ALternative is to have a bunch of separate image arrays for each character which isn't great but isn't the worst
    // We would somehow need to differentiate between which library we're using when changing different character images
    int objectIndex = 0;            // index of object to manipulate
    int libraryIndex = 0;           // index within the library
    
    // Start is called before the first frame update
    void Start()
    {
        imageLibrary.Add(manLibrary);   // add the images from man into the library
    }

    // Update is called once per frame
    void Update()
    {
        // frameCounter++;
        // if (frameCounter % 60 == 0)     // every 60 frames
        // {
        //     objectArray[objectIndex].texture = imageLibrary[objectIndex][libraryIndex];
        //     libraryIndex = (libraryIndex + 1) % imageLibrary[objectIndex].Length;
        // }
    }

    // FOR TESTING: Cycles through the images in a character library
    public void UpdateImage()
    {
        objectArray[objectIndex].texture = imageLibrary[objectIndex][libraryIndex];     // switches image
        objectIndex = (objectIndex + 1) % imageLibrary.Count();                 // selects next object
        libraryIndex = (libraryIndex + 1) % imageLibrary[objectIndex].Length;   // selects next image
    }

    // Swaps a chosen Raw Image object (charIndex) into the chosen image stored in the libraru (imageIndex)
    public void SetImage(int charIndex, int imageIndex)
    {
        objectArray[charIndex].texture = imageLibrary[charIndex][imageIndex];
    }
}
