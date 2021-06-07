using System;
using System.Collections.Generic;
using Basket.API.Entities;
using Basket.API.Repositories;
using Basket.API.Wrappers;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace Basket.Tests
{
    public class BasketTests
    {
        
        [Fact]
        public async void Basket_GetBasketWithInvalidUser_ShouldReturnNull()
        {
            var redis =new  Mock<IRedisWrapper>();
            var repository =new  BasketRepository(redis.Object);

            redis.Setup(foo => foo.GetStringAsync(It.IsAny<string>()))
                .ReturnsAsync((string)null);
          

            var result = await repository.GetBasket(It.IsAny<string>());

            Assert.Null(result);
        }
        
        [Fact]
        public async void Basket_GetBasketWithValidUser_ShouldReturnNull()
        {
            var redis =new  Mock<IRedisWrapper>();
            var repository =new  BasketRepository(redis.Object);

            var serializedBasket = "{\"UserName\":\"user\",\"Items\":[{\"Quantity\":1,\"Color\":\"red\",\"Price\":12.0,\"ProductId\":\"123456789\",\"ProductName\":\"horse\"}],\"TotalPrice\":12.0}";
            redis.Setup(foo => foo.GetStringAsync("user"))
                .ReturnsAsync(serializedBasket);
          
        
            var result = await repository.GetBasket("user");
            var serializedResult = JsonConvert.SerializeObject(result);
            
            Assert.Equal(serializedResult,serializedBasket);
        }
        
        [Fact]
        public async void Basket_DeleteBasketWithValidUser_ShouldSucceed()
        {
            var redis =new  Mock<IRedisWrapper>();
            var repository =new  BasketRepository(redis.Object);
            
            var userName = "user";
            
            await repository.DeleteBasket(userName);
            
            redis.Verify(r=>r.RemoveAsync(userName));
       
        }
        
        [Fact]
        public async void Basket_UpdateBasket_ShouldSucceed()
        {
            var redis =new  Mock<IRedisWrapper>();
            var repository =new  BasketRepository(redis.Object);

            var basket = new ShoppingCart()
            {
                UserName = "user",
                Items = new List<ShoppingCartItem>
                {
                    new ShoppingCartItem()
                        {Color = "red",Price = 12,ProductId = "12345678",
                            ProductName = "horse",Quantity = 1}
                }
            };
            
            
            await repository.UpdateBasket(basket);
            
            redis.Verify(r=>r.SetStringAsync(basket.UserName,basket));
       
        }
    }
}