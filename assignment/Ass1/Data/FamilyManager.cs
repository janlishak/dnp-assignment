using Ass1.Models;
using Ass1.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ass1.Data
{
    public class FamilyManager : IFamilyManager
    {
        private readonly FileContext familyFileHandler;

        public FamilyManager()
        {
            familyFileHandler = new FileContext();
        }


        public bool AddAdultToFamily(Adult adultToAdd)//, Family familyToJoin)
        {
            //IList<Family> families = familyFileHandler.Families;
            IList<Adult> adults = familyFileHandler.Adults;
            Family family;

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
            int maxId = adults.Any() ? adults.Max(a => a.Id) : 0;

            if (adults.Any(a => a.Equals(adultToAdd)))
                throw new Exception($"{adultToAdd.FirstName} {adultToAdd.LastName} not load");
            adultToAdd.Id = ++maxId;
            adults.Add(adultToAdd);
            familyFileHandler.SaveChanges();
            return true;

            //}
            //else
            //{
            //    throw new Exception("Family already has 2 adults");
            //} 
        }


        public IList<Adult> GetAdults()
        {

            IList<Adult> adults = familyFileHandler.Adults;
            return adults;
        }

        public void RemoveAdult(Adult adult)
        {
            IList<Adult> adults = familyFileHandler.Adults;

            if (adults.Contains(adult))
            {
                adults.Remove(adult);
                familyFileHandler.SaveChanges();

            }
        }

        private IList<Adult> CollectAdults(IList<Family> families)
        {
            IList<Adult> adults = new List<Adult>();
            foreach (var family in families)
            {
                foreach (var adult in family.Adults)
                {
                    adults.Add(adult);
                }
            }
            return adults;
        }

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
    }
}
