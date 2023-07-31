using Application.UseCases.Categories.Command.CreateCategory;
using Application.UseCases.Categories.Command.UpdateCategory;

namespace Application.Comman.Mappings
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CategoryMap();
        }
        private void CategoryMap()
        {
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();
        }
    }
}
