using System.Collections.Generic;
using DataLayer.Entityes;

namespace BuisnessLayer.Interfaces
{
    public interface IDirectorysRepository
    {
        IEnumerable<Directory> GetAllDirectorys(bool includeMaterials = false);
        Directory GetDirectoryById(int directoryId, bool includeMaterials = false);
        void SaveDirectory(Directory achieve);
        void DeleteDirectory(Directory achieve);
    }
}