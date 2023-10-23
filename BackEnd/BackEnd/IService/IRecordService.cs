using BackEnd.DTOModels;
using BackEnd.Models;

namespace BackEnd.IService
{
    public interface IRecordService
    {
        Task<IEnumerable<Record>> GetAll();
        Task< Object> Add(RecordDTO Model);
    }
}
