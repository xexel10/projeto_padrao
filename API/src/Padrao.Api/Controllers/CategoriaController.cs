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
    public class CategoriaController : MainController
    {

        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public CategoriaController(IUnitOfWork contexto,
                                   IMapper mapper) : base()
        {
            _uof = contexto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categoria = await _uof.CategoriaRepository.Get().ToListAsync();
            var categoriaDto = _mapper.Map<List<CategoriaDTO>>(categoria);

            return categoriaDto;

        }

        [HttpGet("{_id:int}")]
        public async Task<ActionResult<CategoriaDTO>> GetByID(int _id)
        {
            var categoria = await _uof.CategoriaRepository.GetById(p => p.Id == _id);

            if (categoria == null) return NotFound();

            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO CategoriaDto)
        {
            try
            {
                var categoria = _mapper.Map<Categoria>(CategoriaDto);

                _uof.CategoriaRepository.Add(categoria);
                await _uof.Commit();

                var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria); 
                return Ok(categoriaDTO);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar imóvel. Erro: {ex.Message}");
            }
        }

        [HttpPut("{_id:int}")]
        public async Task<ActionResult> Put(int _id, [FromBody] CategoriaDTO categoriaDto)
        {


            try
            {
                if (_id != categoriaDto.Id)
                {
                    return BadRequest();
                }

                var categoria = _mapper.Map<Categoria>(categoriaDto);

                _uof.CategoriaRepository.Update(categoria);
                await _uof.Commit();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar dados do categoria com id =  {_id}");
            }
        }


        [HttpDelete("{_id:int}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int _id)
        {

            try
            {
                var categoria = await _uof.CategoriaRepository.GetById(p => p.Id == _id);

                if (categoria == null)
                {
                    return NotFound();
                }

                _uof.CategoriaRepository.Delete(categoria);
                await _uof.Commit();

                var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);
                return categoriaDto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir o categoria de id = {_id}");
            }

        }

    }
}
