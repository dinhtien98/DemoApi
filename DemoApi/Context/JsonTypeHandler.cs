using Dapper;
using DemoApi.Models.Dtos.PageDtos;
using Newtonsoft.Json;
using System.Data;

namespace DemoApi.Context
{
    public class JsonTypeHandler : SqlMapper.TypeHandler<List<Json>>
    {
        public override List<Json> Parse(object value)
        {
            // Deserialize the JSON string to a List<Json>
            return value is string json ? JsonConvert.DeserializeObject<List<Json>>(json) : new List<Json>();
        }

        public override void SetValue(IDbDataParameter parameter,List<Json> value)
        {
            // Serialize the List<Json> into a JSON string to store in the database
            parameter.Value = JsonConvert.SerializeObject(value);
        }
    }
}
