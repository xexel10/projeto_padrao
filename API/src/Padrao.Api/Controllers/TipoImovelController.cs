using Padrao.Api.DTOs;
using Padrao.Business.Interfaces;
using Padrao.Business.Models;
using Padrao.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoImovelDTO>>> Get()
        {
            var tipoImovel = await _uof.TipoImovelRepository.Get().ToListAsync();
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
        public async Task<ActionResult> Post([FromBody] TipoImovelDTO TipoImovelDto)
        {
            try
            {
                var tipoImovel = _mapper.Map<TipoImovel>(TipoImovelDto);

                _uof.TipoImovelRepository.Add(tipoImovel);
                await _uof.Commit();

                var tipoImovelDTO = _mapper.Map<TipoImovelDTO>(tipoImovel); 
                return Ok(tipoImovelDTO);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar imóvel. Erro: {ex.Message}");
            }
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
