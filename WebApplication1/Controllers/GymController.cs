using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.GymModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/Gym")]
    [ApiController]
    public class GymController : ControllerBase
    {
        //ApplicationDbContext can then be used in ASP.NET Core controllers or other services through constructor injection.
        private readonly MasterContext _context;
        private readonly SPContext _contextSP;
        private IConfiguration Configuration { get; }

        public GymController(MasterContext context, SPContext contextSp, IConfiguration configuration)
        {
            //The final result is an ApplicationDbContext instance created for each request and passed to the controller to perform a unit - of - work before being disposed when the request ends.
            _context = context;
            //Para as SPs com FromSqlRaw
            _contextSP = contextSp;
            //para as SPs de 2 result Set
            Configuration = configuration;
        }
        // GET: api/GetGym
        [HttpGet]
        public ActionResult<IEnumerable<SPGetGymModel>> GetGym()
        {
            var ErrorCode = new ErrorHandler();
            var result = new List<SPGetGymModel>();
            var SPConnection = new DatasetGeneratorFromSP();
            var conn2 = new SqlConnection();
            try
            {
                conn2.ConnectionString = Configuration.GetConnectionString("MasterContext");
                var DataSet = SPConnection.ConsumeSP("EXECUTE dbo.SP_GetGym", new SqlParameter[] { }, conn2);

                //1o metodo para converter DataSet para/de Json
                var Status = JsonConvert.SerializeObject(DataSet.Tables[0]);
                var Validate = JsonConvert.DeserializeObject<List<Validate>>(Status);
                ErrorCode.CheckStatus(Validate); // Verificar os Erros que vem da BD na Tabela 0

                //2o metodo para converter DataSet para/de Json
                var ResultSp = DataSet.Tables[1].AsEnumerable();
                result = ResultSp.Select(p => new SPGetGymModel
                {
                    Id = p.Field<int>("GymId"),
                    Latitude = p.Field<string>("Latitude"),
                    Longitude = p.Field<string>("Longitude"),
                    Name = p.Field<string>("GymName"),
                    Contact = p.Field<string>("Contact"),
                    Email = p.Field<string>("Email"),
                    Facebook = p.Field<string>("Facebook"),
                    Adress = p.Field<string>("Adress")
                }).ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SPGetGymModel>> GetGymId([FromRoute] int id)
        {
            var resultId = await _context.Gym.FindAsync(id);

            if (resultId == null)
            {
                return NotFound("Ginásio Indicado não se encontra Disponivel na BD");
            }

            //METODO PARA SP COM PARAMETROS E RETORNO DE ERRO POR SP 

            var ErrorCode = new ErrorHandler();
            var result = new SPGetGymModel();
            var SPConnection = new DatasetGeneratorFromSP();
            var conn2 = new SqlConnection();
            try
            {
                SqlParameter[] parameters = {
                new SqlParameter("@Id", id)
                    };
                conn2.ConnectionString = Configuration.GetConnectionString("MasterContext");
                var DataSet = SPConnection.ConsumeSP("EXECUTE dbo.SP_GetGymId @id", parameters, conn2);

                var Status = JsonConvert.SerializeObject(DataSet.Tables[0]);
                var Validate = JsonConvert.DeserializeObject<List<Validate>>(Status);
                ErrorCode.CheckStatus(Validate);
                var ResultSp = DataSet.Tables[1].AsEnumerable();

                result = ResultSp.Select(p => new SPGetGymModel
                {
                    Id = p.Field<int>("GymId"),
                    Adress = p.Field<string>("Adress"),
                    Latitude = p.Field<string>("Latitude"),
                    Longitude = p.Field<string>("Longitude"),
                    Name = p.Field<string>("GymName"),
                    Contact = p.Field<string>("Contact"),
                    Email = p.Field<string>("Email"),
                    Facebook = p.Field<string>("Facebook"),
                }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return result;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGym([FromRoute] int id, [FromBody] UpdateGym input)
        {
            var result = await _context.Gym.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            try
            {
                var Update = new Gym()
                {
                    Id = input.Id,
                    Latitude = input.Latitude,
                    Longitude = input.Longitude,
                    Name = input.Name,
                    Adress = input.Adress,
                    Contact = input.Contact,
                    Email = input.Email,
                    Facebook = input.Facebook
                };
                _context.Update(Update);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!GymIdExists(id))
            {
                return NotFound();
            }
            return Ok("Sucesso");
        }

        [HttpPost]
        public async Task<ActionResult<AddGymOutput>> CreatetGym([FromBody] AddGym input)
        {
            var result = (from p in input.AddGymList
                          select new Gym()
                          {
                              Latitude = p.Latitude,
                              Longitude = p.Longitude,
                              Name = p.Name,
                              Adress = p.Adress,
                              Contact = p.Contact,
                              Email = p.Email,
                              Facebook = p.Facebook
                          }).ToList();

            _context.Gym.AddRange(result);
            await _context.SaveChangesAsync();

            AddGymOutput AddGymOutput1 = new AddGymOutput();
            List<int> output = new List<int>();
            foreach (var item in result)
            {
                output.Add(item.Id);
            }

            AddGymOutput1.Id = output;

            return AddGymOutput1;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGym([FromRoute] int id)
        {
            var result = await _context.Gym.FindAsync(id);

            if (result == null)
            {
                return NotFound("Ginásio Indicado não se encontra Disponivel na BD");
            }
            try
            {
                _context.Gym.Remove(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return NotFound(ex.InnerException);
            }
            

            return Ok("Sucesso");
        }

        private bool GymIdExists(long id) => 
             _context.Gym.Any(e => e.Id == id);
    }
}
