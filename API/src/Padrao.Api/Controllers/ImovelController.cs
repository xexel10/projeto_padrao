using Padrao.Api.DTOs;
using Padrao.Business.Interfaces;
using Padrao.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Padrao.Api.Controllers
{

    [Authorize]
    [Route("api/[Controller]")]
    public class ImovelController : MainController
    {

        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public ImovelController(IUnitOfWork contexto,
                                IMapper mapper) : base()
        {
            _uof = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ImovelDTO>> Get()
        {
            var imovel = _uof.ImovelRepository.Get().ToList();
            var imovelDto = _mapper.Map<List<ImovelDTO>>(imovel);

            return imovelDto;

        }

        [HttpGet("{_id:int}")]
        public async Task<ActionResult<ImovelDTO>> GetByID(int _id)
        {
            var imovel = await _uof.ImovelRepository.GetById(p => p.Id == _id);

            if (imovel == null) return NotFound();

            var imovelDto = _mapper.Map<ImovelDTO>(imovel);
            return Ok(imovel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ImovelDTO imovelDto)
        {
            var imovel = _mapper.Map<Imovel>(imovelDto);

            _uof.ImovelRepository.Add(imovel);
            _uof.Commit();

            var imovelDTO = _mapper.Map<ImovelDTO>(imovel);
            return Ok(imovelDTO);
        }

        [HttpPut("{_id:int}")]
        public async Task<ActionResult> Put(int _id, [FromBody] ImovelDTO imovelDto)
        {

            try
            {
                if (_id != imovelDto.Id)
                {
                    return BadRequest();
                }

                var imovel = _mapper.Map<Imovel>(imovelDto);

                _uof.ImovelRepository.Update(imovel);
                await _uof.Commit();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar dados do imovel com id =  {_id}");
            }
        }


        [HttpDelete("{_id:int}")]
        public async Task<ActionResult<ImovelDTO>> Delete(int _id)
        {

            try
            {
                var imovel = await _uof.ImovelRepository.GetById(p => p.Id == _id);

                if (imovel == null)
                {
                    return NotFound();
                }

                _uof.ImovelRepository.Delete(imovel);
                await _uof.Commit();

                var imovelDto = _mapper.Map<ImovelDTO>(imovel);
                return imovelDto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir o imovel de id = {_id}");
            }

        }

    }
}
