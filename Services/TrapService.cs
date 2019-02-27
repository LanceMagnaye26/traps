using System.Collections.Generic;
using System.Linq;
using TrapApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace TrapApi.Services
{
    public class TrapService
    {
        private readonly IMongoCollection<Trap> _traps;

        public TrapService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("TrapDb"));
            var database = client.GetDatabase("TrapDb");
            _traps = database.GetCollection<Trap>("Trap");
        }

        public List<Trap> Get()
        {
            return _traps.Find(trap => true).ToList();
        }

        public Trap Get(string id)
        {
            return _traps.Find<Trap>(trap => trap.Id == id).FirstOrDefault();
        }

        public Trap Create(Trap trap)
        {
            _traps.InsertOne(trap);
            return trap;
        }

        public void Update(string id, Trap trapIn)
        {
            _traps.ReplaceOne(trap => trap.Id == id, trapIn);
        }

        public void Remove(Trap trapIn)
        {
            _traps.DeleteOne(trap => trap.Id == trapIn.Id);
        }

        public void Remove(string id)
        {
            _traps.DeleteOne(trap => trap.Id == id);
        }
    }
}