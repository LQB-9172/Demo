using AutoMapper;
using Demo.Data;
using Demo.Models;
using Demo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly Datacontext _context;
        private readonly IMapper _mapper;

        public TestRepository(Datacontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddTestAsync(TestModel model)
        {
            var newTest = _mapper.Map<Test>(model);
            _context.Tests.Add(newTest);
            await _context.SaveChangesAsync();
            return newTest.TestID;
        }

        public async Task<bool> DeleteTestAsync(int id)
        {
            var deleteTest = await _context.Tests.FindAsync(id);
            if (deleteTest == null)
            {
                return false;
            }

            _context.Tests.Remove(deleteTest);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TestModel>> GetAllTestAsync()
        {
            var tests = await _context.Tests.ToListAsync();
            return _mapper.Map<List<TestModel>>(tests);
        }

        public async Task<TestModel> GetTest(int TestId)
        {
            var test = await _context.Tests.FindAsync(TestId);
            return _mapper.Map<TestModel>(test);
        }

        public async Task<bool> UpdateTestAsync(int id, TestModel model)
        {
            var existTest = await _context.Tests.FindAsync(id);
            if (existTest != null)
            {
                _context.Entry(existTest).State = EntityState.Detached;
                var updateTest = _mapper.Map<Test>(model);
                _context.Tests.Update(updateTest);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
