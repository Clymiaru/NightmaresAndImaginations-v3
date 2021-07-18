using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.AI
{
    public class Grid : MonoBehaviour
    {
        [SerializeField] private int Width;
        [SerializeField] private int Height;
        [SerializeField] private float CellSize;
        
        private void OnDrawGizmos()
        {
            var objectPosition = transform.position;
            var startingPosition = objectPosition - new Vector3(Width / 2.0f * CellSize,
                                                                        Height / 2.0f * CellSize, 
                                                                        0.0f);
            
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var fromPos = new Vector3(x * CellSize + startingPosition.x, 
                                              y * CellSize + startingPosition.y,
                                              objectPosition.z);
                    
                    Gizmos.DrawSphere(fromPos, 0.1f);
                }
            }
        }
    }
}