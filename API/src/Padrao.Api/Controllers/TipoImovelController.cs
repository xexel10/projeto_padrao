using Padrao.Api.DTOs;
using Padrao.Business.Interfaces;
using Padrao.Business.Models;
using Padrao.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Padrao.Api.Controllers
{

    [Authorize]
    [Route("api/[Controller]")]
    public class TipoImovelController : MainController
    {

        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public TipoImovelController(IUnitOfWork contexto,
                                   IMapper mapper) : base()
        {
            _uof = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TipoImovelDTO>> Get()
        {
            var tipoImovel = _uof.TipoImovelRepository.Get().ToList();
            var tipoImovelDto = _mapper.Map<List<TipoImovelDTO>>(tipoImovel);

            return tipoImovelDto;

        }

        [HttpGet("{_id:int}")]
        public async Task<ActionResult<TipoImovelDTO>> GetByID(int _id)
        {
            var tipoImovel = await _uof.TipoImovelRepository.GetById(p => p.Id == _id);

            if (tipoImovel == null) return NotFound();

            var tipoImovelDto = _mapper.Map<TipoImovelDTO>(tipoImovel);
            return Ok(tipoImovel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TipoImovelDTO tipoImovelDto)
        {
            var tipoImovel = _mapper.Map<TipoImovel>(tipoImovelDto);

            _uof.TipoImovelRepository.Add(tipoImovel);
            _uof.Commit();

            var tipoImovelDTO = _mapper.Map<TipoImovelDTO>(tipoImovel);
            return Ok(tipoImovelDTO);
        }

        [HttpPut("{_id:int}")]
        public async Task<ActionResult> Put(int _id, [FromBody] TipoImovelDTO tipoImovelDto)
        {


            try
            {
                if (_id != tipoImovelDto.Id)
                {
                    return BadRequest();
                }

                var tipoImovel = _mapper.Map<TipoImovel>(tipoImovelDto);

                _uof.TipoImovelRepository.Update(tipoImovel);
                await _uof.Commit();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar dados do tipoImovel com id =  {_id}");
            }
        }


        [HttpDelete("{_id:int}")]
        public async Task<ActionResult<TipoImovelDTO>> Delete(int _id)
        {

            try
            {
                var tipoImovel = await _uof.TipoImovelRepository.GetById(p => p.Id == _id);

                if (tipoImovel == null)
                {
                    return NotFound();
                }

                _uof.TipoImovelRepository.Delete(tipoImovel);
                await _uof.Commit();

                var tipoImovelDto = _mapper.Map<TipoImovelDTO>(tipoImovel);
                return tipoImovelDto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir o tipoImovel de id = {_id}");
            }

        }

    }
}
