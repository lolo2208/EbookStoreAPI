using EbookStoreAPI.DAL.Interfaces;
using EbookStoreAPI.DTO;
using EbookStoreAPI.Services.EntitiesServices.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EbookStoreAPI.Controllers.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShopCartDetailController : ControllerBase
    {
        private readonly ShopCartService _shopCartService;


        public ShopCartDetailController(ShopCartService shopCartService)
        {
            _shopCartService = shopCartService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopCartDetailDTO>>> GetShopCartDetails()
        {
            try
            {
                var shopCartDetails = await _shopCartService.GetAllShoppingCartDetailsAsync();
                return Ok(shopCartDetails);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{idShopCartDetail}")]
        public async Task<ActionResult<IEnumerable<ShopCartDetailDTO>>> GetShopCartDetailById(int idShopCartDetail)
        {
            try
            {
                var findedShopCartDetail = await _shopCartService.FindShoppingCartDetailById(idShopCartDetail);
                return Ok(findedShopCartDetail);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ShopCartDetailDTO>> CreateShopCartDetail(ShopCartDetailDTO shopCartDetail)
        {
            try
            {
                var addedShopCartDetail = await _shopCartService.CreateShoppingCartDetail(shopCartDetail);
                return Ok(addedShopCartDetail);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public async Task<ActionResult<ShopCartDetailDTO>> UpdateShopCartDetail(ShopCartDetailDTO shopCartDetail, int idShopCartDetail)
        {
            try
            {
                if (idShopCartDetail == shopCartDetail.IdShopCartDetail)
                {
                    var updatedShopCartDetail = await _shopCartService.UpdateShoppingCartDetail(shopCartDetail);
                    return Ok(updatedShopCartDetail);
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

        [HttpDelete("{idShopCartDetail}")]
        public async Task<ActionResult<ShopCartDetailDTO>> DeleteShopCartDetail(int idShopCartDetail)
        {
            try
            {
                {
                    var findedShopCartDetail = await _shopCartService.FindShoppingCartDetailById(idShopCartDetail);
                    if (findedShopCartDetail != null)
                    {
                        var deletedShopCartDetail = await _shopCartService.DeleteShoppingCartDetail(findedShopCartDetail.IdShopCartDetail);
                        return Ok(deletedShopCartDetail);
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

        [HttpGet("{idUser}")]
        public async Task<ActionResult<ShopCartDetailDTO>> GetCartDetailByUser(int idUser)
        {
            try
            {
                {
                    var findedShopCartDetail = await _shopCartService.finUserCartDetails(idUser);
                    if (findedShopCartDetail.Count > 0)
                    {
                        return Ok(findedShopCartDetail);
                    }
                    else
                    {
                        return NotFound();
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
