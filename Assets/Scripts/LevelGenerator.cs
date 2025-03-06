using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DefaultNamespace.Hero.Enums;
using Level;
using Level.Structs;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

[Serializable]
public class LevelGenerator : MonoBehaviour
{
    [Serializable]
    public struct TileTypes
    {
        public EditorCellType cell;
        public Tile tile;
    }

    public List<TileTypes> TileTypesList;
    public Tilemap Tilemap;
    public string DefaultLevelName;
    public TextAsset DefaultLevelAsset;

    public Color DefaultTeam1Color;
    public Color DefaultTeam2Color;

    private GUIStyle style;

    private void OnDrawGizmosSelected()
    {
        style = new GUIStyle();
        style.normal.textColor = Color.black;
        style.fontSize = 10;
        style.alignment = TextAnchor.MiddleCenter;
    }

    public void OnGenerateLevelButtonClick()
    {
        var bounds = Tilemap.cellBounds;
        var cellPositionDictionary = new List<CellData>();
        var sides = new List<SideData>();
        var team1heroes = new List<Vector2Int>();
        var team2heroes = new List<Vector2Int>();
        var team1info = new TeamData(TeamSideType.Team1, DefaultTeam1Color);
        var team2info = new TeamData(TeamSideType.Team2, DefaultTeam2Color);

        foreach (var position in bounds.allPositionsWithin)
        {
            var tile = Tilemap.GetTile(position);
            if (tile == null) continue;

            var currentCellType = TileTypesList.FirstOrDefault(t => t.tile == tile).cell;
            var currentPosition = new Vector2Int(position.x, Math.Abs(position.y));

            switch (currentCellType)
            {
                case EditorCellType.Free:
                    cellPositionDictionary.Add(new CellData(CellType.Free, currentPosition));
                    break;
                case EditorCellType.Blocked:
                    cellPositionDictionary.Add(new CellData(CellType.Blocked, currentPosition));
                    break;
                case EditorCellType.Team1:
                    team1heroes.Add(currentPosition);
                    break;
                case EditorCellType.Team2:
                    team2heroes.Add(currentPosition);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        sides.Add(new SideData(team1info, team1heroes));
        sides.Add( new SideData(team2info, team2heroes));

        var pathToAsset = AssetDatabase.GetAssetPath(DefaultLevelAsset);
        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), pathToAsset);

        File.WriteAllText(fullPath, JsonConvert.SerializeObject(new LevelData
        {
            Cells = cellPositionDictionary,
            Name = DefaultLevelName,
            Sides = sides
        }));

        Debug.Log("Generating Level JSON success.");
        Debug.Log(AssetDatabase.GetAssetPath(DefaultLevelAsset));
    }

    private void OnDrawGizmos()
    {
        foreach (var position in Tilemap.cellBounds.allPositionsWithin)
        {
            var tile = Tilemap.GetTile(position);
            if (tile == null) continue;

            var oddRowPosition = new Vector2Int(
                position.x, 
                Math.Abs(position.y));

            Handles.Label(
                Tilemap.CellToWorld(position), 
                tile.name + "\n" + oddRowPosition,
                style
                );
        }
    }
}