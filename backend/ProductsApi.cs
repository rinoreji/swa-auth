using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace backend
{
    public static class ProductsApi
    {
        [FunctionName("products")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "put", "delete", Route = "products/{id:int?}")] HttpRequest req,
            int? id,
            ILogger log)
        {
            if (req.Method == HttpMethod.Get.Method)
            {
                var result = new JsonResult(InMemoryStore.GetProducts());
                result.StatusCode = 200;
                return result;
            }
            else if (req.Method == HttpMethod.Post.Method)
            {

                var p = GetProductFromBody(req.Body);
                var prod = InMemoryStore.AddProduct(p);
                var result = new JsonResult(prod);
                result.StatusCode = 201;
                return result;
            }
            else if (req.Method == HttpMethod.Put.Method)
            {
                if (id.HasValue)
                {
                    var p = GetProductFromBody(req.Body);
                    var prod = InMemoryStore.UpdateProduct(id.Value, p);
                    var result = new JsonResult(prod);
                    result.StatusCode = 200;
                    return result;
                }
            }
            else if (req.Method == HttpMethod.Delete.Method)
            {
                if (id.HasValue)
                {
                    InMemoryStore.DeleteProduct(id.Value);
                    return new EmptyResult();
                }
            }

            return new EmptyResult();

        }

        private static Product GetProductFromBody(Stream body)
        {
            using (StreamReader r = new StreamReader(body))
            using (JsonReader jr = new JsonTextReader(r))
            {
                var serializer = new JsonSerializer();
                return serializer.Deserialize<Product>(jr);
            }
        }

    }
}
