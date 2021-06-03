using API.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Aggregator.Services
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasket(string userName);
    }
}
