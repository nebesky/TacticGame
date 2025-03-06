using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extensions
{
    public static class Hex
    {
        private static Vector2Int TopLeft => new (-1,1);
        private static Vector2Int DownLeft => new (-1,-1);
        private static Vector2Int TopRight => new (1,-1);
        
        private static IEnumerable<Func<Vector2Int, Vector2Int>> Directions { get; } = new List<Func<Vector2Int, Vector2Int>>
        {
            target => target + (target.y % 2 == 0 ? TopLeft : Vector2Int.up),
            target => target + (target.y % 2 == 0 ? Vector2Int.up : Vector2Int.one),
            target => target + Vector2Int.right,
            target => target + (target.y % 2 == 0 ? new Vector2Int(0,-1) : TopRight),
            target => target + (target.y % 2 == 0 ? DownLeft : Vector2Int.down),
            target => target + Vector2Int.left
        };

        public static IEnumerable<Vector2Int> AStar(
            Vector2Int startCell,
            Vector2Int targetCell,
            IList<Vector2Int> availableCells)
        {
            var path = new List<Vector2Int>();

            if (availableCells.Contains(targetCell))
            {
                var neighborStartCellCoordinates = GetAvailableNeighborCellCoordinates(startCell);

                if (neighborStartCellCoordinates.Any(cell => cell == targetCell))
                {
                    //если целевая клетка сосед - Записываем путь сразу
                    path.Add(startCell);
                    path.Add(targetCell);
                }
                else
                {
                    var isProcessedCells = false;
                    var openList = GetAvailableNeighborCellCoordinates(startCell)
                        .Select(neighborCoordinate => new PathHex
                        {
                            coordinate = neighborCoordinate,
                            IsProcessed = false,
                            g = 1,
                            h = 1,
                            neighborCoordinate = startCell
                        }).ToList();

                    while (!isProcessedCells)
                    {
                        var smallerHexPath = openList
                            .OrderBy(pathHex => pathHex.g + pathHex.h)
                            .FirstOrDefault(cell => cell.IsProcessed == false);

                        if (smallerHexPath == null) break;

                        foreach (var neighborCoordinate in GetAvailableNeighborCellCoordinates(smallerHexPath.coordinate))
                        {
                            if (openList.All(pathHex => pathHex.coordinate != neighborCoordinate))
                            {
                                var newPathHex = new PathHex
                                {
                                    coordinate = neighborCoordinate,
                                    IsProcessed = false,
                                    g = Distance(smallerHexPath.coordinate, neighborCoordinate),
                                    h = smallerHexPath.g + smallerHexPath.h + 1,
                                    neighborCoordinate = smallerHexPath.coordinate
                                };

                                openList.Add(newPathHex);

                                if (newPathHex.coordinate == targetCell)
                                {
                                    path = GetPathFromOpenList(openList).ToList();

                                    isProcessedCells = true;

                                    break;
                                }
                            }
                            else
                            {
                                //если нашли, то обрабатываем
                                var currentPathHex = openList.First(pathHex => pathHex.coordinate == neighborCoordinate);
                                if (currentPathHex.IsProcessed) continue;
                                
                                var currentHexWeight = smallerHexPath.g + smallerHexPath.h;

                                if (currentPathHex.h > currentHexWeight + 1)
                                {
                                    currentPathHex.h = currentHexWeight + 1;
                                    currentPathHex.neighborCoordinate = smallerHexPath.coordinate;
                                }
                            }
                        }

                        smallerHexPath.IsProcessed = true;
                    }
                }
            }

            return path;

            IEnumerable<Vector2Int> GetPathFromOpenList(IList<PathHex> pathHexes)
            {
                var processedPath = new List<Vector2Int> { targetCell };
                var currentHex = targetCell;

                while (currentHex != startCell)
                {
                    var hex = currentHex;
                    var currentPathHex = pathHexes.First(pathHex => pathHex.coordinate == hex);

                    currentHex = currentPathHex.neighborCoordinate;
                    processedPath.Add(currentHex);
                }

                processedPath.Reverse();

                return processedPath;
            }

            IEnumerable<Vector2Int> GetAvailableNeighborCellCoordinates(Vector2Int targetCoordinate) =>
                Directions.Select(direction => direction(targetCoordinate))
                    .Where(availableCells.Contains);
        }

        private static int Distance(Vector2Int firstCell, Vector2Int lastCell)
        {
            var dx = Math.Abs(firstCell.x - lastCell.x);
            var dy = Math.Abs(firstCell.y - lastCell.y);
            var dz = Math.Abs(firstCell.x + firstCell.y - lastCell.x - lastCell.y);

            return Math.Max(dx, Math.Max(dy, dz));
        }

        private class PathHex
        {
            public Vector2Int coordinate;
            public Vector2Int neighborCoordinate;
            public bool IsProcessed;
            public int g;
            public int h;
        }
    }
}