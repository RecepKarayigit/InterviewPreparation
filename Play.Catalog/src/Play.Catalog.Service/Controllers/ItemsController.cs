using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;

namespace Play.Catalog.Service.Controllers
{

    [ApiController]
    [Route("items")]
    // https://localhost:5001/items
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDto> items = new()
        {
            new ItemDto (Guid.NewGuid(), "Potion","Restores a small amount of HP", 5 , DateTimeOffset.UtcNow),
            new ItemDto (Guid.NewGuid(), "Antidote","Cures poison", 7 , DateTimeOffset.UtcNow),
            new ItemDto (Guid.NewGuid(), "Bronz sword","Deals a small amount of damage", 20 , DateTimeOffset.UtcNow)
        };

        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            return items;
        }


        // GET /items/{id
        [HttpGet("{id}")]
        public ItemDto GetById(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return item;
        }

    }

}