using System;
using System.Linq;
using System.Collections.Generic;

namespace GameServer.Maps {

    public class MapManager {
        /// <summary>
        /// Lista de mapas
        /// </summary>
        public static HashSet<MapData> Map = new HashSet<MapData>();

        /// <summary>
        /// Adiciona um novo mapa
        /// </summary>
        public static void Add(int mapID) {
            Map.Add(new MapData(mapID));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapID"></param>
        /// <returns></returns>
        public static MapData FindMapByID(int mapID) {
            var find_value = from mData in Map
                             where mData.ID.CompareTo(mapID) == 0
                             select mData;

            return find_value.FirstOrDefault();
        }
    }
}
