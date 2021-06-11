using UnityEngine;


//LOTS OF MATH THAT I DONT UNDERSTAND IS HERE, ALL IT DOES IS MAKE COOL HEXAGON GRID.
//IDK HOW TO EXPLAIN HOW THE MATH WORKS IT JUST DOES!

//I only ran this script once, to create the grid. I then copied it during
//play mode and pasted it in edit mode so it would become permenant.

//I like hexagons :)
public class HexGridGenerator : MonoBehaviour
{
    public Transform hexPrefab;
        
    public int gridWidth = 30;
    public int gridHeight = 30;

    float hexWidth = 1.732f;
    float hexHeight = 2.0f;
    public float gap = 0.0f;

    Vector3 startPos;

    void Start()
    {
        //runs all the math
        AddGap();
        CalcStartPos();
        CreateGrid();
    }

    void AddGap()
    {
        //math
        hexWidth += hexWidth * gap;
        hexHeight += hexHeight * gap;
    }

    void CalcStartPos()
    {
        //More math
        float offset = 0;
        if (gridHeight / 2 % 2 != 0)
            offset = hexWidth / 2;

        float x = -hexWidth * (gridWidth / 2) - offset;
        float z = hexHeight * 0.75f * (gridHeight / 2);

        startPos = new Vector3(x, 0, z);
    }

    Vector3 CalcWorldPos(Vector2 gridPos)
    {
        //A bit more math :)
        float offset = 0;
        if (gridPos.y % 2 != 0)
            offset = hexWidth / 2;

        float x = startPos.x + gridPos.x * hexWidth + offset;
        float z = startPos.z - gridPos.y * hexHeight * 0.75f;

        return new Vector3(x, 0, z);
    }

    void CreateGrid()
    {
        //Just a little bit more math
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                Transform hex = Instantiate(hexPrefab) as Transform;
                Vector2 gridPos = new Vector2(x, y);
                hex.position = CalcWorldPos(gridPos);
                hex.parent = this.transform;
                hex.name = "Hexagon" + x + "|" + y;
            }
        }
    }
}