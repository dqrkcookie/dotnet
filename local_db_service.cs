using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawfect_Care
{
    public class local_db_service
    {

        private const string db_name = "local_pet_profile.db3";
        private SQLiteAsyncConnection db_connection;

        public local_db_service()
        {
            // save image to device's specific folder
            //string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "pet_data");

            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}

            //string dbPath = Path.Combine(folderPath, db_name);
            //db_connection = new SQLiteAsyncConnection(dbPath);

            db_connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, db_name));
            db_connection.CreateTableAsync<pet_local_db>();
        }

        public async Task<List<pet_local_db>> GetAllPets()
        {
            return await db_connection.Table<pet_local_db>().ToListAsync();
        }

        public async Task<pet_local_db> GetPetId(int id)
        {
            return await db_connection.Table<pet_local_db>().Where(x => x.pet_id == id).FirstOrDefaultAsync();
        }

        public async Task AddPet(pet_local_db pet)
        {
            await db_connection.InsertAsync(pet);
        }

        public async Task UpdatePet(pet_local_db pet)
        {
            await db_connection.UpdateAsync(pet);
        }

        public async Task DeletePet(int id)
        {
            var pet = await GetPetId(id);
            if (pet != null)
            {
                await db_connection.DeleteAsync(pet);
            }
        }
    }
}
