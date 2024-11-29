using ProjetoCrud.Dto.Produto;
using ProjetoCrud.Models;

namespace ProjetoCrud.Service.Produto
{
    public interface IProdutoInterface
    {
        Task<ResponseModel<List<ProdutoModel>>> GetProdutos();
        //Task<ResponseModel<ProdutoModel>> GetProdutosId(int idProduto);
        Task<ResponseModel<List<ProdutoModel>>> PostProdutos(ProdutoCriacaoDto produtoCriacaoDto);
        Task<ResponseModel<List<ProdutoModel>>> EditProduto(ProdutoEdicaoDto produtoEdicaoDto);
        Task<ResponseModel<List<ProdutoModel>>> DeleteProduto(int idProduto);

    }
}
