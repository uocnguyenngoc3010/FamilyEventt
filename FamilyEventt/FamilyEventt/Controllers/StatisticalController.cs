using FamilyEventt.Dto;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyEventt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticalController : ControllerBase
    {
        public IStatistical Service;
        public StatisticalController(IStatistical service)
        {
            this.Service = service;
        }
        /// <summary>
        /// Thống kê theo loại :
        /// 0. Thống kê số lượng event theo thời gian 
        /// 1. Thống kê số lượng người dùng
        /// 2. Thống kê loại event được book 
        /// 3. Thống kê đồ ăn được book
        /// 4. Thống kê vật phẩm trang trí được order
        /// 5. Thống kê phòng được sử dụng
        /// 6. Thống kê số lượng loại sự kiện được book theo thời gian
        /// 7. Thống kê doanh thu theo khoảng thời gian
        /// </summary>
        /// <param name="type"></param>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <returns>
        /// count: số lượng đếm theo yêu cầu 
        /// StartDate: ngày bắt đầu
        /// EndDate: ngày kết thúc
        /// StatisticalID : ID object or name object được thống kê
        /// TotalPrice: tổng tiền (đang update)
        /// </returns>
        [Route("get-data-statistial")]
        [HttpGet]

        public async Task<IActionResult> GetDataStatistical(int type, DateTime StartDate, DateTime EndDate)

        {
            ResponseAPI<List<StatisticalDto>> responseAPI = new ResponseAPI<List<StatisticalDto>>();
            try
            {
                responseAPI.Data = await this.Service.StatisticalDataByType(type,StartDate,EndDate);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
    }
}
