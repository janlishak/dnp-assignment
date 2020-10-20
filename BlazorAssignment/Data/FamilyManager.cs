using BlazorAssignment.Models;
using BlazorAssignment.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorAssignment.Data
{
    public class FamilyManager : IFamilyManager
    {
        private readonly FileContext familyFileHandler;
        private IList<Adult> adults;

        public FamilyManager()
        {
            familyFileHandler = new FileContext();
            adults = familyFileHandler.Adults;
        }

        public void AddAdultToFamily(Adult adultToAdd)
        {
            int maxId = adults.Any() ? adults.Max(a => a.Id) : 0;

            if (adults.Any(a => a.Equals(adultToAdd)))
                throw new Exception($"{adultToAdd.FirstName} {adultToAdd.LastName} not load");
            adultToAdd.Id = ++maxId;
            adults.Add(adultToAdd);
            familyFileHandler.SaveChanges();

        }

        public IList<Adult> GetAdults()
        {
            return adults;
        }

        public void RemoveAdult(Adult adult)
        {
            if (adults.Contains(adult))
            {
                adults.Remove(adult);
                familyFileHandler.SaveChanges();
            }
        }

    }
}


//IList<Family> families = familyFileHandler.Families;
//Family family;

//try
//{
//    family = families.First(f => f.StreetName == familyToJoin.StreetName && f.HouseNumber == familyToJoin.HouseNumber);

//}
//catch (ArgumentNullException)
//{
//    return false;
//}
//if (family.Adults.Count<2)
//{
//}
//else
//{
//    throw new Exception("Family already has 2 adults");
//} 



//private IList<Adult> CollectAdults(IList<Family> families)
//{
//    foreach (var family in families)
//    {
//        foreach (var adult in family.Adults)
//        {
//            adults.Add(adult);
//        }
//    }
//    return adults;
//}

//----Family----
/*public bool AddFamily(Family toAdd)
{
    IList<Family> families = familyFileHandler.Families;
    int max = families.Any() ? families.Max(f => f.Id) : 0;

    toAdd.Id = ++max;
    int same = families.Where(f => (f.Id == toAdd.Id || (f.HouseNumber == toAdd.HouseNumber && f.StreetName == toAdd.StreetName))).Count();

    if (same < 1)
    {
        families.Add(toAdd);
        familyFileHandler.SaveChanges();
        return true;
    }
    else
    {
        throw new Exception("Already exists");
    }
            //families.Add(family);
    //WriteFamiliesToFile();
}

public IList<Family> GetFamilies()
{

    return familyFileHandler.Families;
}

public bool RemoveFamily(Family toRemove)
{
    bool removed = familyFileHandler.Families.Remove(toRemove);
    if(removed)
    {
        familyFileHandler.SaveChanges();
}
    return removed;


}
*/
/*public void UpdateFamily(Family family)
{
 Family toUpdate = families.First(t => t.HouseNumber == family.HouseNumber);
 WriteFamiliesToFile();
}
*/

