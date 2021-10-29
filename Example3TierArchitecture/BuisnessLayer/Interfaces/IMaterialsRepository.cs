using System.Collections.Generic;
using DataLayer.Entityes;

namespace BuisnessLayer.Interfaces
{
    public interface IMaterialsRepository
    {
        IEnumerable<Material> GetAllMaterials(bool includeDirectory = false);
        Material GetMaterialById(int materialId, bool includeDirectory = false);
        void SaveMaterial(Material material);
        void DeleteMaterial(Material material);
    }
}