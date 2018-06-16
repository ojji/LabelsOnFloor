﻿using System.Collections.Generic;
using System.Linq;
using Verse;

namespace LabelsOnFloor
{
    public class CustomRoomLabelManager
    {
        private readonly List<CustomRoomData> _roomLabels = new List<CustomRoomData>();


        public bool IsRoomCustomised(Room room)
        {
            return _roomLabels.Any(rl => rl.RoomObject == room);
        }

        public string GetCustomLabelFor(Room room)
        {
            Main.Instance.Logger.Message($"Looking for room {room}");

            foreach (var customRoomData in _roomLabels)
            {
                Main.Instance.Logger.Message($"Custom label for {customRoomData.RoomObject} is {customRoomData.Label}");
            }

            var result = _roomLabels.FirstOrDefault(rl => rl.RoomObject == room)?.Label;
            Main.Instance.Logger.Message($"Label returned is {result}");

            return result;
        }

        public CustomRoomData GetOrCreateCustomRoomDataFor(Room room, IntVec3 loc)
        {
            var result = _roomLabels.FirstOrDefault(rl => rl.RoomObject == room);
            if (result != null)
                return result;

            result = new CustomRoomData(room, Find.VisibleMap, "", loc);
            _roomLabels.Add(result);
            result = _roomLabels.FirstOrDefault(rl => rl.RoomObject == room);

            return result;
        }

        public void CleanupMissingRooms()
        {
            _roomLabels.RemoveAll(data => !data.IsRoomStillValid() || string.IsNullOrEmpty(data.Label));
        }
    }
}