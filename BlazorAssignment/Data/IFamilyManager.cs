using BlazorAssignment.Models;
using System.Collections.Generic;

namespace BlazorAssignment.Data
{
    interface IFamilyManager
    {
        IList<Adult> GetAdults();
        void AddAdultToFamily(Adult adultToAdd);
        void RemoveAdult(Adult adult);

        // IList<Family> GetFamilies();
        // bool AddFamily(Family toAdd);
        // bool RemoveFamily(Family toRemove);
        // bool AddAdultToFamily(Adult adultToAdd);//, Family familyToJoin);
    }
}
