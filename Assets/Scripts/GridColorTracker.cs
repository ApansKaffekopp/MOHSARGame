using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridColorTracker : MonoBehaviour
{
    [SerializeField] List<PixelChangeColor> grid;
    List<Color> colorGrid;

    public List<Color> GetColorGrid() {
        List<Color> temp = new List<Color>();
        foreach(PixelChangeColor cube in grid) {
            temp.Add(cube.currentColor);
        }
        return temp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
