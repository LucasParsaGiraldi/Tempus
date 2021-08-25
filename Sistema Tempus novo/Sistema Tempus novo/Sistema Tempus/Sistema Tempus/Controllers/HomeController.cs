using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Sistema_Tempus.Models;

namespace Sistema_Tempus.Controllers
{
    public class HomeController : Controller
    {
        ClienteFactory<Cliente> faCliente = new ClienteFactory<Cliente>();
        public ActionResult Index()
        {
            return View(faCliente.SelectAll());
        }


        public ActionResult Manager(int? id)
        {
            if (id != null)
            {
                return View(faCliente.SelectAll().Where(a => a.Cliente_ID == id).FirstOrDefault());
            }
            else
            {
                Cliente cliente = new Cliente();
                return View(cliente);
            }
        }

        [HttpPost]
        public ActionResult Manager(Cliente model)
        {
            model.Renda_Familiar.ToString().Replace(".", "").Replace(",", "");

            if (ModelState.IsValid)
            {
                if (model.Cliente_ID <= 0)
                {
                    model.Data_Cadastro = DateTime.Today;
                    faCliente.Save(model);
                }
                else
                {
                    faCliente.Update(model);
                }
                return RedirectToAction("Index", new { q = "create-sucess" });
            }
            else
            {
                return RedirectToAction("Index", new { q = "create-erro" });
            }
        }

        public ActionResult Relatorios(int? data)
        {
            ClienteModel model = new ClienteModel();



            if( data == null)
            {
                decimal media = 0;
                foreach (var item in faCliente.SelectAll())
                {
                    media = media + item.Renda_Familiar.Value;
                }

                int total = faCliente.SelectAll().Count();
                media = Decimal.Divide(media, total);

                model.MaiorDeIdade = faCliente.SelectAll().Where(a => a.Data_Nascimento.Value.Year <= (DateTime.Today.Year - 18) && a.Renda_Familiar > media).Count();

                model.Geral = faCliente.SelectAll();


                model.ClasseA = faCliente.SelectAll().Where(a => a.Renda_Familiar <= 980).Count();
                model.ClasseB = faCliente.SelectAll().Where(a => a.Renda_Familiar > 980 && a.Renda_Familiar <= 2500).Count();
                model.ClasseC = faCliente.SelectAll().Where(a => a.Renda_Familiar > 2500).Count();
            }
            else if(data == 2)
            {
                decimal media = 0;
                foreach (var item in faCliente.SelectAll())
                {
                    media = media + item.Renda_Familiar.Value;
                }
                var lastWeek = DateTime.Now.AddDays(-1 *(int)+7).Date;
                int total = faCliente.SelectAll().Count();
                media = Decimal.Divide(media, total);

                model.MaiorDeIdade = faCliente.SelectAll().Where(a => a.Data_Nascimento.Value.Year <= (DateTime.Today.Year - 18) && a.Renda_Familiar > media && a.Data_Cadastro.Value >= lastWeek).Count();

                model.Geral = faCliente.SelectAll();

                model.ClasseA = faCliente.SelectAll().Where(a => a.Renda_Familiar <= 980 && a.Data_Cadastro.Value >= lastWeek).Count();
                model.ClasseB = faCliente.SelectAll().Where(a => a.Renda_Familiar > 980 && a.Renda_Familiar <= 2500 && a.Data_Cadastro.Value >= lastWeek).Count();
                model.ClasseC = faCliente.SelectAll().Where(a => a.Renda_Familiar > 2500 && a.Data_Cadastro.Value >= lastWeek).Count();
            }
            else if (data == 1)
            {
                decimal media = 0;
                foreach (var item in faCliente.SelectAll())
                {
                    media = media + item.Renda_Familiar.Value;
                }
                var lastWeek = DateTime.Now.AddDays(-1 * (int)+7).Date;
                int total = faCliente.SelectAll().Count();
                media = Decimal.Divide(media, total);

                model.MaiorDeIdade = faCliente.SelectAll().Where(a => a.Data_Nascimento.Value.Year <= (DateTime.Today.Year - 18) && a.Renda_Familiar > media && a.Data_Cadastro.Value == DateTime.Today).Count();

                model.Geral = faCliente.SelectAll();

                model.ClasseA = faCliente.SelectAll().Where(a => a.Renda_Familiar <= 980 && a.Data_Cadastro.Value == DateTime.Today).Count();
                model.ClasseB = faCliente.SelectAll().Where(a => a.Renda_Familiar > 980 && a.Renda_Familiar <= 2500 && a.Data_Cadastro.Value == DateTime.Today).Count();
                model.ClasseC = faCliente.SelectAll().Where(a => a.Renda_Familiar > 2500 && a.Data_Cadastro.Value == DateTime.Today).Count();
            }

            else if (data == 3)
            {
                decimal media = 0;
                foreach (var item in faCliente.SelectAll())
                {
                    media = media + item.Renda_Familiar.Value;
                }

                int total = faCliente.SelectAll().Count();
                media = Decimal.Divide(media, total);

                model.MaiorDeIdade = faCliente.SelectAll().Where(a => a.Data_Nascimento.Value.Year <= (DateTime.Today.Year - 18) && a.Renda_Familiar > media && a.Data_Cadastro.Value.Month <= DateTime.Now.Month - 1).Count();

                model.Geral = faCliente.SelectAll();


                model.ClasseA = faCliente.SelectAll().Where(a => a.Renda_Familiar <= 980 && a.Data_Cadastro.Value.Month <= DateTime.Now.Month - 1).Count();
                model.ClasseB = faCliente.SelectAll().Where(a => a.Renda_Familiar > 980 && a.Renda_Familiar <= 2500 && a.Data_Cadastro.Value.Month <= DateTime.Now.Month - 1).Count();
                model.ClasseC = faCliente.SelectAll().Where(a => a.Renda_Familiar > 2500 && a.Data_Cadastro.Value.Month <= a.Data_Cadastro.Value.Month - 1).Count();
            }


            return View(model);
        }

        public ActionResult Delete(int id)
        {
            Cliente cliente = new Cliente();
            cliente = faCliente.FindBy(a => a.Cliente_ID == id).FirstOrDefault();
            if (id > 0)
            {
                faCliente.Delete(cliente);
                return RedirectToAction("Index", new { q = "delete-sucess" });
            }
            else
            {
                return RedirectToAction("Index", new { q = "delete-erro" });
            }


        }
    }
}