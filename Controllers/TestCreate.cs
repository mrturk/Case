using Case.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Case.Controllers
{
    [Authorize]
    [ApiController]
    public class TestCreate : ControllerBase
    {


        private readonly MyWebApiContext _MyWebApiContext;

        public TestCreate(MyWebApiContext myWebApiContext)
        {
            this._MyWebApiContext = myWebApiContext;
        }




        [AllowAnonymous]
        [HttpPost]
        [Route("test/create")]
        public IActionResult create(TestElementModel data)
        {
            string[] city = { "Ankara", "İstanbul", "İzmir", "Bursa", "Edirne", "Konya", "Antalya", "Diyarbakır","Van","Rize" };

            Functions.Functions _functions = new Functions.Functions();

            List<Customer> customer = new List<Customer>();

            for (int i = 0; i < data.customerCount; i++)
            {
                Random rnd = new Random();

                customer.Add(new Customer
                {
                    Ad=_functions.randomString(),
                    Soyad= _functions.randomString(),
                    Sehir=city[rnd.Next(0,10)]
                });
            }

            List<Basket> basket = new List<Basket>();
            _MyWebApiContext.Customer.AddRange(customer);
            _MyWebApiContext.SaveChanges();

            var customers = _MyWebApiContext.Customer.ToList();

            for (int i = 0; i < data.basketCount; i++)
            {
                Random rndCustomerId = new Random();
                basket.Add(new Basket {
                    MusterId=customer[rndCustomerId.Next(0,data.customerCount)].Id.ToString()
                });
            }
            _MyWebApiContext.Basket.AddRange(basket);
            _MyWebApiContext.SaveChanges();

            var baskets = _MyWebApiContext.Basket.ToList();


            List<BasketProduct> basketProduct = new List<BasketProduct>();
            for (int i = 0; i < baskets.Count; i++)
            {
                Random rnd = new Random();
                for (int j = 0; j < rnd.Next(1, 6); j++)
                {
                    basketProduct.Add(new BasketProduct
                    {
                        Aciklama = _functions.randomString(),
                        Tutar = rnd.Next(100, 1000),
                        SepetId = baskets[i].Id
                    });
                }
   
            }


            _MyWebApiContext.BasketProduct.AddRange(basketProduct);
            _MyWebApiContext.SaveChanges();
            return Ok();
        }
        


        [AllowAnonymous]
        [HttpGet]
        [Route("test/cityBasedAnalysis")]
        public IActionResult cityBasedAnalysis()
        {
            string[] city = { "Ankara", "İstanbul", "İzmir", "Bursa", "Edirne", "Konya", "Antalya", "Diyarbakır", "Van", "Rize" };

            List<DtoCityAnalysis> dtoCityAnalyses = new List<DtoCityAnalysis>();



            for (int i = 0; i < 9; i++)
            {
                int basketCount = 0;
                float price = 0;
                var cityforId = _MyWebApiContext.Customer.Where(m => m.Sehir == city[i]).ToList();

                for (int j = 0; j < cityforId.Count; j++)
                {
                    var basketforcityId = _MyWebApiContext.Basket.Where(s => s.Id == cityforId[j].Id).ToList();

                    for (int k = 0; k < basketforcityId.Count; k++)
                    {
                        
                        var basketproductforbasketId = _MyWebApiContext.BasketProduct.Where(n => n.Id == basketforcityId[k].Id).ToList();
                        basketCount++;

                        for (int m = 0; m < basketproductforbasketId.Count; m++)
                        {
                            price += basketproductforbasketId[m].Tutar;
                        }
                    }
                }

                dtoCityAnalyses.Add(new DtoCityAnalysis
                {
                    SehirAdi = city[i],
                    SepetAdet = basketCount,
                    ToplamTutar = price
                });
                basketCount = 0;
                price = 0;
            }
            return Ok(dtoCityAnalyses);
        }

    }
}
