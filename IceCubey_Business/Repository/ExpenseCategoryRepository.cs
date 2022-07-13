using AutoMapper;
using IceCubey_Business.Repository.IRepository;
using IceCubey_DataAccess;
using IceCubey_DataAccess.Data;
using IceCubey_Models;
using Microsoft.EntityFrameworkCore;

namespace IceCubey_Business.Repository
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ExpenseCategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ExpenseCategoryDTO> Create(ExpenseCategoryDTO objDTO)
        {
            var obj = _mapper.Map<ExpenseCategoryDTO, ExpenseCategory>(objDTO);
            obj.CreatedDate = DateTime.Now;
            var addedObj = _db.ExpenseCategories.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<ExpenseCategory, ExpenseCategoryDTO>(addedObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.ExpenseCategories.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.ExpenseCategories.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<ExpenseCategoryDTO> Get(int id)
        {
            var obj = await _db.ExpenseCategories.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                return _mapper.Map<ExpenseCategory, ExpenseCategoryDTO>(obj);
            }
            return new ExpenseCategoryDTO();
        }

        public async Task<IEnumerable<ExpenseCategoryDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<ExpenseCategory>, IEnumerable<ExpenseCategoryDTO>>(_db.ExpenseCategories);
        }

        public async Task<ExpenseCategoryDTO> Update(ExpenseCategoryDTO objDTO)
        {
            var objFromDb = await _db.ExpenseCategories.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = objDTO.Name;
                _db.ExpenseCategories.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<ExpenseCategory, ExpenseCategoryDTO>(objFromDb);
            }
            return objDTO;

        }
    }
}
