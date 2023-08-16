using FamilyEventt.Dto;
using FamilyEventt.Dto.ResponeEventForExport;
using FamilyEventt.Interfaces;
using FamilyEventt.Models;
using FamilyEventt.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Twilio.Http;
using VetCV.HtmlRendererCore.PdfSharpCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FamilyEventt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public IEvent EventService;
        public FamilyEventContext db;
        public EventController(IEvent service , FamilyEventContext db) 
        {
            this.EventService = service;
            this.db = db;
            //EventService.disableEvent();
        }
        // GET: api/<EventController>
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            ResponseAPI<List<Event>> responseAPI = new ResponseAPI<List<Event>>();
            try
            {
                responseAPI.Data = await this.EventService.GetAllEvents();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("update-all")]
        [HttpGet]
        public async Task<IActionResult> updateAllEvents()
        {
            ResponseAPI<List<Event>> responseAPI = new ResponseAPI<List<Event>>();
            try
            {
                responseAPI.Data = await this.EventService.UpdateEventAll();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// Id Decoration
        /// </summary>
        /// <param name="eventid"></param>
        /// <returns></returns>
        [Route("get-decoration-by-eventid")]
        [HttpGet]
        public async Task<IActionResult> GetProductDecordationByEventId(string eventid)
        {
            ResponseAPI<List<Product>> responseAPI = new ResponseAPI<List<Product>>();
            try
            {
                responseAPI.Data = await this.EventService.GetProductDecorationByEvent(eventid);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// ID menu
        /// </summary>
        /// <param name="eventid"></param>
        /// <returns></returns>
        [Route("get-menu-by-eventid")]
        [HttpGet]
        public async Task<IActionResult> GetMenuByEventId(string eventid)
        {
            ResponseAPI<List<FoodDto>> responseAPI = new ResponseAPI<List<FoodDto>>();
            try
            {
                responseAPI.Data = await this.EventService.GetMenuByEvent(eventid);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// Entertainment ID
        /// </summary>
        /// <param name="eventid"></param>
        /// <returns></returns>
        [Route("get-entertainment-by-eventid")]
        [HttpGet]
        public async Task<IActionResult> GetEntertainmentByEvent(string eventid)
        {
            ResponseAPI<List<EntertainmentProduct>> responseAPI = new ResponseAPI<List<EntertainmentProduct>>();
            try
            {
                responseAPI.Data = await this.EventService.GetEntertainmentByEvent(eventid);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("get-event-by-date")]
        [HttpGet]
        public async Task<IActionResult> GetEventByDay(string eventbooker, DateTime minDate, DateTime maxDate)
        {
            ResponseAPI<List<EntertainmentProduct>> responseAPI = new ResponseAPI<List<EntertainmentProduct>>();
            try
            {
                if (minDate > maxDate)
                {
                    var tmp = minDate;
                    minDate = maxDate;
                    maxDate = tmp;
                }
                responseAPI.Data = await this.EventService.GetEventByDay(eventbooker, minDate, maxDate);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("get-event-by-date-admin")]
        [HttpGet]
        public async Task<IActionResult> GetEventByDayAdmin(DateTime minDate, DateTime maxDate)
        {
            ResponseAPI<List<EntertainmentProduct>> responseAPI = new ResponseAPI<List<EntertainmentProduct>>();
            try
            {
                if (minDate > maxDate)
                {
                    var tmp = minDate;
                    minDate = maxDate;
                    maxDate = tmp;
                }
                responseAPI.Data = await this.EventService.GetEventByDayForAdmin(minDate, maxDate);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        // GET api/<EventController>/5
        [Route("insert-event")]
        [HttpPost]
        public async Task<IActionResult> InsertEvent(EventDto eventDto )
        {
            ResponseAPI<List<Event>> responseAPI = new ResponseAPI<List<Event>>();
            try
            {
                responseAPI.Data = await this.EventService.InsertEvent(eventDto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }

        [Route("insert-event-mobile")]
        [HttpPost]
        public async Task<IActionResult> InsertEventmobile(EventRequestDto eventDto)
        {
            ResponseAPI<Event> responseAPI = new ResponseAPI<Event>();
            try
            {
                responseAPI.Data = await this.EventService.InsertDataMobile(eventDto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }

        [Route("update-event-mobile")]
        [HttpPut]
        public async Task<IActionResult> updateEventmobile(UpdateEventMobile eventDto)
        {
            ResponseAPI<Event> responseAPI = new ResponseAPI<Event>();
            try
            {
                responseAPI.Data = await this.EventService.UpdateDataMobile(eventDto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = "false";
                return BadRequest(responseAPI);
            }
        }


        [Route("search-by-id-eventbooker")]
        [HttpGet]
        public async Task<IActionResult> GetEventByEventBookerID(string ID)
        {
            ResponseAPI<Event> responseAPI = new ResponseAPI<Event>();
            try
            {
                responseAPI.Data = await this.EventService.GetEventByEventBookerID(ID);
                return Ok(responseAPI); 
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        [Route("search-script-by-id-event")]
        [HttpGet]
        public async Task<IActionResult> GetScriptByEventID(string ID)
        {
            ResponseAPI<Event> responseAPI = new ResponseAPI<Event>();
            try
            {
                responseAPI.Data = await this.EventService.GetScriptByEvent(ID);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }
        /// <summary>
        /// Id event
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [Route("search-event-by-id-event")]
        [HttpGet]
        public async Task<IActionResult> GetEventByID(string ID)
        {
            ResponseAPI<Event> responseAPI = new ResponseAPI<Event>();
            try
            {
                responseAPI.Data = await this.EventService.GetEventByID(ID);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("update-event")]
        [HttpPut]
        public async Task<IActionResult> UpdateEvent(EventDto eventDto)
        {
            ResponseAPI<List<Event>> responseAPI = new ResponseAPI<List<Event>>();
            try
            {
                responseAPI.Data = await this.EventService.UpdateEvent(eventDto);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("delete-event")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEvent(string id)
        {
            ResponseAPI<List<Event>> responseAPI = new ResponseAPI<List<Event>>();
            try
            {
                responseAPI.Data = await this.EventService.DeleteEvent(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [HttpGet("disable")]
        public async Task<IActionResult> Event()
        {
            ResponseAPI<Event> responseAPI = new ResponseAPI<Event>();
            try
            {
                responseAPI.Data = await this.EventService.disableEvent();
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("export")]
        [HttpGet]
        public async Task<IActionResult> Event(string id)
        {
            ResponseAPI<List<ResponeEventAll>> responseAPI = new ResponseAPI<List<ResponeEventAll>>();
            try
            {
                responseAPI.Data = await this.EventService.ExportData(id);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }

        [Route("export-mobile")]
        [HttpGet]
        public async Task<IActionResult> EventMobile(string eventBookerid)
        {
            ResponseAPI<List<ResponeEventAll>> responseAPI = new ResponseAPI<List<ResponeEventAll>>();
            try
            {
                responseAPI.Data = await this.EventService.ExportDataMobile(eventBookerid);
                return Ok(responseAPI);
            }
            catch (Exception ex)
            {
                responseAPI.Message = ex.Message;
                return BadRequest(responseAPI);
            }
        }


        [Route("export-PDF")]
        [HttpGet]
        public async Task<IActionResult> ExportPDF(string ID)
        {
            AdminConfig ad = new AdminConfig();
            AdminConfigService sv = new AdminConfigService();
            ad = sv.GetConfig();
            var ev = await db.Event.Where(x=>x.EventId.Equals(ID))
                .Select(x => new Event
                {
                    EventId = x.EventId,
                    ScriptId = x.ScriptId,
                    DecorationId = x.DecorationId,
                    EventTypeId = x.EventTypeId,
                    MenuId = x.MenuId,
                    EntertainmentId = x.EntertainmentId,
                    EventBookerId = x.EventBookerId,
                    OrganizedPerson = x.OrganizedPerson,
                    StartDate = x.StartDate,
                    TotalPrice = x.TotalPrice,
                    EndDate = x.EndDate,
                    Status = x.Status,
                    Script = new Script
                    {
                        Id = x.Script.Id,
                        ScriptName = x.Script.ScriptName,
                        Status = x.Script.Status,
                        ScriptContent = x.Script.ScriptContent,
                    },
                    Decoration = new Decoration
                    {
                        DecorationId = x.Decoration.DecorationId,
                        DecorationName = x.Decoration.DecorationName,
                        DecorationPrice = x.Decoration.DecorationPrice,
                        DecorationImage = x.Decoration.DecorationImage,

                    },
                    EventType = new EventType
                    {
                        EventTypeId = x.EventType.EventTypeId,
                        EventTypeName = x.EventType.EventTypeName,
                        EventTypeImage = x.EventType.EventTypeImage,
                        EventTypeDescription = x.EventType.EventTypeDescription,
                    },
                    Menu = new Menu
                    {
                        MenuId = x.Menu.MenuId,
                        MenuName = x.Menu.MenuName,
                        Status = x.Menu.Status,
                        PriceTotal = x.Menu.PriceTotal,
                    },
                    Entertainment = new Entertainment
                    {
                        EntertainmentId = x.Entertainment.EntertainmentId,
                        Status = x.Entertainment.Status,
                        EntertainmentTotal = x.Entertainment.EntertainmentTotal

                    },
                    EventBooker = new EventBooker
                    {
                        EventBookerId = x.EventBooker.EventBookerId,
                        Fullname = x.EventBooker.Fullname,
                        Email = x.EventBooker.Email,
                        Phone = x.EventBooker.Phone,
                        Address = x.EventBooker.Address,
                        RegisterDate = x.EventBooker.RegisterDate,
                        Gender = x.EventBooker.Gender,
                        DateOfBirth = x.EventBooker.DateOfBirth,
                        Image = x.EventBooker.Image,
                        Status = x.EventBooker.Status,
                    },
                }).FirstOrDefaultAsync();
            var menu = await db.Menu.Where(x => x.MenuId.Equals(ev.MenuId)).FirstOrDefaultAsync();
            var menup = await db.MenuProduct.Where(x=>x.MenuId.Equals(ev.MenuId))
                .Select(x => new MenuProduct
                {
                    MenuId = x.MenuId,
                    Product = x.Product,
                    Quatity = x.Quatity,
                    Price = x.Price,
                    Type = x.Type,
                    ProductNavigation = new Food
                    {
                        FoodId = x.ProductNavigation.FoodId,
                        CookingRecipe = x.ProductNavigation.CookingRecipe,
                        Dish = x.ProductNavigation.Dish,
                        FoodDescription = x.ProductNavigation.FoodDescription,
                        FoodImage = x.ProductNavigation.FoodImage,
                        FoodIngredient = x.ProductNavigation.FoodIngredient,
                        FoodName = x.ProductNavigation.FoodName,
                        FoodOrigin = x.ProductNavigation.FoodOrigin,
                        FoodPrice = x.ProductNavigation.FoodPrice,
                        FoodTypeId = x.ProductNavigation.FoodTypeId,
                    }
                })
                .ToListAsync();
            var doc = new PdfDocument();
            string htmlcontent = "<div style='width:100%; text-align:center'>";
            htmlcontent += "<h2>FamilyEvent</h2>";
            htmlcontent += "<h2> Hóa đơn số:" + ev.EventId + " & Ngày: "+ ev.EndDate +" </h2>";
            htmlcontent += "<h3> Tên khách hàng : " + ev.EventBooker.Fullname + "</h3>";
            htmlcontent += "<h3> Liên hệ : "+ad.phone+" & Email : "+ad.email+" </h3>";
            htmlcontent += "<div>";

            htmlcontent += "<h3> THỰC ĐƠN </h3>";
            htmlcontent += "<h3> Tên thực đơn: "+ ev.Menu.MenuName +"</h3>";
            htmlcontent += "<h3> Số bàn: " + menu.TableQuantity + "</h3>";
            htmlcontent += "<h3> Tổng tiền : "+ menu.PriceTotal +" </h3>";
            htmlcontent += "<table style ='width:100%; border: 1px solid #000'>";
            htmlcontent += "<thead style='font-weight:bold'>";
            htmlcontent += "<tr>";
            htmlcontent += "<td style='border:1px solid #000'> Tên món </td>";
            htmlcontent += "<td style='border:1px solid #000'> Mô tả </td>";
            htmlcontent += "<td style='border:1px solid #000'> Số lượng </td>";
            htmlcontent += "<td style='border:1px solid #000'>Giá (món/phần/thùng)</td >";
            htmlcontent += "</tr>";
            htmlcontent += "</thead >";

            htmlcontent += "<tbody>";
            foreach(var item in menup)
            {
                htmlcontent += "<tr>";
                htmlcontent += "<td>" + item.ProductNavigation.FoodName + "</td>";
                htmlcontent += "<td>" + item.ProductNavigation.FoodDescription + "</td>";
                htmlcontent += "<td>" + item.Quatity + "</td >";
                htmlcontent += "<td>" + item.Price + "</td>";
                htmlcontent += "</tr>";
            }
            htmlcontent += "<tbody>";
            htmlcontent += "</table>";
            htmlcontent += "</div>";

            htmlcontent += "<div>";

            var deco = await this.db.Decoration.Where(d=> d.DecorationId.Equals(ev.DecorationId)).FirstOrDefaultAsync();
            var decop = await this.db.DecorationProduct.Where(d => d.DecorationId.Equals(ev.DecorationId))
                .Select(x => new DecorationProductDto
                {
                    DecorationId = x.DecorationId,
                    ProductId = x.ProductId,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Decoration = new DecorationDto
                    {
                        DecorationId = x.Decoration.DecorationId,
                        DecorationName = x.Decoration.DecorationName,
                        DecorationPrice = x.Decoration.DecorationPrice,
                        DecorationImage = x.Decoration.DecorationImage,
                    },
                    Product = new ProductDto
                    {
                        ProductId = x.Product.ProductId,
                        DecorationProductName = x.Product.DecorationProductName,
                        ProductImage = x.Product.ProductImage,
                        ProductDetails = x.Product.ProductDetails,
                        ProductPrice = x.Product.ProductPrice,
                        ProductQuantity = x.Product.ProductQuantity,
                        ProductSupplier = x.Product.ProductSupplier,
                        Status = x.Product.Status,
                    },
                })
                .ToListAsync();
            htmlcontent += "<h3> VẬT DỤNG TRANG TRÍ </h3>";
            htmlcontent += "<h3> Tổng tiền :"+ deco.DecorationPrice+" </h3>";
            htmlcontent += "<table style ='width:100%; border: 1px solid #000'>";
            htmlcontent += "<thead style='font-weight:bold'>";
            htmlcontent += "<tr>";
            htmlcontent += "<td style='border:1px solid #000'> Tên sản phẩm </td>";
            htmlcontent += "<td style='border:1px solid #000'> Mô tả </td>";
            htmlcontent += "<td style='border:1px solid #000'> Số lượng </td>";
            htmlcontent += "<td style='border:1px solid #000'> Giá (vật dụng)</td >";
            htmlcontent += "</tr>";
            htmlcontent += "</thead >";

            htmlcontent += "<tbody>";
            foreach (var item in decop)
            {
                htmlcontent += "<tr>";
                htmlcontent += "<td>" + item.Product.DecorationProductName + "</td>";
                htmlcontent += "<td>" + item.Product.ProductDetails + "</td>";
                htmlcontent += "<td>" + item.Quantity + "</td >";
                htmlcontent += "<td>" + item.Price + "</td>";
                htmlcontent += "</tr>";
            }
            htmlcontent += "<tbody>";
            htmlcontent += "</table>";
            htmlcontent += "</div>";

            htmlcontent += "<div>";

            var e = await this.db.Entertainment.Where(x=>x.EntertainmentId.Equals(ev.EntertainmentId)).FirstOrDefaultAsync();
            var ep = await this.db.EntertainmentProduct.Where(x => x.EntertainmentId.Equals(ev.EntertainmentId))
                .Select(x => new EntertainmentProduct
                {
                    EntertainmentId = x.EntertainmentId,
                    ProductId = x.ProductId,
                    ShowId = x.ShowId,
                    GameId = x.GameId,
                    EntertainmentProductPrice = x.EntertainmentProductPrice,
                    Quantity = x.Quantity,
                    Game = new GameServices
                    {
                        GameId = x.GameId,
                        GameDetails = x.Game.GameId,
                        GameName = x.Game.GameName,
                        GameImage = x.Game.GameImage,
                        //GameServicePrice= x.Game.GameServicePrice,
                        GameReward = x.Game.GameReward,
                    },
                    Show = new ShowService
                    {
                        ShowId = x.ShowId,
                        Light = x.Show.Light,
                        ShowDescription = x.Show.ShowDescription,
                        ShowImage = x.Show.ShowImage,
                        ShowServiceName = x.Show.ShowServiceName,
                        Singer = x.Show.Singer,
                        Sound = x.Show.Sound,
                    }
                }).ToListAsync();
            htmlcontent += "<h3> GIẢI TRÍ </h3>";
            htmlcontent += "<h3> Tổng tiền : "+ e.EntertainmentTotal +" </h3>";
            htmlcontent += "<table style ='width:100%; border: 1px solid #000'>";
            htmlcontent += "<thead style='font-weight:bold'>";
            htmlcontent += "<tr>";
            htmlcontent += "<td style='border:1px solid #000'> Tên </td>";
            htmlcontent += "<td style='border:1px solid #000'> Mô tả </td>";
            htmlcontent += "<td style='border:1px solid #000'> Số lượng </td>";
            htmlcontent += "<td style='border:1px solid #000'> Giá (100.000đ)</td >";
            htmlcontent += "</tr>";
            htmlcontent += "</thead >";

            htmlcontent += "<tbody>";
            foreach (var item in ep)
            {
                htmlcontent += "<tr>";
                if(item.ShowId!= null)
                {
                    htmlcontent += "<td>" + item.Show.ShowServiceName + "</td>";
                    htmlcontent += "<td>" + item.Show.ShowDescription + "</td>";
                }
                else if(item.GameId != null) 
                {
                    htmlcontent += "<td>" + item.Game.GameName + "</td>";
                    htmlcontent += "<td>" + item.Game.GameDetails + "</td>";
                }
                htmlcontent += "<td>" + item.Quantity + "</td >";
                htmlcontent += "<td>" + 100000 + "</td>";
                htmlcontent += "</tr>";
            }
            htmlcontent += "<tbody>";
            htmlcontent += "</table>";
            htmlcontent += "</div>";

            htmlcontent += "<h3> TỔNG TIỀN CHO TOÀN BỘ SỰ KIỆN : "+ev.TotalPrice+" </h3>";

            htmlcontent += "</div>";

            PdfGenerator.AddPdfPages(doc, htmlcontent, PageSize.A4);
            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                doc.Save(ms);
                response = ms.ToArray();
            }
            string Filename = "Invoice_" + ID + ".pdf";
            return File(response, "application/pdf", Filename);
        }
    }
}
