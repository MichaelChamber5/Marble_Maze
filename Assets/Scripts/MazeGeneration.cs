using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class MazeGeneration : MonoBehaviour
{
    [SerializeField] GameObject block;
    [SerializeField] GameObject winBlock;
    [SerializeField] GameObject playerBall;
    [SerializeField] int mazeSize = 10;

    private int[,] maze;
    private Stack<Vector2Int> stack;
    private System.Random random;

    void Start()
    {
        maze = new int[mazeSize, mazeSize];
        GenerateMaze();
        PrintMaze(); // For debugging, prints the maze to the console
    }

    void GenerateMaze()
    {
        // Initialize maze with walls (1's)
        for (int x = 0; x < mazeSize; x++)
        {
            for (int y = 0; y < mazeSize; y++)
            {
                maze[x, y] = 1;
            }
        }

        stack = new Stack<Vector2Int>();
        random = new System.Random();

        // Start at position on the grid, must be odd
        Vector2Int startPos = new Vector2Int(1, 1);
        stack.Push(startPos);
        maze[startPos.x, startPos.y] = 0; // Mark as path

        while (stack.Count > 0)
        {
            Vector2Int current = stack.Peek();
            List<Vector2Int> neighbors = GetValidNeighbors(current);

            if (neighbors.Count > 0)
            {
                Vector2Int chosen = neighbors[random.Next(neighbors.Count)];

                // Remove the wall between the current cell and the chosen cell
                Vector2Int wall = (current + chosen) / 2;
                maze[wall.x, wall.y] = 0;

                // Mark the chosen cell as a path and add it to the stack
                maze[chosen.x, chosen.y] = 0;
                stack.Push(chosen);
            }
            else
            {
                stack.Pop();
            }
        }
    }

    List<Vector2Int> GetValidNeighbors(Vector2Int cell)
    {
        List<Vector2Int> neighbors = new List<Vector2Int>();

        Vector2Int[] directions = {
            new Vector2Int(0, 2),  // Up
            new Vector2Int(2, 0),  // Right
            new Vector2Int(0, -2), // Down
            new Vector2Int(-2, 0)  // Left
        };

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbor = cell + direction;
            if (IsInBounds(neighbor) && maze[neighbor.x, neighbor.y] == 1)
            {
                neighbors.Add(neighbor);
            }
        }

        return neighbors;
    }

    bool IsInBounds(Vector2Int cell)
    {
        return cell.x > 0 && cell.x < mazeSize - 1 && cell.y > 0 && cell.y < mazeSize - 1;
    }

    void PrintMaze()
    {
        for (int i = 0; i < mazeSize; i++)
        {
            for (int k = 0; k < mazeSize; k++)
            {
                if (maze[i, k] == 1)
                {
                    Instantiate(block, new Vector3(i - mazeSize / 2, 0, k - mazeSize / 2), Quaternion.identity);
                }
            }
        }
        GameObject.Instantiate(winBlock, new Vector3(mazeSize / 2 - 1, 0, mazeSize / 2 - 1), Quaternion.identity);
        GameObject.Instantiate(playerBall, new Vector3(-mazeSize / 2 + 1, 0, -mazeSize / 2 + 1), Quaternion.identity);
    }
}
