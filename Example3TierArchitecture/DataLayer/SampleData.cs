using System.Linq;

namespace DataLayer
{
   public static class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if (!context.Directory.Any())
            {
                // Directories
                context.Directory.Add(new Entityes.Directory() { Title = "Amazon orders", Html = "<b>Directory Content</b>" });
                context.Directory.Add(new Entityes.Directory() { Title = "Iherb orders", Html = "<b>Directory Content</b>" });
                context.SaveChanges();

                // Materials
                context.Material.Add(new Entityes.Material() { Title = "Сlothing", Html = "<i>Material Content</i>", DirectoryId = context.Directory.First().Id });
                context.Material.Add(new Entityes.Material() { Title = "Books", Html = "<i>Material Content</i>", DirectoryId = context.Directory.First().Id });
                context.Material.Add(new Entityes.Material() { Title = "TV", Html = "<i>Material Content</i>", DirectoryId = context.Directory.OrderByDescending( o => o.Id).Last().Id });
                context.Material.Add(new Entityes.Material() { Title = "Herbal Tea", Html = "<i>Material Content</i>", DirectoryId = context.Directory.First().Id + 1 });
                context.SaveChanges();
            }
        }
    }
}