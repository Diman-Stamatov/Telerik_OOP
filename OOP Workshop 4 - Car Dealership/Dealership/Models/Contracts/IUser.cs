﻿using System.Collections.Generic;

namespace Dealership.Models.Contracts
{
    public interface IUser : IPrintable
    {
        string Username { get; }

        string FirstName { get; }

        string LastName { get; }

        string Password { get; }

        RoleType Role { get; }

        IList<IVehicle> Vehicles { get; }

        void AddVehicle(IVehicle vehicle);

        void RemoveVehicle(IVehicle vehicle);

        void AddComment(IComment commentToAdd, IVehicle vehicleToCommentOn);

        void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment);

        string PrintVehicles();

        IUser Clone();
        
    }
}
