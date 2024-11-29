using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjetoCrud.Data;
using ProjetoCrud.Dto.Produto;
using ProjetoCrud.Models;

namespace ProjetoCrud.Service.Produto
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context;
            
        }

        public async Task<ResponseModel<List<ProdutoModel>>> DeleteProduto(int idProduto)
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();

            try
            {
                var produto = await _context.Produtos.FirstOrDefaultAsync(produtoBando => produtoBando.id == idProduto);

                if (produto != null) 
                {
                    _context.Remove(produto);
                    await _context.SaveChangesAsync();

                    resposta.Dados = await _context.Produtos.ToListAsync();
                    resposta.Mensagem = "Produto removido com sucesso";

                    return resposta;
                }
                else
                {
                    resposta.Mensagem = "Nenhum produto encontrado";
                    return resposta;
                }
            }
            catch(Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProdutoModel>>> EditProduto(ProdutoEdicaoDto produtoEdicaoDto)
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();
            try
            {
                var produto = await _context.Produtos.FirstOrDefaultAsync(produtoBanco => produtoBanco.id == produtoEdicaoDto.id);

                if (produto != null)
                {
                    produto.nome = produtoEdicaoDto.nome;
                    produto.descricao = produtoEdicaoDto.descricao;

                    _context.Update(produto);
                    await _context.SaveChangesAsync();

                    resposta.Dados = await _context.Produtos.ToListAsync();
                    resposta.Mensagem = "Editado com sucesso";

                    return resposta;
                }
                else
                {
                    resposta.Mensagem = "Nenhum produto encontrado";
                    return resposta;
                }

            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProdutoModel>>> GetProdutos()
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();
            try
            {
                var produtos = await _context.Produtos.ToListAsync();

                resposta.Dados = produtos;
                resposta.Mensagem = "todos os produtos foram coletados";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        //public async Task<ResponseModel<ProdutoModel>> GetProdutosId(int idProduto)
        //{
        //    ResponseModel<ProdutoModel> resposta = new ResponseModel<ProdutoModel>();
        //    try 
        //    {
        //        var produto = await _context.Produtos.FirstOrDefaultAsync(produtoBanco => produtoBanco.id == idProduto);
        //        if(produto == null)
        //        {
        //            resposta.Mensagem = "Nenhum produto";
        //            return resposta;
        //        }

        //        resposta.Dados = produto;
        //        resposta.Mensagem = "Produto localizado";
        //        return resposta;
        //    }
        //    catch (Exception ex) 
        //    {
        //        resposta.Mensagem = ex.Message;
        //        resposta.Status = false;
        //        return resposta;
        //    }
        //}

        public async Task<ResponseModel<List<ProdutoModel>>> PostProdutos(ProdutoCriacaoDto produtoCriacaoDto)
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();
            try
            {
                var produto = new ProdutoModel()
                {
                    nome = produtoCriacaoDto.nome,
                    descricao = produtoCriacaoDto.descricao
                };

                _context.Add(produto);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Produtos.ToListAsync();
                resposta.Mensagem = "Produto criado com sucesso";   
                return resposta;

            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
