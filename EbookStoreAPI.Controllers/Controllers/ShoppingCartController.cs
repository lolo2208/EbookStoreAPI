using EbookStoreAPI.DAL.Interfaces;
using EbookStoreAPI.DTO;
using EbookStoreAPI.Services.EntitiesServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EbookStoreAPI.Controllers.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShopCartService _shopCartService;

        public ShoppingCartController(IShopCartService shopCartService)
        {
            _shopCartService = shopCartService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCartDTO>>> GetShoppingCarts()
        {
            try
            {
                var ShoppingCarts = await _shopCartService.GetAllShoppingCartsAsync();
                return Ok(ShoppingCarts);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{idShoppingCart}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ShoppingCartDTO>>> GetShoppingCartById(int idShoppingCart)
        {
            try
            {
                var findedShoppingCart = await _shopCartService.FindShoppingCartById(idShoppingCart);
                return Ok(findedShoppingCart);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{idUser}")]
        public async Task<ActionResult<IEnumerable<ShoppingCartDTO>>> GetShoppingCartByUser(int idUser)
        {
            try
            {
                var findedShoppingCart = await _shopCartService.FindShoppingCartByUser(idUser);
                return Ok(findedShoppingCart);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCartDTO>> CreateShoppingCart(ShoppingCartDTO shoppingCart)
        {
            try
            {
                var addedShoppingCart = await _shopCartService.CreateShoppingCart(shoppingCart);
                return Ok(addedShoppingCart);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut("{idShoppingCart}")]
        public async Task<ActionResult<ShoppingCartDTO>> UpdateShoppingCart(ShoppingCartDTO shoppingCart, int idShoppingCart)
        {
            try
            {
                if (idShoppingCart == shoppingCart.IdShopCart)
                {
                    var updatedShoppingCart = await _shopCartService.UpdateShoppingCart(shoppingCart);
                    return Ok(updatedShoppingCart);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete("{idShoppingCart}")]
        public async Task<ActionResult<ShoppingCartDTO>> DeleteShoppingCart(int idShoppingCart)
        {
            try
            {
                {
                    var findedShoppingCart = await _shopCartService.FindShoppingCartById(idShoppingCart);
                    if (findedShoppingCart != null)
                    {
                        var deletedShoppingCart = await _shopCartService.DeleteShoppingCart(findedShoppingCart.IdShopCart);
                        return Ok(deletedShoppingCart);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
