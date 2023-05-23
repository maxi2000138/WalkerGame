using System.Collections.Generic;
using Data.DataObjects;
using Infrastructure.DI;
using Infrastructure.Services;
using Inventory.Model;
using UnityEngine;

namespace Data.Extensions
{
        public static class DataExtensions
        {
                public static Vector3Data AsVector3Data(this Vector3 vector) => 
                        new Vector3Data(vector.x, vector.y, vector.z);
                public static Vector3 AsUnityVector(this Vector3Data vector3Data) =>
                        new Vector3(vector3Data.x, vector3Data.y, vector3Data.z);

                public static T ToDeserialized<T>(this string json) => 
                        JsonUtility.FromJson<T>(json);
        
                public static string ToJson(this object obj) => 
                        JsonUtility.ToJson(obj);

                public static List<Cell> ToInventoryList(this List<CellData> list)
                {
                        List<Cell> inventoryList = new List<Cell>(list.Count);
                        list.ForEach(item => 
                                inventoryList.Add(new Cell(ServiceLocator
                                        .Container
                                        .GetService<GameFactory>()
                                        .CreateLootItem(item.LootTypeId), item.Count)));

                        return inventoryList;
                }
                
                public static List<CellData> ToInventoryDataList(this List<Cell> list)
                {
                        List<CellData> cells = new List<CellData>(list.Count);
                        list.ForEach(item => cells.Add(new CellData(item)));
                        return cells;
                }
        }
}
