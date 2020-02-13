using Mine.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        /// <summary>
        /// The Data List
        /// This is where the items are stored
        /// </summary>
        public List<ItemModel> datalist;

        /// <summary>
        /// Constructor for the Storee
        /// </summary>
        public MockDataStore()
        {
            // Load the dataset
            LoadDefaultData();
        }

        /// <summary>
        /// Load the Default data
        /// </summary>
        /// <returns></returns>
        public bool LoadDefaultData()
        {
            datalist = new List<ItemModel>()
            {
                new ItemModel { Name = "Band Ages", Description="Heals damage done to a character", Value=5 },
                new ItemModel { Name = "Med Kit", Description="Offers extra protection from damage", Value=1 },
                new ItemModel { Name = "Wo Od", Description="Material that can be used to build", Value=3 },
                new ItemModel { Name = "Po Tion", Description="Offers extra health", Value=6 },
                new ItemModel { Name = "Tr Ap", Description="Item that can trick opposing players into getting damage", Value=9 },
            };

            return true;
        }

        /// <summary>
        /// Add the data to the list
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True for pass, else fail</returns>
        public async Task<bool> CreateAsync(ItemModel data)
        {
            datalist.Add(data);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Update the data with the information passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns>True for pass, else fail</returns>
        public async Task<bool> UpdateAsync(ItemModel data)
        {
            var oldData = datalist.Where((ItemModel arg) => arg.Id == data.Id).FirstOrDefault();
            datalist.Remove(oldData);
            datalist.Add(data);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Deletes the Data passed in by
        /// Removing it from the list
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True for pass, else fail</returns>
        public async Task<bool> DeleteAsync(string id)
        {
            var oldData = datalist.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            datalist.Remove(oldData);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// Takes the ID and finds it in the data set
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Record if found else null</returns>
        public async Task<ItemModel> ReadAsync(string id)
        {
            return await Task.FromResult(datalist.FirstOrDefault(s => s.Id == id));
        }

        /// <summary>
        /// Get the full list of data
        /// </summary>
        /// <param name="forceRefresh"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ItemModel>> IndexAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(datalist);
        }
        public void WipeDataList()
        {
            datalist.Clear();
            LoadDefaultData();
        }
    }
}