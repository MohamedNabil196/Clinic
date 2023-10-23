using BackEnd.DTOModels;
using BackEnd.IService;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordController : ControllerBase
    {
        public IRecordService _recordService;
        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result =await _recordService.GetAll();
            return Ok(result);

        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] RecordDTO model)
        {
            BaseResult Response = new BaseResult();

            #region Model is Valid

            if (ModelState.IsValid)
            {
                var returnResultfromDb =await _recordService.Add(model);
                if (returnResultfromDb == null)
                {
                    Response.Data = null;
                    Response.Success = false;
                    return BadRequest(Response);
                }
                Response.Data = returnResultfromDb;
                Response.Success = true;
                return Ok(Response);
            }
            #endregion

            return Ok(Response);
        }


    }
}
