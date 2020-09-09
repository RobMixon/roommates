using System;
using System.Collections.Generic;
using Roommates.Models;
using Roommates.Repositories;

namespace Roommates
{
    class Program
    {
        /// <summary>
        ///  This is the address of the database.
        ///  We define it here as a constant since it will never change.
        /// </summary>
        private const string CONNECTION_STRING = @"server=localhost\SQLExpress;database=Roommates;integrated security=true";

        static void Main(string[] args)
        {

            RoomRepository roomRepo = new RoomRepository(CONNECTION_STRING);

            /*
            Console.WriteLine("Getting All Rooms:");
            Console.WriteLine();

            List<Room> allRooms = roomRepo.GetAll();

            foreach (Room room in allRooms)
            {
                Console.WriteLine($"{room.Id} {room.Name} {room.MaxOccupancy}");
            }
            */
            Console.WriteLine("----------------------------");

            RoommateRepository roommateRepo = new RoommateRepository(CONNECTION_STRING);
            Console.WriteLine("getting all the roommates");
            Console.WriteLine();
            List<Roommate> allRoommates = roommateRepo.GetAll();
            foreach (Roommate roommate in allRoommates)
            {
                Console.WriteLine($"{roommate.Id} {roommate.Firstname} {roommate.Lastname} {roommate.RentPortion} {roommate.MovedInDate} {roommate.Room}");
            }
            /*
            Console.WriteLine("----------------------------");

            Console.WriteLine("Getting Room with Id 1");

            Room singleRoom = roomRepo.GetById(1);

            Console.WriteLine($"{singleRoom.Id} {singleRoom.Name} {singleRoom.MaxOccupancy}");
            */

            Console.WriteLine("----------------------------");
            Console.WriteLine("Getting Roommate with Id 1");

            Roommate roommate1 = roommateRepo.GetById(1);

            Console.WriteLine($"{roommate1.Firstname} {roommate1.Lastname} {roommate1.Room}");
            Console.WriteLine("----------------------------");

            // getting roommates based on roomId

            Console.WriteLine("getting all the roommates and all their room info");
            List<Roommate> allRoommatesWithRoom = roommateRepo.GetRoommatesByRoomId(1);
            foreach (Roommate roommateWithRoom in allRoommatesWithRoom)
            {
                Console.WriteLine($"{roommateWithRoom.Id}: {roommateWithRoom.Firstname} {roommateWithRoom.Lastname} is assigned {roommateWithRoom.Room.Name}; \n pays {roommateWithRoom.RentPortion} move-in-date: {roommateWithRoom.MovedInDate}");
            };
            Console.WriteLine("----------------------------");

            Roommate newRoommate = new Roommate
            {
                Firstname = "pablo",
                Lastname = "nuts",
                MovedInDate = new DateTime(2020, 2, 22),
                RentPortion = 12,
                Room = roomRepo.GetById(1)
            };

            //roommateRepo.Insert(newRoommate);
            //update
            roommateRepo.Update(newRoommate);
            Console.WriteLine($"updated juan to {newRoommate.Firstname}");
            Console.WriteLine("----------------------------");

            roommateRepo.Delete(2);
            /*
            Room bathroom = new Room
            {
                Name = "Bathroom",
                MaxOccupancy = 1
            };

            roomRepo.Insert(bathroom);

            */


            /*
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Added the new Room with id {bathroom.Id}");

            bathroom.MaxOccupancy = 3;

            roomRepo.Update(bathroom);


            Console.WriteLine("-------------------------------");
            Console.WriteLine($"updated the room to have max occupancy of {bathroom.MaxOccupancy}");
            */


            /*
            foreach (Room room in allRooms)
            {
                Console.WriteLine($"{room.Id} {room.Name} {room.MaxOccupancy}");
            }
            Console.WriteLine("-------------------------------");

            roomRepo.Delete(bathroom.Id);
            */
        }
    }
}