using Agency.Core.Contracts;
using Agency.Exceptions;
using Agency.Models;
using Agency.Models.Contracts;

using System;
using System.Collections.Generic;

namespace Agency.Core
{
    public class Repository : IRepository
    {
        private readonly List<IVehicle> vehicles = new List<IVehicle>();
        private readonly List<IJourney> journeys = new List<IJourney>();
        private readonly List<ITicket> tickets = new List<ITicket>();

        public IList<IVehicle> Vehicles
        {
            get
            {
                var copiedList = DuplicateVehiclesList(this.vehicles);
                return copiedList;
            }
        }
        public IList<IJourney> Journeys
        {
            get
            {
                var copiedList = DuplicateJourneysList(this.journeys);
                return copiedList;
            }
        }
        public IList<ITicket> Tickets
        {
            get
            {
                var copiedList = DuplicateTicketsList(this.tickets);
                return copiedList;
            }
        }

        public IBus CreateBus(int passengerCapacity, double pricePerKilometer, bool hasFreeTv)
        {
            int nextId = vehicles.Count;
            var bus = new Bus(++nextId, passengerCapacity, pricePerKilometer, hasFreeTv);
            this.vehicles.Add(bus);
            return bus;
        }

        public IAirplane CreateAirplane(int passengerCapacity, double pricePerKilometer, bool isLowCost)
        {
            int nextId = vehicles.Count;
            var airplane = new Airplane(++nextId, passengerCapacity, pricePerKilometer, isLowCost);
            this.vehicles.Add(airplane);
            return airplane;
        }

        public ITrain CreateTrain(int passengerCapacity, double pricePerKilometer, int carts)
        {
            int nextId = vehicles.Count;
            var train = new Train(++nextId, passengerCapacity, pricePerKilometer, carts);
            this.vehicles.Add(train);
            return train;
        }

        public IJourney CreateJourney(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            int nextId = journeys.Count;
            var journey = new Journey(++nextId, startLocation, destination, distance, vehicle);
            this.journeys.Add(journey);
            return journey;
        }

        public ITicket CreateTicket(IJourney journey, double administrativeCosts)
        {
            int nextId = tickets.Count;
            var ticket = new Ticket(++nextId, journey, administrativeCosts);
            this.tickets.Add(ticket);
            return ticket;
        }

        public IVehicle FindVehicleById(int id)
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Id == id)
                {
                    return vehicle;
                }
            }
            throw new EntityNotFoundException($"A vehicle with the id: {id} was not found!");
        }

        public IJourney FindJourneyById(int id)
        {
            var foundJourney = journeys.Find(journey => journey.Id == id);
            if (foundJourney == null)
            {
                throw new EntityNotFoundException($"A journey with the id: {id} was not found!");
            }
            return foundJourney;
        }

        public ITicket FindTicketById(int id)
        {
            var foundTicket = tickets.Find(ticket => ticket.Id == id);
            if (foundTicket == null)
            {
                throw new EntityNotFoundException($"A ticket with the id: {id} was not found!");
            }
            return foundTicket;
        }
        private IList<IVehicle> DuplicateVehiclesList(IList<IVehicle> vehicles)
        {
            var duplicateList = new List<IVehicle>();
            foreach (var vehicle in vehicles) 
            {
                duplicateList.Add(vehicle.Copy());
            }
            return duplicateList;
        }
        private IList<IJourney> DuplicateJourneysList(IList<IJourney> journeys)
        {
            var duplicateList = new List<IJourney>();
            foreach (var journey in journeys)
            {
                duplicateList.Add(journey.Clone());
            }
            return duplicateList;
        }
        private IList<ITicket> DuplicateTicketsList(IList<ITicket> tickets)
        {
            var duplicateList = new List<ITicket>();
            foreach (var ticket in tickets)
            {
                duplicateList.Add(ticket.Clone());
            }
            return duplicateList;
        }
    }
}
