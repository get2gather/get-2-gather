using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.MobileServices;

namespace get_2_gather
{
    public class Person
    {
        public static IMobileServiceTable<Person> personTable = App.MobileService.GetTable<Person>();
        public static MobileServiceCollection<Person, Person> personItems;

        public int Id { get; set; }

        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "LastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "Reputation")]
        public int Reputation { get; set; }

        public static async void InsertPerson(Person personItem)
        {
            await personTable.InsertAsync(personItem);            
        }

        public static async void GetPeople(int personID)
        {
            try
            {
                personItems = await personTable
                    .Where(p => p.Id == personID)
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                throw e; //consider logging, etc :)
            }
        }

        public async void UpdatePerson(Person item)
        {
            // This code takes a freshly completed TodoItem and updates the database. When the MobileService 
            // responds, the item is removed from the list 
            await personTable.UpdateAsync(item);
        }

        //public static async void DeletePerson(int personID)
        //{
        //    try
        //    {
        //        await personTable.DeleteAsync(personTable
        //            .Where(p => p.Id == personID));
        //    }
        //    catch (MobileServiceInvalidOperationException e)
        //    {
        //        throw e; //consider logging, etc :)
        //    }
        //}
    }


}
