using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using MongoDB.AspNetCore.OData;
using MongoDB.Driver;
using MongoDB_OData.Data;
using MongoDB_OData.Entities;

namespace MongoDB_OData.Controllers
{
    public class CustomerController : ODataController
    {
        private readonly IMongoCollection<Customer> _customers;
        public CustomerController(MongoDbService mongoDbService) 
        {
            _customers = mongoDbService.Database?.GetCollection<Customer>("customer");
        }

        [MongoEnableQuery]
        public ActionResult Get()
        {
            return Ok(_customers.AsQueryable());
        }

        /*[HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _customers.Find(FilterDefinition<Customer>.Empty).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer?>> GetById(string id)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.Id, id);
            var customer = _customers.Find(filter).FirstOrDefault();
            return customer is not null ? Ok(customer) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Customer customer)
        {
            await _customers.InsertOneAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Customer customer)
        {
            var filter = Builders<Customer>.Filter.Eq( c => c.Id, customer.Id);

            //Method 01
            *//*
            var update = Builders<Customer>.Update
                .Set(c => c.Name, customer.Name)
                .Set(c => c.Email, customer.Email);
                .Set(c => c.Address, customer.Address);
                .Set(c => c.NumberOfItems, customer.NumberOfItems);
            await _customers.UpdateOneAsync(filter, update);
            *//*

            //Method 02
            await _customers.ReplaceOneAsync(filter, customer);
            return Ok(customer);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string id)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.Id, id);
            await _customers.DeleteOneAsync(filter);
            return Ok("Deleted the customer successfully ");
        }*/
    }
}
