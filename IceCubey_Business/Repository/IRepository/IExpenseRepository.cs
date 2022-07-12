using IceCubey_Models;

namespace IceCubey_Business.Repository.IRepository
{
    public interface IExpenseRepository
    {
        public Task<ExpenseDTO> Create(ExpenseDTO objDTO);
        public Task<ExpenseDTO> Update(ExpenseDTO objDTO);
        public Task<int> Delete(int id);
        public Task<ExpenseDTO> Get(int id);
        public Task<IEnumerable<ExpenseDTO>> GetAll();
    }
}
