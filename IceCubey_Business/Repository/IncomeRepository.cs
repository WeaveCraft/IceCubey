using AutoMapper;
using IceCubey_Business.Repository.IRepository;
using IceCubey_DataAccess;
using IceCubey_DataAccess.Data;
using IceCubey_Models;
using Microsoft.EntityFrameworkCore;

namespace IceCubey_Business.Repository
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public IncomeRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IncomeDTO> Create(IncomeDTO objDTO)
        {
            var obj = _mapper.Map<IncomeDTO, Income>(objDTO);
            var addedObj = _db.Incomes.Add(obj);
            await _db.SaveChangesAsync();

            return _mapper.Map<Income, IncomeDTO>(addedObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Incomes.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.Incomes.Remove(obj);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IncomeDTO> Get(int id)
        {
            var obj = await _db.Incomes.Include(u => u.Category).FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Income, IncomeDTO>(obj);
            }
            return new IncomeDTO();
        }

        public async Task<IEnumerable<IncomeDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Income>, IEnumerable<IncomeDTO>>(_db.Incomes.Include(u => u.Category));
        }

        public async Task<IncomeDTO> Update(IncomeDTO objDTO)
        {
            var objFromDb = await _db.Incomes.FirstOrDefaultAsync(u => u.Id == objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = objDTO.Name;
                objFromDb.Description = objDTO.Description;
                objFromDb.ImageUrl = objDTO.ImageUrl;
                objFromDb.CategoryId = objDTO.CategoryId;
                objFromDb.Date = objDTO.Date;
                objFromDb.IsCommon = objDTO.IsCommon;
                objFromDb.IsUncommon = objDTO.IsUncommon;
                _db.Incomes.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Income, IncomeDTO>(objFromDb);
            }
            return objDTO;

        }
    }
}
