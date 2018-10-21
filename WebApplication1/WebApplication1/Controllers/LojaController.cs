using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LojaController : Controller
    {
        public ActionResult Index()
        {
            BdLojasEntities db = new BdLojasEntities();
            IEnumerable<Lojas> lojas = db.Lojas.ToList();

            return View(lojas);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Editar(int? Id)
        {
            return View();
        }

        public ActionResult MudarSituacao(int Id)
        {
            try
            {
                BdLojasEntities db = new BdLojasEntities();
                Lojas loja = db.Lojas.Find(Id);
                loja.Ativo = !loja.Ativo;
                db.SaveChanges();
                return RedirectToAction("index", "loja");
            }
            catch(Exception)
            {
                return HttpNotFound();
            }
        }

        public ActionResult Excluir(int Id)
        {
            try
            {
                BdLojasEntities db = new BdLojasEntities();
                Lojas loja = db.Lojas.Find(Id);
                db.Lojas.Remove(loja);
                db.SaveChanges();
                return RedirectToAction("index", "loja");
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public void Inserir(FormCollection form)
        {
            try
            {
                BdLojasEntities db = new BdLojasEntities();
                Lojas loja = new Lojas
                {
                    RazaoSocial = form["razao"],
                    NomeFantasia = form["fantasia"],
                    Cnpj = form["cnpj"],
                    Email = form["email"],
                    Endereco = form["endereco"],
                    Cidade = form["cidade"],
                    Esatado = form["estado"],
                    Telefone = form["telefone"],
                    Agencia = form["agencia"],
                    Conta = form["conta"],
                    IdCategoria = int.Parse(form["idCategoria"]),
                    Ativo = true,
                    DataCadastro = DateTime.Now

                };
                db.Lojas.Add(loja);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}