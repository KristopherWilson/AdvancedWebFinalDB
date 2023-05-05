using webapi.Models;

public interface IService
{
    Task<List<Buildings>> GetAll();

    Task<Buildings> GetById(string id);
    Task<bool> CreateBuilding(string name, string id);
    Task<bool> UpdateBuilding(string name, string id);
    Task<bool> DeleteById(string id);
}