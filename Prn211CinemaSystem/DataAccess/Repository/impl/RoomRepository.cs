using BussinessObject.Models;
using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.impl
{
    public class RoomRepository : IRoomRepository
    {
        public List<Room> getListRooms() => RoomDao.GetRoomDAO.getListRoom();
        public Room getRoomById(int roomId) => RoomDao.GetRoomDAO.getRoomById(roomId);
    }
}
