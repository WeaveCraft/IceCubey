using IceCubey_Models;

namespace IceCubey_Business.Repository.IRepository
{
    public interface IExpenseCategoryRepository
    {
        public Task<ExpenseCategoryDTO> Create(ExpenseCategoryDTO objDTO);
        public Task<ExpenseCategoryDTO> Update(ExpenseCategoryDTO objDTO);
        public Task<int> Delete(int id);
        public Task<ExpenseCategoryDTO> Get(int id);
        public Task<IEnumerable<ExpenseCategoryDTO>> GetAll();
    }
}
