using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCrud.Dto.Produto;
using ProjetoCrud.Models;
using ProjetoCrud.Service.Produto;

namespace ProjetoCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoInterface _produtoInterface;

        public ProdutoController(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }


        [HttpGet("GetProdutos")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> GetProdutos()
        {
            var produtos = await _produtoInterface.GetProdutos();
            return Ok(produtos);
        }

        //[HttpGet("GetProdutosId")]
        //public async Task<ActionResult<ResponseModel<ProdutoModel>>> GetProdutosId(int idProduto)
        //{
        //    var produto = await _produtoInterface.GetProdutosId(idProduto);
        //    return Ok(produto);
        //}

        [HttpPost("PostProdutos")]

        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> PostProdutos(ProdutoCriacaoDto produtoCriacaoDto)
        {
            var produto = await _produtoInterface.PostProdutos(produtoCriacaoDto);
            return Ok(produto);
        }

        [HttpDelete("DeleteProduto")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> DeleteProduto(int idProduto)
        {
            var produto = await _produtoInterface.DeleteProduto(idProduto);
            return Ok(produto);
        }
        
        [HttpPut("EditProduto")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> EditProduto(ProdutoEdicaoDto produtoEdicaoDto)
        {
            var produto = await _produtoInterface.EditProduto(produtoEdicaoDto);
            return Ok(produto);
        }
    }
}
