using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Hero.Enums;
using Level;
using Level.Structs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Extensions
{
    public class LevelDataConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var teamColorsToken = jsonObject["TeamColors"];
            var cellsToken = jsonObject["Cells"];
            var teams = new Dictionary<TeamSideType, IList<Vector2Int>>();

            var result = new LevelData
            {
                Name = jsonObject["Name"].Value<string>(),
                Cells = new List<CellData>(),
                Sides = new List<SideData>()
            };

            foreach (var token in cellsToken)
            {
                var values = token
                    .ToString()
                    .Replace("\"", "")
                    .Split(':');

                var vectorInt = values[0]
                    .Replace("(", "")
                    .Replace(")", "")
                    .Split(',');
                
                var cellPosition = new Vector2Int(int.Parse(vectorInt[0]), int.Parse(vectorInt[1]));
                var cellType = (CellType)int.Parse(values[1]);

                result.Cells.Add(new CellData(cellType, cellPosition));
            }

            foreach (var token in teamColorsToken)
            {
                var sideType = (TeamSideType)Enum.Parse(typeof(TeamSideType), token.Path.Split(".").Last());
                var colorJson = token.First.ToObject<ColorJSON>();
                var newTeam = new TeamData(sideType, colorJson);
                var newSide = new SideData(
                    newTeam, 
                    teams.TryGetValue(sideType, out var team) ? team.ToList() : new List<Vector2Int>());

                result.Sides.Add(newSide);
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType) => true;
    }
}